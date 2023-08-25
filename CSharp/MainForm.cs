using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.ImageFiles.Ico;
using Vintasoft.Imaging.ImageColors;
using Vintasoft.Imaging.UI;

using DemosCommonCode;
using DemosCommonCode.Imaging;

namespace IconEditorDemo
{
    /// <summary>
    /// Main form of Icon Editor Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Application's title.
        /// </summary>
        static readonly string _mainFormTitle = string.Format("VintaSoft Icon Editor Demo v{0}", ImagingGlobalSettings.ProductVersion);

        /// <summary>
        /// Opened ICO file.
        /// </summary>
        IconFile _iconFile;

        /// <summary>
        /// A value indicating whether current file is virtual.
        /// </summary>
        bool _isVirtual;

        /// <summary>
        /// A value indicating whether current file is a cursor file.
        /// </summary>
        bool _isCursor;

        /// <summary>
        /// A value indicating whether hotspot values are changing.
        /// </summary>
        bool _isHotspotValuesAreChanging = false;

        /// <summary>
        /// Dictionary: thumbnail image => source image.
        /// </summary>
        Dictionary<VintasoftImage, VintasoftImage> _sourceImages;

        /// <summary>
        /// Dictionary: thumbnail image => mask image.
        /// </summary>
        Dictionary<VintasoftImage, VintasoftImage> _maskImages;

        /// <summary>
        /// Dictionary: thumbnail image => page index. 
        /// </summary>
        Dictionary<VintasoftImage, int> _pageIndexes;

        /// <summary>
        /// Dictionary: thumbnail image => image is changed.
        /// </summary>
        Dictionary<VintasoftImage, bool> _isImageChanged;

        /// <summary>
        /// The current page index.
        /// </summary>
        int _currentPageIndex = -1;

        /// <summary>
        /// A value indicating whether drawing is performed.
        /// </summary>
        bool _isDrawing;

        /// <summary>
        /// X coordinate of the last drawing point on image.
        /// </summary>
        int _lastDrawX = -1;

        /// <summary>
        /// Y coordinate of the last drawing point on image.
        /// </summary>
        int _lastDrawY = -1;

        /// <summary>
        /// X coordinate of the last mouse moved point on image.
        /// </summary>
        int _lastMoveX = -1;

        /// <summary>
        /// Y coordinate of the last mouse moved point on image.
        /// </summary>
        int _lastMoveY = -1;

        /// <summary>
        /// Drawing color of the left mouse button.
        /// </summary>
        ColorBase _leftColor = new Argb32Color(0, 0, 0);

        /// <summary>
        /// Drawing color of the right mouse button.
        /// </summary>
        ColorBase _rightColor;

        /// <summary>
        /// A value indicating whether the left color is transparent.
        /// </summary>
        bool _isLeftColorTransparent;

        /// <summary>
        /// A value indicating whether the right color is transparent.
        /// </summary>
        bool _isRightColorTransparent = true;

        /// <summary>
        /// The black white palette.
        /// </summary>
        static Palette _blackWhitePalette = Palette.CreateBlackWhitePalette();

        /// <summary>
        /// Transparent color for drawing on the current mask.
        /// </summary>
        static IndexedColor _transparentMaskColor = new IndexedColor(_blackWhitePalette, 1);

        /// <summary>
        /// Non-transparent color for drawing on the current mask.
        /// </summary>
        static IndexedColor _opaqueMaskColor = new IndexedColor(_blackWhitePalette, 0);

        /// <summary>
        /// Transparent color for drawing on image in the image viewer.
        /// </summary>
        static Argb32Color _transparentColor = new Argb32Color(0, new Rgb24Color(255, 255, 255));

        /// <summary>
        /// The background image.
        /// </summary>
        Image _backgroundImage;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            UpdateFormTitle("(Untitled)");

            _sourceImages = new Dictionary<VintasoftImage, VintasoftImage>();
            _maskImages = new Dictionary<VintasoftImage, VintasoftImage>();
            _isImageChanged = new Dictionary<VintasoftImage, bool>();
            _pageIndexes = new Dictionary<VintasoftImage, int>();

            thumbnailViewer1.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(thumbnailViewer1_Images_ImageCollectionChanged);
            UpdateUI();

            _backgroundImage = Image.FromStream(DemosResourcesManager.GetResourceAsStream("background.png"));
            imageViewer1.BackgroundImage = _backgroundImage;

