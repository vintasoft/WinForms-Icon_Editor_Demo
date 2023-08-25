using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageColors;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;

using DemosCommonCode;
using DemosCommonCode.Imaging;

namespace IconEditorDemo
{
    /// <summary>
    /// A form that allows to specify parameters for new pages.
    /// </summary>
    public partial class InsertPageForm : Form
    {

        #region Fields

        /// <summary>
        /// The result of opening an image.
        /// </summary>
        DialogResult _openImageDialogResult = DialogResult.None;

        /// <summary>
        /// A zero-based index of the page in opened image file.
        /// </summary>
        int _openPageIndex = -1;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertPageForm"/> class.
        /// </summary>
        /// <param name="createNewFile">Indicates whether a new file must be created.</param>
        /// <param name="pagesCount">Default value for a number of pages to be inserted.</param>
        public InsertPageForm(bool createNewFile, int pagesCount)
        {
            InitializeComponent();
            insertIndexNumericUpDown.Enabled = !createNewFile;
            insertIndexNumericUpDown.Maximum = (decimal)pagesCount;
            insertIndexNumericUpDown.Value = (decimal)pagesCount;
            typeGroupBox.Visible = createNewFile;
        }

        #endregion



        #region Properties

        VintasoftImage _image;
        /// <summary>
        /// Gets the source image of the icon.
        /// </summary>
        internal VintasoftImage Image
        {
            get
            {
                return _image;
            }
        }

        VintasoftImage _maskImage;
        /// <summary>
        /// Gets the mask image of the icon.
        /// </summary>
        internal VintasoftImage MaskImage
        {
            get
            {
                return _maskImage;
            }
        }