            // set the initial directory in open file dialog
            DemosTools.SetTestFilesFolder(openIcoFileDialog);
        }

        #endregion



        #region Properties

        bool _isIconFileLoading = false;
        /// <summary>
        /// Gets or sets a value indicating whether icon file is loading.
        /// </summary>
        internal bool IsIconFileLoading
        {
            get
            {
                return _isIconFileLoading;
            }
            set
            {
                _isIconFileLoading = value;
                UpdateUI();
            }
        }

        bool _isIconFileSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether icon file is saving.
        /// </summary>
        internal bool IsIconFileSaving
        {
            get
            {
                return _isIconFileSaving;
            }
            set
            {
                _isIconFileSaving = value;
                UpdateUI();
            }
        }

        bool _isIconFileChanging = false;
        /// <summary>
        /// Gets or sets a value indicating whether icon file is changing.
        /// </summary>
        internal bool IsIconFileChanging
        {
            get
            {
                return _isIconFileChanging;
            }
            set
            {
                if (value)
                    Cursor = Cursors.WaitCursor;
                else
                    Cursor = Cursors.Default;

                _isIconFileChanging = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        #region 'File' menu

        /// <summary>
        /// Handles the Click event of NewToolStripMenuItem object.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsIconFileLoading = true;

            // create new file
            NewFile();

            IsIconFileLoading = false;
        }

        /// <summary>
        /// Handles the Click event of OpenToolStripMenuItem object.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openIcoFileDialog.Multiselect = false;
            if (openIcoFileDialog.ShowDialog() == DialogResult.OK)
            {
                IsIconFileLoading = true;

                // open existing file
                OpenFile(openIcoFileDialog.FileName);

                IsIconFileLoading = false;
            }
        }

        /// <summary>
        /// Handles the Click event of AddPageToolStripMenuItem object.
        /// </summary>
        private void addPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsIconFileLoading = true;

            using (InsertPageForm insertPageForm = new InsertPageForm(false, _iconFile.Pages.Count))
            {
                DialogResult result = insertPageForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    VintasoftImage addingImage = insertPageForm.Image;
                    VintasoftImage maskImage = insertPageForm.MaskImage;
                    int index = insertPageForm.InsertIndex;

                    // add page to icon file
                    _iconFile.Pages.Insert(index, addingImage, maskImage, IconCompression.Bmp);
                    addingImage.Dispose();
                    if (maskImage != null)
                        maskImage.Dispose();

                    // add page to thumbnail viewer
                    InsertPage(index);
                    thumbnailViewer1.FocusedIndex = index;
                }
            }

            IsIconFileLoading = false;
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of SaveToolStripMenuItem object.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if current file is virtual
            if (_isVirtual)
            {
                // call handler of "File => Save as" menu
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            IsIconFileSaving = true;

            try
            {
                UpdateChangedPagesInCurrentFile();

                // save changes in current file
                _iconFile.SaveChanges();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            IsIconFileSaving = false;
        }

        /// <summary>
        /// Handles the Click event of SaveAsToolStripMenuItem object.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsIconFileSaving = true;

            try
            {
                saveIcoFileDialog.Filter = GetSaveDialogFilter();
                if (saveIcoFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // save current file to specified file and switch to the new source
                    Save(saveIcoFileDialog.FileName, true);
                    // update form title
                    UpdateFormTitle(Path.GetFileName(saveIcoFileDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            IsIconFileSaving = false;
        }

        /// <summary>
        /// Handles the Click event of SaveToToolStripMenuItem object.
        /// </summary>
        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsIconFileSaving = true;

            try
            {
                saveIcoFileDialog.Filter = GetSaveDialogFilter();
                if (saveIcoFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // save current file to specified file without switching to the new source
                    Save(saveIcoFileDialog.FileName, false);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            IsIconFileSaving = false;
        }

        /// <summary>
        /// Handles the Click event of CloseToolStripMenuItem object.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close file
            CloseFile();
        }

        /// <summary>
        /// Handles the Click event of ExitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close file
            CloseFile();
            // exit application
            Close();
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Handles the Click event of ThumbnailViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ThumbnailViewerSettingsForm dlg = new ThumbnailViewerSettingsForm(thumbnailViewer1))
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of ImageViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageViewerSettingsForm dlg = new ImageViewerSettingsForm(imageViewer1))
            {
                dlg.CanEditMultipageSettings = false;
                dlg.ShowDialog();
            }
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of AboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.TopMost = TopMost;
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Image Viewer

        /// <summary>
        /// Handles the MouseDown event of ImageViewer1 object.
        /// </summary>
        private void imageViewer1_MouseDown(object sender, MouseEventArgs e)
        {
            PerformMouseMoveAndPageDrawing(e);
        }

        /// <summary>
        /// Handles the MouseMove event of ImageViewer1 object.
        /// </summary>
        private void imageViewer1_MouseMove(object sender, MouseEventArgs e)
        {
            PerformMouseMoveAndPageDrawing(e);
        }

        /// <summary>
        /// Handles the MouseUp event of ImageViewer1 object.
        /// </summary>
        private void imageViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateFocusedImageThumbnailAfterMouseEvent();
        }

        /// <summary>
        /// Handles the MouseLeave event of ImageViewer1 object.
        /// </summary>
        private void imageViewer1_MouseLeave(object sender, EventArgs e)
        {
            // clear current mouse coordinates
            UpdateCursorCoordinates("");
        }

        #endregion


        #region Thumbnail Viewer

        /// <summary>
        /// Handles the ImageCollectionChanged event of Images property of ThumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            ImageCollection images = thumbnailViewer1.Images;
            // get changed images
            VintasoftImage[] changedImages = e.Images;
            switch (e.Action)
            {
                case ImageCollectionChangeAction.SwapImages:
                case ImageCollectionChangeAction.Reorder:
                    // change images order

                    for (int i = 0; i < changedImages.Length; i++)
                    {
                        VintasoftImage changedImage = changedImages[i];
                        int indexOfImage = images.IndexOf(changedImage);
                        int pageIndex = _pageIndexes[changedImage];

                        // if the indexes do not match
                        if (indexOfImage != pageIndex)
                        {
                            // find the index corresponding to the image
                            for (int j = 0; j < images.Count; j++)
                            {
                                if (_pageIndexes[images[j]] == indexOfImage)
                                {
                                    _pageIndexes[images[j]] = pageIndex;
                                    break;
                                }
                            }
                            _pageIndexes[changedImage] = indexOfImage;
                            SwapPages(indexOfImage, pageIndex);
                        }
                    }
                    UpdateUI();
                    break;

                case ImageCollectionChangeAction.RemoveImages:
                    // remove pages

                    for (int i = 0; i < changedImages.Length; i++)
                    {
                        int index = _pageIndexes[changedImages[i]];
                        RemovePage(index, changedImages[i]);
                    }
                    UpdateUI();
                    break;
            }
        }

        /// <summary>
        /// Handles the FocusedIndexChanged event of ThumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            int newPageIndex = e.FocusedIndex;
            if (newPageIndex < 0)
                return;

            ChangeCurrentPage(newPageIndex);
        }

        /// <summary>
        /// Handles the ThumbnailPainting event of ThumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_ThumbnailPainting(object sender, ThumbnailPaintEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;

                // create graphics
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                // calculate image size
                VintasoftImage image = e.ThumbnailImage;
                Size thumbnailRectSize = GetThumbnailSize();
                int imageRectWidth = thumbnailRectSize.Width;
                int imageRectHeight = thumbnailRectSize.Height;
                int imageWidth = image.Width;
                int imageHeight = image.Height;
                int thumbnailWidth = (int)g.VisibleClipBounds.Width;
                int thumbnailHeight = (int)g.VisibleClipBounds.Height;
                int textWidth = imageRectWidth;
                int textHeight = thumbnailHeight - imageRectHeight;

                // draw thumbnail
                Rectangle rect = new Rectangle(
                    (thumbnailWidth - imageWidth) / 2,
                    (thumbnailRectSize.Height - imageHeight) / 2,
                    imageWidth,
                    imageHeight);
                image.Draw(g, rect, new Rectangle(0, 0, imageWidth, imageHeight));

                int thumbnailIndex = e.ThumbnailIndex;
                int pageIndex = _pageIndexes[thumbnailViewer1.Images[thumbnailIndex]];
                IconPage page = _iconFile.Pages[pageIndex];
                string text = string.Format("{0}x{1}, {2} bpp", page.Width, page.Height, page.BitsPerPixel);

                // draw text
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                RectangleF textRect = new RectangleF(0, imageRectHeight + 3, textWidth, textHeight - 6);
                g.DrawString(text, Font, new SolidBrush(ForeColor), textRect, format);
            }
        }

        #endregion


        #region Drawing

        /// <summary>
        /// Handles the DoubleClick event of LeftColorPanel object.
        /// </summary>
        private void leftColorPanel_DoubleClick(object sender, EventArgs e)
        {
            // select drawing color for the left mouse button
            SelectDrawingColor(ref _leftColor, ref _isLeftColorTransparent);
        }

        /// <summary>
        /// Handles the DoubleClick event of RightColorPanel object.
        /// </summary>
        private void rightColorPanel_DoubleClick(object sender, EventArgs e)
        {
            // select drawing color for the right mouse button
            SelectDrawingColor(ref _rightColor, ref _isRightColorTransparent);
        }

        /// <summary>
        /// Handles the Click event of SwapColorsButton object.
        /// </summary>
        private void swapColorsButton_Click(object sender, EventArgs e)
        {
            // swap colors of drawing with 
            // left and right mouse buttons
            ColorBase foreColor = _leftColor;
            _leftColor = _rightColor;
            _rightColor = foreColor;

            bool isForeColorTransparent = _isLeftColorTransparent;
            _isLeftColorTransparent = _isRightColorTransparent;
            _isRightColorTransparent = isForeColorTransparent;

            UpdateColorPanels();
        }

        /// <summary>
        /// Handles the Click event of SetLeftColorTransparentButton object.
        /// </summary>
        private void setLeftColorTransparentButton_Click(object sender, EventArgs e)
        {
            // set left mouse button drawing color to the transparent color
            _isLeftColorTransparent = true;
            UpdateColorPanels();
        }

        /// <summary>
        /// Handles the Click event of SetRightColorTransparentButton object.
        /// </summary>
        private void setRightColorTransparentButton_Click(object sender, EventArgs e)
        {
            // set right mouse button drawing color to the transparent color
            _isRightColorTransparent = true;
            UpdateColorPanels();
        }

        #endregion


        #region Cursor icon

        /// <summary>
        /// Handles the ValueChanged event of HotspotXNumericUpDown object.
        /// </summary>
        private void hotspotXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_isHotspotValuesAreChanging)
                return;

            // update coordinates of current page hotspot

            IconPage currentPage = _iconFile.Pages[_currentPageIndex];
            int hotspotX = Math.Min(currentPage.Width - 1, (int)hotspotXNumericUpDown.Value);
            int hotspotY = Math.Min(currentPage.Height - 1, (int)hotspotYNumericUpDown.Value);
            currentPage.SetHotspotForCursor(hotspotX, hotspotY);
        }

        /// <summary>
        /// Handles the ValueChanged event of HotspotYNumericUpDown object.
        /// </summary>
        private void hotspotYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update coordinates of current page hotspot

            IconPage currentPage = _iconFile.Pages[_currentPageIndex];
            int hotspotX = Math.Min(currentPage.Width - 1, (int)hotspotXNumericUpDown.Value);
            int hotspotY = Math.Min(currentPage.Height - 1, (int)hotspotYNumericUpDown.Value);
            currentPage.SetHotspotForCursor(hotspotX, hotspotY);
        }

        #endregion


        #region Palette

        /// <summary>
        /// Handles the PaletteChanged event of PagePaletteViewer object.
        /// </summary>
        private void pagePaletteViewer_PaletteChanged(object sender, EventArgs e)
        {
            UpdateImageInViewer();
            UpdateFocusedImageThumbnail();
        }

        /// <summary>
        /// Handles the MouseClick event of PagePaletteViewer object.
        /// </summary>
        private void pagePaletteViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (pagePaletteViewer.Palette.ColorCount > 0 &&
                (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                int selectedColorIndex = pagePaletteViewer.GetColorIndex(e.Location);
                if (selectedColorIndex != -1)
                {
                    // get selected color
                    IndexedColor indexedColor = new IndexedColor(pagePaletteViewer.Palette, (byte)selectedColorIndex);

                    if (e.Button == MouseButtons.Left)
                    {
                        // set selected color to left mouse button
                        _leftColor = indexedColor;
                        _isLeftColorTransparent = false;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        // set selected color to right mouse button
                        _rightColor = indexedColor;
                        _isRightColorTransparent = false;
                    }
                    UpdateColorPanels();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeSelectedColorButton object.
        /// </summary>
        private void changeSelectedColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = pagePaletteViewer.SelectedColor;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // set new color
                    pagePaletteViewer.Palette.SetColor(pagePaletteViewer.SelectedColorIndex, dialog.Color.ToArgb());
                    UpdateColorPanels();
                }
            }
        }

        #endregion


        #region Viewer Tool Strip

        /// <summary>
        /// Handles the PageIndexChanged event of ViewerToolStrip object.
        /// </summary>
        private void viewerToolStrip_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            if (_iconFile != null && !IsIconFileChanging)
            {
                // change focused page in thumbnail viewer
                thumbnailViewer1.FocusedIndex = e.SelectedPageIndex;
            }
        }

        #endregion

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isIconFileLoaded = _iconFile != null;
            bool isIconFileEmpty = !isIconFileLoaded || _iconFile.Pages.Count == 0;
            bool isPageImageLoaded = imageViewer1.Image != null;
            bool isPaletteImage = pagePaletteViewer.Palette != null && pagePaletteViewer.Palette.ColorCount > 0;

            // file
            addPagesToolStripMenuItem.Enabled = isIconFileLoaded;
            saveToolStripMenuItem.Enabled = isIconFileLoaded && !isIconFileEmpty;
            saveAsToolStripMenuItem.Enabled = isIconFileLoaded && !isIconFileEmpty;
            saveToToolStripMenuItem.Enabled = isIconFileLoaded && !isIconFileEmpty;
            closeToolStripMenuItem.Enabled = isIconFileLoaded;

            // viewerToolStrip
            if (isIconFileLoaded)
            {
                viewerToolStrip.PageCount = thumbnailViewer1.Images.Count;
                viewerToolStrip.SelectedPageIndex = _currentPageIndex;
            }
            else
            {
                viewerToolStrip.SelectedPageIndex = 0;
                viewerToolStrip.PageCount = 0;
            }
            viewerToolStrip.SaveButtonEnabled = isIconFileLoaded && !isIconFileEmpty;

            changeSelectedColorButton.Enabled = isPageImageLoaded && isPaletteImage;

            // drawing instruments
            UpdateColorPanels();
            swapColorsButton.Enabled = isPageImageLoaded;
            hotspotGroupBox.Visible = isIconFileLoaded && _isCursor;
            if (!isIconFileLoaded || isIconFileEmpty)
            {
                UpdatePaletteInViewer(new Palette());
            }

            UpdateCursorCoordinates("");
            UpdatePageInfo();
        }

        /// <summary>
        /// Updates the page info in the toolstrip status label.
        /// </summary>
        private void UpdatePageInfo()
        {
            if (_iconFile != null && _iconFile.Pages.Count > 0)
            {
                IconPage currentPage = _iconFile.Pages[_currentPageIndex];
                imageInfoLabel.Text = string.Format("Width={0}, Height={1}; BitsPerPixel={2}; Resolution={3}",
                    currentPage.Width, currentPage.Height, currentPage.BitsPerPixel, currentPage.Resolution);

                // if current file is a cursor file
                if (_isCursor)
                {
                    _isHotspotValuesAreChanging = true;
                    hotspotXNumericUpDown.Value = (decimal)currentPage.HotspotX;
                    hotspotYNumericUpDown.Value = (decimal)currentPage.HotspotY;
                    _isHotspotValuesAreChanging = false;
                }
            }
            else
            {
                imageInfoLabel.Text = "";
            }
        }

        /// <summary>
        /// Updates the title of the main form.
        /// </summary>
        /// <param name="fileName">Current file name.</param>
        private void UpdateFormTitle(string fileName)
        {
            Text = string.Format("{0} - {1}", _mainFormTitle, fileName);
        }

        /// <summary>
        /// Updates the current page image in viewer.
        /// </summary>
        private void UpdateImageInViewer()
        {
            VintasoftImage currentImage = thumbnailViewer1.Images[_currentPageIndex];
            UpdateImageInViewer(_sourceImages[currentImage], _maskImages[currentImage]);
        }

        /// <summary>
        /// Updates the image in viewer.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="maskImage">The mask image.</param>
        private void UpdateImageInViewer(VintasoftImage sourceImage, VintasoftImage maskImage)
        {
            UpdatePageInfo();

            VintasoftImage currentImage = imageViewer1.Image;
            imageViewer1.Image = IconPage.RenderImage(sourceImage, maskImage);
            if (currentImage != null)
                currentImage.Dispose();

            UpdatePaletteInViewer(sourceImage.Palette);

            if (!_isLeftColorTransparent)
            {
                if (sourceImage.Palette.ColorCount > 0)
                {
                    if (_leftColor != null)
                    {
                        _leftColor = new IndexedColor(sourceImage.Palette, _leftColor);
                    }
                    else
                    {
                        _leftColor = new IndexedColor(sourceImage.Palette, 0);
                    }
                }
                else
                {
                    if (_leftColor != null)
                    {
                        _leftColor = _leftColor.ToArgb32Color();
                    }
                    else
                    {
                        _leftColor = new Argb32Color(0, 0, 0);
                    }
                }
            }

            if (!_isRightColorTransparent)
            {
                if (sourceImage.Palette.ColorCount > 0)
                {
                    if (_rightColor != null)
                    {
                        _rightColor = new IndexedColor(sourceImage.Palette, _rightColor);
                    }
                    else
                    {
                        _isRightColorTransparent = true;
                    }
                }
                else
                {
                    if (_rightColor != null)
                    {
                        _rightColor = _rightColor.ToArgb32Color();
                    }
                    else
                    {
                        _isRightColorTransparent = true;
                    }
                }
            }

            UpdateColorPanels();
        }

        /// <summary>
        /// Updates current mouse coordinates and performs drawing on the current page.
        /// </summary>
        private void PerformMouseMoveAndPageDrawing(MouseEventArgs e)
        {
            if (imageViewer1.VisualTool != null || imageViewer1.Image == null)
                return;

            Point imagePoint = imageViewer1.PointToImage(e.Location);
            int x = imagePoint.X;
            int y = imagePoint.Y;

            IconPage currentPage = _iconFile.Pages[_currentPageIndex];
            // if cursor is outside the page
            if (x < 0 || y < 0 || x >= currentPage.Width || y >= currentPage.Height)
            {
                _lastDrawX = -1;
                _lastDrawY = -1;
                _lastMoveX = -1;
                _lastMoveY = -1;
                UpdateCursorCoordinates("");
                return;
            }

            // if cursor position is changed
            if (x != _lastMoveX || y != _lastMoveY)
            {
                _lastMoveX = x;
                _lastMoveY = y;
                UpdateCursorCoordinates(String.Format("X = {0}, Y = {1}", x, y));
            }

            // if last drawing position is changed
            if (x != _lastDrawX || y != _lastDrawY)
            {
                if ((e.Button & (MouseButtons.Left | MouseButtons.Right)) == 0)
                {
                    _lastDrawX = -1;
                    _lastDrawY = -1;
                    return;
                }

                VintasoftImage currentImage = thumbnailViewer1.Images[_currentPageIndex];
                VintasoftImage sourceImage = _sourceImages[currentImage];
                VintasoftImage maskImage = _maskImages[currentImage];

                if ((e.Button & MouseButtons.Left) > 0)
                {
                    if (_isLeftColorTransparent)
                        SetPixelTransparency(maskImage, x, y);
                    else
                        SetPixelColor(sourceImage, maskImage, x, y, _leftColor);
                }
                else
                {
                    if (_isRightColorTransparent)
                        SetPixelTransparency(maskImage, x, y);
                    else
                        SetPixelColor(sourceImage, maskImage, x, y, _rightColor);
                }

                _isImageChanged[currentImage] = true;
                _isDrawing = true;
                _lastDrawX = x;
                _lastDrawY = y;
            }
        }

        /// <summary>
        /// Updates current page thumbnail after drawing.
        /// </summary>
        private void UpdateFocusedImageThumbnailAfterMouseEvent()
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                _lastDrawX = -1;
                _lastDrawY = -1;
                UpdateFocusedImageThumbnail();
            }
        }

        /// <summary>
        /// Updates the thumbnail of focused image.
        /// </summary>
        private void UpdateFocusedImageThumbnail()
        {
            VintasoftImage newThumbnail = GetThumbnailFromImage(imageViewer1.Image);

            thumbnailViewer1.Images[_currentPageIndex].SetImage(newThumbnail);
        }

        /// <summary>
        /// Updates the palette viewer.
        /// </summary>
        /// <param name="palette">The palette with changes.</param>
        private void UpdatePaletteInViewer(Palette palette)
        {
            if (pagePaletteViewer.Palette != palette)
            {
                pagePaletteViewer.Palette.Changed -= new EventHandler(pagePaletteViewer_PaletteChanged);
                pagePaletteViewer.Palette = palette;
                pagePaletteViewer.Palette.Changed += new EventHandler(pagePaletteViewer_PaletteChanged);
            }
        }

        /// <summary>
        /// Updates color panels using the current drawing colors.
        /// </summary>
        private void UpdateColorPanels()
        {
            if (_isLeftColorTransparent)
            {
                leftColorPanel.BackgroundImage = _backgroundImage;
            }
            else
            {
                leftColorPanel.BackgroundImage = null;
                leftColorPanel.BackColor = _leftColor.ToColor();
            }

            if (_isRightColorTransparent)
            {
                rightColorPanel.BackgroundImage = _backgroundImage;
            }
            else
            {
                rightColorPanel.BackgroundImage = null;
                rightColorPanel.BackColor = _rightColor.ToColor();
            }
        }

        /// <summary>
        /// Updates the cursor coordinates label.
        /// </summary>
        /// <param name="coordinates">The string with the cursor coordinates.</param>
        private void UpdateCursorCoordinates(string coordinates)
        {
            cursorCoordinatesLabel.Text = coordinates;
        }

        #endregion


        #region ICO File Manipulation

        /// <summary>
        /// Closes the current Icon file and creates a new file.
        /// </summary>
        private void NewFile()
        {
            using (InsertPageForm insertPageForm = new InsertPageForm(true, 0))
            {
                DialogResult result = insertPageForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CloseFile();

                    _isCursor = insertPageForm.IsCursor;
                    IconType iconType1 = IconType.Icon;
                    if (_isCursor)
                        iconType1 = IconType.Cursor;
                    _iconFile = new IconFile(iconType1);
                    _isVirtual = true;
                    VintasoftImage addingImage = insertPageForm.Image;
                    VintasoftImage maskImage = insertPageForm.MaskImage;

                    _iconFile.Pages.Add(addingImage, maskImage, IconCompression.Bmp);

                    addingImage.Dispose();
                    if (maskImage != null)
                        maskImage.Dispose();

                    LoadPages();
                    UpdateFormTitle(String.Format("(Untitled) [{0}]", iconType1));
                }
            }
        }

        /// <summary>
        /// Opens an existing Icon file.
        /// </summary>
        /// <param name="filename">Icon file name.</param>
        private void OpenFile(string filename)
        {
            CloseFile();
            try
            {
                _iconFile = new IconFile(filename);

                _isCursor = _iconFile.Type == IconType.Cursor;
                _isVirtual = false;

                LoadPages();
            }
            catch (Exception e)
            {
                _iconFile = null;
                DemosTools.ShowErrorMessage(e);
                return;
            }

            UpdateFormTitle(Path.GetFileName(filename));
            UpdateUI();
        }

        /// <summary>
        /// Loads page thumbnails into the thumbnail viewer.
        /// </summary>
        private void LoadPages()
        {
            for (int i = 0; i < _iconFile.Pages.Count; i++)
            {
                VintasoftImage image = GetThumbnailFromImage(_iconFile.Pages[i].GetImage());

                _pageIndexes.Add(image, i);
                _isImageChanged.Add(image, false);

                thumbnailViewer1.Images.Add(image);
            }
        }

        /// <summary>
        /// Inserts a page to the current file.
        /// </summary>
        /// <param name="index">Page index.</param>
        private void InsertPage(int index)
        {
            VintasoftImage image = GetThumbnailFromImage(_iconFile.Pages[index].GetImage());

            thumbnailViewer1.Images.Insert(index, image);

            _pageIndexes.Add(image, index);
            _isImageChanged.Add(image, false);

            List<VintasoftImage> increaseImages = new List<VintasoftImage>();
            foreach (VintasoftImage key in _pageIndexes.Keys)
            {
                if (_pageIndexes[key] > index)
                {
                    increaseImages.Add(key);
                }
            }

            for (int i = 0; i < increaseImages.Count; i++)
            {
                _pageIndexes[increaseImages[i]]++;
            }
            increaseImages.Clear();
        }

        /// <summary>
        /// Removes the specified page from current file.
        /// </summary>
        /// <param name="index">Index of the page to be deleted.</param>
        /// <param name="image">The <see cref="VintasoftImage"/> associated with the page.</param>
        private void RemovePage(int index, VintasoftImage image)
        {
            _iconFile.Pages.RemoveAt(index);
            _pageIndexes.Remove(image);

            List<VintasoftImage> reduceList = new List<VintasoftImage>();
            foreach (VintasoftImage key in _pageIndexes.Keys)
            {
                if (_pageIndexes[key] > index)
                    reduceList.Add(key);
            }

            for (int i = 0; i < reduceList.Count; i++)
            {
                _pageIndexes[reduceList[i]]--;
            }
            reduceList.Clear();

            if (_sourceImages.ContainsKey(image))
                _sourceImages.Remove(image);

            if (_maskImages.ContainsKey(image))
                _maskImages.Remove(image);

            if (_isImageChanged.ContainsKey(image))
                _isImageChanged.Remove(image);

            if (_currentPageIndex >= index)
                _currentPageIndex--;

            if (thumbnailViewer1.FocusedIndex >= 0)
            {
                ChangeCurrentPage(thumbnailViewer1.FocusedIndex);
            }
            else
            {
                ClearCurrentPageInImageViewer();
            }
        }

        /// <summary>
        /// Saves current file.
        /// </summary>
        /// <param name="filename">The name of the file to save to.</param>
        /// <param name="switchToNewSource">A value indicating whether file must be switched to the source after saving.</param>
        private void Save(string filename, bool switchToNewSource)
        {
            try
            {
                UpdateChangedPagesInCurrentFile();

                if (switchToNewSource)
                {
                    _iconFile.SaveChanges(filename);
                    _isVirtual = false;
                }
                else
                    _iconFile.Save(filename);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Updates changed pages in current file.
        /// </summary>
        private void UpdateChangedPagesInCurrentFile()
        {
            IconPageCollection pages = _iconFile.Pages;

            // for each image in thumbnail viewer
            for (int i = 0; i < thumbnailViewer1.Images.Count; i++)
            {
                VintasoftImage currentImage = thumbnailViewer1.Images[i];
                // if image is changed
                if (_isImageChanged[currentImage])
                {
                    int hotspotX = 0;
                    int hotspotY = 0;
                    if (_isCursor)
                    {
                        hotspotX = pages[i].HotspotX;
                        hotspotY = pages[i].HotspotY;
                    }

                    IconCompression compression = pages[i].Compression;
                    // remove page from file
                    pages.RemoveAt(i);
                    // insert page to the file
                    pages.Insert(i, _sourceImages[currentImage], _maskImages[currentImage], compression);

                    if (_isCursor)
                        pages[i].SetHotspotForCursor(hotspotX, hotspotY);

                    _isImageChanged[currentImage] = false;
                }
            }
        }

        /// <summary>
        /// Swaps two pages in the current file.
        /// </summary>
        /// <param name="firstPageIndex">Index of one of the swapping pages.</param>
        /// <param name="secondPageIndex">Index of another page.</param>
        private void SwapPages(int firstPageIndex, int secondPageIndex)
        {
            _iconFile.Pages.Swap(firstPageIndex, secondPageIndex);
        }

        /// <summary>
        /// Changes the current page.
        /// </summary>
        /// <param name="newPageIndex">Index of the page to be set as current.</param>
        private void ChangeCurrentPage(int newPageIndex)
        {
            if (newPageIndex == _currentPageIndex)
                return;

            if (newPageIndex < 0 || newPageIndex >= _iconFile.Pages.Count)
                throw new ArgumentOutOfRangeException("newPageIndex");

            _currentPageIndex = newPageIndex;

            VintasoftImage sourceImage = null;
            VintasoftImage maskImage = null;

            GetSourceAndMaskImages(out sourceImage, out maskImage);

            UpdateImageInViewer(sourceImage, maskImage);
            UpdateUI();
        }

        /// <summary>
        /// Returns the source and the mask images of the current page and
        /// loads them into dictionaries, if necessary.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="maskImage">The mask image.</param>
        private void GetSourceAndMaskImages(out VintasoftImage sourceImage, out VintasoftImage maskImage)
        {
            VintasoftImage currentImage = thumbnailViewer1.Images[_currentPageIndex];
            if (!_sourceImages.ContainsKey(currentImage) || _sourceImages[currentImage] == null)
            {
                IconPage currentPage = _iconFile.Pages[_currentPageIndex];
                sourceImage = currentPage.GetSourceImage(null);

                if (currentPage.HasMaskImage)
                {
                    maskImage = currentPage.GetMaskImage(null);
                }
                else
                {
                    maskImage = new VintasoftImage(sourceImage.Width, sourceImage.Height, PixelFormat.BlackWhite);
                }

                _sourceImages[currentImage] = sourceImage;
                _maskImages[currentImage] = maskImage;
            }
            else
            {
                sourceImage = _sourceImages[currentImage];
                maskImage = _maskImages[currentImage];
            }
        }

        /// <summary>
        /// Disposes the source and mask images loaded in the dictionaries.
        /// </summary>
        private void DisposeSourceAndMaskImages()
        {
            foreach (VintasoftImage keyImage in _sourceImages.Keys)
            {
                _sourceImages[keyImage].Dispose();
            }
            _sourceImages.Clear();

            foreach (VintasoftImage keyImage in _maskImages.Keys)
            {
                _maskImages[keyImage].Dispose();
            }
            _maskImages.Clear();

            _isImageChanged.Clear();
        }

        /// <summary>
        /// Returns saving dialog filter for the current file.
        /// </summary>
        /// <returns>String with saving dialog filter.</returns>
        private string GetSaveDialogFilter()
        {
            if (_isCursor)
                return "Cursor Files (*.cur)|*.cur";
            else
                return "Icon Files (*.ico)|*.ico";
        }

        /// <summary>
        /// Closes the current file.
        /// </summary>
        private void CloseFile()
        {
            UpdateFormTitle("(Untitled)");

            thumbnailViewer1.Images.ClearAndDisposeItems();
            DisposeSourceAndMaskImages();
            _pageIndexes.Clear();

            ClearCurrentPageInImageViewer();
            _currentPageIndex = -1;

            if (_iconFile != null)
            {
                _iconFile.Dispose();
                _iconFile = null;
            }

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Drawing

        /// <summary>
        /// Selects the drawing color for the current palette in the palette viewer.
        /// </summary>
        /// <param name="drawingColor">Drawing color.</param>
        /// <param name="isColorTransparent">Indicates whether the color is transparent.</param>
        private void SelectDrawingColor(ref ColorBase drawingColor, ref bool isColorTransparent)
        {
            if (pagePaletteViewer.Palette.ColorCount > 0)
            {
                using (PaletteForm paletteForm = new PaletteForm())
                {
                    paletteForm.CanChangePalette = false;
                    Palette palette = pagePaletteViewer.Palette;
                    paletteForm.PaletteViewer.Palette = palette;
                    if (paletteForm.ShowDialog() == DialogResult.OK)
                    {
                        drawingColor = new IndexedColor(palette, paletteForm.PaletteViewer.SelectedColorIndex);
                        isColorTransparent = false;

                        UpdateColorPanels();
                    }
                }
            }
            else
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        drawingColor = new Argb32Color(dlg.Color);
                        isColorTransparent = false;

                        UpdateColorPanels();
                    }
                }
            }
        }

        /// <summary>
        /// Sets the transparency of the specified pixel of the specified mask image.
        /// </summary>
        /// <param name="maskImage">The <see cref="VintasoftImage"/> that specifies the mask.</param>
        /// <param name="x">X coordinate of the pixel.</param>
        /// <param name="y">Y coordinate of the pixel.</param>
        private void SetPixelTransparency(VintasoftImage maskImage, int x, int y)
        {
            maskImage.SetPixelColor(x, y, _transparentMaskColor);
            imageViewer1.Image.SetPixelColor(x, y, _transparentColor);

            if (_lastDrawX != -1 && _lastDrawY != -1)
            {
                if (Math.Abs(x - _lastDrawX) > 1 || Math.Abs(y - _lastDrawY) > 1)
                {
                    List<Point> points = GetLinePoints(_lastDrawX, _lastDrawY, x, y);

                    DrawLineOnImage(maskImage, points, _transparentMaskColor);
                    DrawLineOnImage(imageViewer1.Image, points, _transparentColor);

                    points.Clear();
                }
            }
        }

        /// <summary>
        /// Sets the color of the specified pixel of the specified image.
        /// </summary>
        /// <param name="sourceImage">The <see cref="VintasoftImage"/> that is a source image.</param>
        /// <param name="maskImage">The <see cref="VintasoftImage"/> that specifies the mask.</param>
        /// <param name="pixelColor">New pixel color.</param>
        /// <param name="x">X coordinate of the pixel.</param>
        /// <param name="y">Y coordinate of the pixel.</param>
        private void SetPixelColor(VintasoftImage sourceImage, VintasoftImage maskImage, int x, int y, ColorBase pixelColor)
        {
            maskImage.SetPixelColor(x, y, _opaqueMaskColor);
            sourceImage.SetPixelColor(x, y, pixelColor);
            imageViewer1.Image.SetPixelColor(x, y, pixelColor);

            if (_lastDrawX != -1 && _lastDrawY != -1)
            {
                if (Math.Abs(x - _lastDrawX) > 1 || Math.Abs(y - _lastDrawY) > 1)
                {
                    List<Point> points = GetLinePoints(_lastDrawX, _lastDrawY, x, y);

                    DrawLineOnImage(maskImage, points, _opaqueMaskColor);
                    DrawLineOnImage(sourceImage, points, pixelColor);
                    DrawLineOnImage(imageViewer1.Image, points, pixelColor);

                    points.Clear();
                }
            }
        }

        /// <summary>
        /// Draws the line on a specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="points">Line points list.</param>
        /// <param name="color">Line color.</param>
        private void DrawLineOnImage(VintasoftImage image, List<Point> points, ColorBase color)
        {
            PixelManipulator pixelManipulator = image.OpenPixelManipulator();
            pixelManipulator.LockPixels(new Rectangle(0, 0, image.Width, image.Height), BitmapLockMode.Write);

            for (int i = 0; i < points.Count; i++)
            {
                pixelManipulator.SetPixelColor(points[i].X, points[i].Y, color);
            }

            pixelManipulator.UnlockPixels();
            image.ClosePixelManipulator(true);
        }

        /// <summary>
        /// Returns a list of points which lie on a line between specified points.
        /// </summary>
        /// <param name="x1">X coordinate of the first point.</param>
        /// <param name="y1">Y coordinate of the first point.</param>
        /// <param name="x2">X coordinate of the second point.</param>
        /// <param name="y2">Y coordinate of the second point.</param>
        /// <returns>List of points.</returns>
        private List<Point> GetLinePoints(int x1, int y1, int x2, int y2)
        {
            List<Point> result = new List<Point>();
            double k;
            double b;
            int temp;
            if (y1 == y2)
            {
                if (x1 > x2)
                {
                    temp = x1;
                    x1 = x2;
                    x2 = temp;
                }

                for (int x = x1 + 1; x < x2; x++)
                {
                    result.Add(new Point(x, y1));
                }
            }
            else if (x1 == x2)
            {
                if (y1 > y2)
                {
                    temp = y1;
                    y1 = y2;
                    y2 = temp;
                }

                for (int y = y1 + 1; y < y2; y++)
                {
                    result.Add(new Point(x1, y));
                }
            }
            else if (Math.Abs(x1 - x2) >= Math.Abs(y1 - y2))
            {
                k = (double)(y2 - y1) / (double)(x2 - x1);
                b = y1 - k * x1;

                if (x1 > x2)
                {
                    temp = x1;
                    x1 = x2;
                    x2 = temp;
                }

                for (int x = x1 + 1; x < x2; x++)
                {
                    result.Add(new Point(x, (int)Math.Round(k * x + b)));
                }
            }
            else
            {
                k = (double)(x2 - x1) / (double)(y2 - y1);
                b = x1 - k * y1;

                if (y1 > y2)
                {
                    temp = y1;
                    y1 = y2;
                    y2 = temp;
                }

                for (int y = y1 + 1; y < y2; y++)
                {
                    result.Add(new Point((int)Math.Round(k * y + b), y));
                }
            }

            return result;
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Clears the current page in image viewer.
        /// </summary>
        private void ClearCurrentPageInImageViewer()
        {
            VintasoftImage currentImage = imageViewer1.Image;

            imageViewer1.Image = null;

            if (currentImage != null)
                currentImage.Dispose();
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Returns the thumbnail size.
        /// </summary>
        /// <returns>Thumbnail size.</returns>
        private Size GetThumbnailSize()
        {
            int width = thumbnailViewer1.ThumbnailSize.Width;
            int height = (int)(thumbnailViewer1.ThumbnailSize.Height * 0.7) + 1;
            return new Size(width, height);
        }

        /// <summary>
        /// Returns a thumbnail of specified image.
        /// </summary>
        /// <param name="image">The original <see cref="VintasoftImage"/>.</param>
        /// <returns><see cref="VintasoftImage"/> that is an image thumbnail.</returns>
        private VintasoftImage GetThumbnailFromImage(VintasoftImage image)
        {
            Size size = GetThumbnailSize();
            return image.GetThumbnail(size);
        }

        #endregion

        #endregion

    }
}