        /// <summary>
        /// Gets the insert index of the new page.
        /// </summary>
        internal int InsertIndex
        {
            get
            {
                return (int)insertIndexNumericUpDown.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the new file is a cursor file.
        /// </summary>
        internal bool IsCursor
        {
            get
            {
                return cursorRadioButton.Checked;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of SelectImageButton object.
        /// </summary>
        private void selectImageButton_Click(object sender, EventArgs e)
        {
            // show open file dialog
            _openImageDialogResult = openImageDialog.ShowDialog();
            // if file is selected
            if (_openImageDialogResult == DialogResult.OK)
            {
                string filename = openImageDialog.FileName;
                int selectedIndex;

                // get selected page index
                using (ImageCollection images = SelectImageForm.SelectImageFromFile(filename, out selectedIndex))
                {
                    if (selectedIndex == -1)
                    {
                        _openImageDialogResult = DialogResult.Cancel;
                        return;
                    }

                    // save selected page index
                    _openPageIndex = selectedIndex;
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // get image size
            int newWidth;
            int newHeight;
            if (!TryGetNewSize(out newWidth, out newHeight))
                return;

            // get the image pixel format
            PixelFormat pixelFormat = GetPixelFormat();

            // if empty page must be created
            if (emptyPageRadioButton.Checked)
            {
                // create new image with specified size
                _image = new VintasoftImage(newWidth, newHeight, pixelFormat);
                // get the background color
                Color backgroundColor = backgroundColorPanelControl.Color;

                // if image is palette image
                if (_image.BitsPerPixel <= 8)
                {
                    // create the default palette for image
                    int[] paletteColors = CreateDefaultPalette(pixelFormat);
                    // set the image palette
                    _image.Palette.SetColors(paletteColors);
                }

                if (backgroundColor != Color.Black)
                {
                    ClearImageCommand clearImageCommand = new ClearImageCommand(backgroundColor);
                    clearImageCommand.ExecuteInPlace(_image);
                }
            }
            // if NOT empty page must be created
            else
            {
                // if image file is not selected in open file dialog
                if (_openImageDialogResult != DialogResult.OK)
                {
                    DemosTools.ShowInfoMessage("Please specify the source image file first.");
                    return;
                }

                try
                {
                    // create image collection
                    using (ImageCollection images = new ImageCollection())
                    {
                        // add selected image file to the image collection
                        images.Add(openImageDialog.FileName);
                        // get image with specified index
                        _image = images[_openPageIndex];
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    _image = null;
                    return;
                }

                // alpha channel mask image
                VintasoftImage alphaChannelMaskImage = null;
                switch (_image.PixelFormat)
                {
                    case PixelFormat.Indexed8:
                    case PixelFormat.Bgra32:
                    case PixelFormat.Bgra64:
                        GetAlphaChannelMaskCommand getAlphaChannelMaskCommand = new GetAlphaChannelMaskCommand();
                        // get the alpha channel mask image
                        alphaChannelMaskImage = getAlphaChannelMaskCommand.Execute(_image);
                        break;
                }

                // a value indicating whether selected pixel format supports alpha channel
                bool isPixelFormatSupportAlphaChannel = false;
                switch (pixelFormat)
                {
                    case PixelFormat.Bgra32:
                        isPixelFormatSupportAlphaChannel = true;
                        break;
                }

                // if the selected pixel format does not match the actual image pixel format
                if (_image.PixelFormat != pixelFormat)
                {
                    ChangePixelFormatCommand changePixelFormatCommand = new ChangePixelFormatCommand(pixelFormat);
                    // convert image to the selected pixel format
                    changePixelFormatCommand.ExecuteInPlace(_image);
                }

                // create a black-white mask image
                _maskImage = new VintasoftImage(newWidth, newHeight, PixelFormat.BlackWhite);

                // if the selected size does not match the actual image size
                if (_image.Width != newWidth || _image.Height != newHeight)
                {
                    // create resized image
                    VintasoftImage resizedImage = new VintasoftImage(newWidth, newHeight, _image.PixelFormat);
                    // if image is palette image
                    if (_image.Palette.ColorCount > 0)
                    {
                        // set palette of resized image
                        resizedImage.Palette.SetColors(_image.Palette.GetAsArray());
                    }

                    // calculate the region of source image, which must be overlaid on the top of resized image
                    int originalWidth = _image.Width;
                    int originalHeight = _image.Height;
                    double ratio = (double)originalWidth / originalHeight;
                    double newRatio = (double)newWidth / newHeight;

                    int width;
                    int height;
                    int offsetX;
                    int offsetY;
                    if (ratio > newRatio)
                    {
                        width = newWidth;
                        offsetX = 0;
                        height = (int)(originalHeight * ((double)newWidth / originalWidth));
                        offsetY = (newHeight - height) / 2;
                    }
                    else
                    {
                        height = newHeight;
                        offsetY = 0;
                        width = (int)(originalWidth * ((double)newHeight / originalHeight));
                        offsetX = (newWidth - width) / 2;
                    }

                    OverlayCommand overlayCommand = new OverlayCommand();
                    overlayCommand.RegionOfInterest = new RegionOfInterest(offsetX, offsetY, width, height);
                    overlayCommand.OverlayImage = _image;
                    // overlay the source image on top of the resized image
                    overlayCommand.ExecuteInPlace(resizedImage);

                    // if source image has alpha channel
                    if (alphaChannelMaskImage != null)
                    {
                        // if selected pixel format supports alpha channel
                        if (isPixelFormatSupportAlphaChannel)
                        {
                            // create alpha channel image
                            using (VintasoftImage alphaChannelImage = new VintasoftImage(newWidth, newHeight, PixelFormat.Gray8))
                            {
                                overlayCommand.OverlayImage = alphaChannelMaskImage;
                                // overlay alpha channel mask on a top of alpha channel image
                                overlayCommand.ExecuteInPlace(alphaChannelImage);

                                SetAlphaChannelMaskCommand setAlphaChannelMaskCommand = new SetAlphaChannelMaskCommand(alphaChannelImage);
                                // set alpha channel in resized image
                                setAlphaChannelMaskCommand.ExecuteInPlace(resizedImage);
                            }
                        }
                        // if selected pixel format does NOT support alpha channel
                        else
                        {
                            InvertCommand invertCommand = new InvertCommand();
                            // create inverted alpha channel mask image
                            using (VintasoftImage invertedAlphaChannelMaskImage = invertCommand.Execute(alphaChannelMaskImage))
                            {
                                ChangePixelFormatToBlackWhiteCommand changePixelFormatToBlackWhiteCommand = new ChangePixelFormatToBlackWhiteCommand(764);
                                // convert the inverted alpha channel mask image to a black-white image
                                changePixelFormatToBlackWhiteCommand.ExecuteInPlace(invertedAlphaChannelMaskImage);

                                overlayCommand.OverlayImage = invertedAlphaChannelMaskImage;
                                // overlay inverted alpha channel mask image on a top of mask image
                                overlayCommand.ExecuteInPlace(_maskImage);
                            }
                        }
                    }

                    // dispose source image
                    _image.Dispose();
                    // use resized image as the source image
                    _image = resizedImage;

                    // clear mask image

                    ClearImageCommand clearImageCommand = new ClearImageCommand(new IndexedColor(_maskImage.Palette, (byte)1));
                    if (offsetX > 0)
                    {
                        clearImageCommand.RegionOfInterest = new RegionOfInterest(0, 0, offsetX, newHeight);
                        clearImageCommand.ExecuteInPlace(_maskImage);

                        clearImageCommand.RegionOfInterest = new RegionOfInterest(newWidth - offsetX, 0, offsetX, newHeight);
                        clearImageCommand.ExecuteInPlace(_maskImage);
                    }
                    else if (offsetY > 0)
                    {
                        clearImageCommand.RegionOfInterest = new RegionOfInterest(0, 0, newWidth, offsetY);
                        clearImageCommand.ExecuteInPlace(_maskImage);

                        clearImageCommand.RegionOfInterest = new RegionOfInterest(0, newHeight - offsetY, newWidth, offsetY);
                        clearImageCommand.ExecuteInPlace(_maskImage);
                    }
                }
                // if the selected size matches the actual image size
                else
                {
                    // if source image has alpha channel
                    if (alphaChannelMaskImage != null)
                    {
                        OverlayCommand overlayCommand = new OverlayCommand();
                        overlayCommand.RegionOfInterest = new RegionOfInterest(0, 0, newWidth, newHeight);
                        // if selected pixel format supports alpha channel
                        if (isPixelFormatSupportAlphaChannel)
                        {
                            // create alpha channel image
                            using (VintasoftImage alphaChannelImage = new VintasoftImage(newWidth, newHeight, PixelFormat.Gray8))
                            {
                                overlayCommand.OverlayImage = alphaChannelMaskImage;
                                // overlay alpha channel mask on a top of alpha channel image
                                overlayCommand.ExecuteInPlace(alphaChannelImage);

                                SetAlphaChannelMaskCommand setAlphaChannelMaskCommand = new SetAlphaChannelMaskCommand(alphaChannelImage);
                                // set alpha channel in resized image
                                setAlphaChannelMaskCommand.ExecuteInPlace(_image);
                            }
                        }
                        // if selected pixel format does NOT support alpha channel
                        else
                        {
                            InvertCommand invertCommand = new InvertCommand();
                            // create inverted alpha channel mask image
                            using (VintasoftImage invertedAlphaChannelMaskImage = invertCommand.Execute(alphaChannelMaskImage))
                            {
                                ChangePixelFormatToBlackWhiteCommand changePixelFormatToBlackWhiteCommand = new ChangePixelFormatToBlackWhiteCommand(765);
                                // convert the inverted alpha channel mask image to a black-white image
                                changePixelFormatToBlackWhiteCommand.ExecuteInPlace(invertedAlphaChannelMaskImage);

                                overlayCommand.OverlayImage = invertedAlphaChannelMaskImage;
                                // overlay inverted alpha channel mask image on a top of mask image
                                overlayCommand.ExecuteInPlace(_maskImage);
                            }
                        }
                    }
                }
            }

            if (_image != null && !_image.IsDisposed)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of EmptyPageRadioButton object.
        /// </summary>
        private void emptyPageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the CheckedChanged event of PageWithImageRadioButton object.
        /// </summary>
        private void pageWithImageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the CheckedChanged event of CustomSizeRadioButton object.
        /// </summary>
        private void customSizeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the CheckedChanged event of Bpp32RadioButton object.
        /// </summary>
        private void bpp32RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            backgroundColorPanelControl.CanEditAlphaChannel = bpp32RadioButton.Checked;

            if (!backgroundColorPanelControl.CanEditAlphaChannel)
                backgroundColorPanelControl.Color = Color.FromArgb(255, backgroundColorPanelControl.Color);
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // get the current status of application
            bool isEmptyPage = emptyPageRadioButton.Checked;
            bool isPageWithImage = pageFromImageRadioButton.Checked;
            bool isCustomSize = customSizeRadioButton.Checked;

            // "Select image" button
            selectImageButton.Enabled = isPageWithImage;

            backgroundColorPanelControl.Enabled = isEmptyPage;

            // insert index
            insertIndexNumericUpDown.Enabled = isPageWithImage || isEmptyPage;

            sizeGroupBox.Text = "Resize to";
            if (isEmptyPage)
                sizeGroupBox.Text = "Size";
            customSizeWidthTextBox.Enabled = isCustomSize;
            customSizeHeightTextBox.Enabled = isCustomSize;

            // "OK" button
            okButton.Enabled = (isPageWithImage && _openImageDialogResult == DialogResult.OK) || isEmptyPage;
        }

        /// <summary>
        /// Returns the selected pixel format.
        /// </summary>
        /// <returns>Selected <see cref="PixelFormat"/>.</returns>
        private PixelFormat GetPixelFormat()
        {
            PixelFormat pixelFormat = PixelFormat.Undefined;
            if (bpp1RadioButton.Checked)
            {
                pixelFormat = PixelFormat.Indexed1;
            }
            else if (bpp4RadioButton.Checked)
            {
                pixelFormat = PixelFormat.Indexed4;
            }
            else if (bpp8RadioButton.Checked)
            {
                pixelFormat = PixelFormat.Indexed8;
            }
            else if (bpp24RadioButton.Checked)
            {
                pixelFormat = PixelFormat.Bgr24;
            }
            else if (bpp32RadioButton.Checked)
            {
                pixelFormat = PixelFormat.Bgra32;
            }

            return pixelFormat;
        }

        /// <summary>
        /// Returns new image size.
        /// </summary>
        /// <param name="newWidth">New image width.</param>
        /// <param name="newHeight">New image height.</param>
        /// <returns>A value indicating whether the size is received successfully.</returns>
        private bool TryGetNewSize(out int newWidth, out int newHeight)
        {
            newWidth = 0;
            newHeight = 0;

            if (size16x16RadioButton.Checked)
            {
                newWidth = 16;
                newHeight = 16;
            }
            else if (size32x32RadioButton.Checked)
            {
                newWidth = 32;
                newHeight = 32;
            }
            else if (size48x48RadioButton.Checked)
            {
                newWidth = 48;
                newHeight = 48;
            }
            else if (size64x64RadioButton.Checked)
            {
                newWidth = 64;
                newHeight = 64;
            }
            else if (size128x128RadioButton.Checked)
            {
                newWidth = 128;
                newHeight = 128;
            }
            else if (size256x256RadioButton.Checked)
            {
                newWidth = 256;
                newHeight = 256;
            }
            else if (customSizeRadioButton.Checked)
            {
                if (!Int32.TryParse(customSizeWidthTextBox.Text, out newWidth))
                {
                    DemosTools.ShowErrorMessage("Invalid custom width specified.");
                    customSizeWidthTextBox.Focus();
                    customSizeWidthTextBox.SelectAll();
                    return false;
                }

                if (!Int32.TryParse(customSizeHeightTextBox.Text, out newHeight))
                {
                    DemosTools.ShowErrorMessage("Invalid custom height specified.");
                    customSizeHeightTextBox.Focus();
                    customSizeHeightTextBox.SelectAll();
                    return false;
                }

                if (newWidth <= 0 || newWidth > 256)
                {
                    DemosTools.ShowErrorMessage("Width must be in range from 1 to 256.");
                    customSizeWidthTextBox.Focus();
                    customSizeWidthTextBox.SelectAll();
                    return false;
                }

                if (newHeight <= 0 || newHeight > 256)
                {
                    DemosTools.ShowErrorMessage("Height must be in range from 1 to 256.");
                    customSizeHeightTextBox.Focus();
                    customSizeHeightTextBox.SelectAll();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Creates an initial palette for the specified pixel format.
        /// </summary>
        /// <returns>An array with palette colors in integer representation.</returns>
        private int[] CreateDefaultPalette(PixelFormat pixelFormat)
        {
            int[] colors = null;
            byte[] rgbTable;
            int index;
            switch (pixelFormat)
            {
                case PixelFormat.Indexed1:
                    colors = new int[2];
                    colors[0] = Color.FromArgb(0, 0, 0).ToArgb();
                    colors[1] = Color.FromArgb(255, 255, 255).ToArgb();
                    break;

                case PixelFormat.Indexed4:
                    colors = new int[16];
                    rgbTable = new byte[2] { 0, 255 };
                    index = 0;
                    for (int red = 0; red < 2; red++)
                    {
                        for (int green = 0; green < 2; green++)
                        {
                            for (int blue = 0; blue < 2; blue++)
                            {
                                colors[index++] = Color.FromArgb(rgbTable[red], rgbTable[green], rgbTable[blue]).ToArgb();
                            }
                        }
                    }

                    while (index < 16)
                    {
                        int gray = (index - 7) * 28;
                        colors[index++] = Color.FromArgb(gray, gray, gray).ToArgb();
                    }
                    break;

                case PixelFormat.Indexed8:
                    rgbTable = new byte[6] { 0, 51, 102, 153, 204, 255 };
                    colors = new int[256];
                    index = 0;
                    for (int red = 0; red < 6; red++)
                    {
                        for (int green = 0; green < 6; green++)
                        {
                            for (int blue = 0; blue < 6; blue++)
                            {
                                colors[index++] = Color.FromArgb(rgbTable[red], rgbTable[green], rgbTable[blue]).ToArgb();
                            }
                        }
                    }
                    break;
            }

            return colors;
        }

        #endregion

    }
}
