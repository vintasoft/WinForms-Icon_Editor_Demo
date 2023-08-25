namespace IconEditorDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.Palette palette1 = new Vintasoft.Imaging.Palette();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIcoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cursorCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.thumbnailViewer1 = new Vintasoft.Imaging.UI.ThumbnailViewer();
            this.imageViewer1 = new Vintasoft.Imaging.UI.ImageViewer();
            this.changeSelectedColorButton = new System.Windows.Forms.Button();
            this.hotspotGroupBox = new System.Windows.Forms.GroupBox();
            this.hotspotYLabel = new System.Windows.Forms.Label();
            this.hotspotXLabel = new System.Windows.Forms.Label();
            this.hotspotYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hotspotXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.paletteEditorGroupBox = new System.Windows.Forms.GroupBox();
            this.pagePaletteViewer = new Vintasoft.Imaging.UI.PaletteViewer();
            this.setRightColorTransparentButton = new System.Windows.Forms.Button();
            this.setLeftColorTransparentButton = new System.Windows.Forms.Button();
            this.leftColorPanel = new System.Windows.Forms.Panel();
            this.rightColorPanel = new System.Windows.Forms.Panel();
            this.swapColorsButton = new System.Windows.Forms.Button();
            this.saveIcoFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.viewerToolStrip = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.mainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.hotspotGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hotspotYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotspotXNumericUpDown)).BeginInit();
            this.paletteEditorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(978, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.addPagesToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveToToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // addPagesToolStripMenuItem
            // 
            this.addPagesToolStripMenuItem.Name = "addPagesToolStripMenuItem";
            this.addPagesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addPagesToolStripMenuItem.Text = "Add Page...";
            this.addPagesToolStripMenuItem.Click += new System.EventHandler(this.addPageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToToolStripMenuItem
            // 
            this.saveToToolStripMenuItem.Name = "saveToToolStripMenuItem";
            this.saveToToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveToToolStripMenuItem.Text = "Save To...";
            this.saveToToolStripMenuItem.Click += new System.EventHandler(this.saveToToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thumbnailViewerSettingsToolStripMenuItem,
            this.imageViewerSettingsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // thumbnailViewerSettingsToolStripMenuItem
            // 
            this.thumbnailViewerSettingsToolStripMenuItem.Name = "thumbnailViewerSettingsToolStripMenuItem";
            this.thumbnailViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.thumbnailViewerSettingsToolStripMenuItem.Text = "Thumbnail Viewer Settings...";
            this.thumbnailViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.thumbnailViewerSettingsToolStripMenuItem_Click);
            // 
            // imageViewerSettingsToolStripMenuItem
            // 
            this.imageViewerSettingsToolStripMenuItem.Name = "imageViewerSettingsToolStripMenuItem";
            this.imageViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.imageViewerSettingsToolStripMenuItem.Text = "Image Viewer Settings...";
            this.imageViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.imageViewerSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openIcoFileDialog
            // 
            this.openIcoFileDialog.Filter = "Icon and Cursor Files|*ico;*.cur|Icon Files (*.ico)|*.ico|Cursor Files (*.cur)|*." +
    "cur";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursorCoordinatesLabel,
            this.imageInfoLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cursorCoordinatesLabel
            // 
            this.cursorCoordinatesLabel.Name = "cursorCoordinatesLabel";
            this.cursorCoordinatesLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // imageInfoLabel
            // 
            this.imageInfoLabel.Name = "imageInfoLabel";
            this.imageInfoLabel.Size = new System.Drawing.Size(963, 17);
            this.imageInfoLabel.Spring = true;
            this.imageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.changeSelectedColorButton);
            this.splitContainer1.Panel2.Controls.Add(this.hotspotGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.paletteEditorGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.setRightColorTransparentButton);
            this.splitContainer1.Panel2.Controls.Add(this.setLeftColorTransparentButton);
            this.splitContainer1.Panel2.Controls.Add(this.leftColorPanel);
            this.splitContainer1.Panel2.Controls.Add(this.rightColorPanel);
            this.splitContainer1.Panel2.Controls.Add(this.swapColorsButton);
            this.splitContainer1.Size = new System.Drawing.Size(978, 541);
            this.splitContainer1.SplitterDistance = 649;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.thumbnailViewer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.imageViewer1);
            this.splitContainer2.Size = new System.Drawing.Size(649, 541);
            this.splitContainer2.SplitterDistance = 215;
            this.splitContainer2.TabIndex = 5;
            // 
            // thumbnailViewer1
            // 
            this.thumbnailViewer1.AllowDrop = true;
            this.thumbnailViewer1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.thumbnailViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnailViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance1.BorderWidth = 1;
            this.thumbnailViewer1.FocusedThumbnailAppearance = thumbnailAppearance1;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.thumbnailViewer1.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.thumbnailViewer1.Location = new System.Drawing.Point(0, 0);
            this.thumbnailViewer1.Name = "thumbnailViewer1";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.thumbnailViewer1.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.thumbnailViewer1.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.thumbnailViewer1.Size = new System.Drawing.Size(215, 541);
            this.thumbnailViewer1.TabIndex = 0;
            this.thumbnailViewer1.Text = "thumbnailViewer1";
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.thumbnailViewer1.ThumbnailAppearance = thumbnailAppearance5;
            this.thumbnailViewer1.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.thumbnailViewer1.ThumbnailSize = new System.Drawing.Size(100, 100);
            this.thumbnailViewer1.ThumbnailPainting += new System.EventHandler<Vintasoft.Imaging.UI.ThumbnailPaintEventArgs>(this.thumbnailViewer1_ThumbnailPainting);
            this.thumbnailViewer1.FocusedIndexChanged += new System.EventHandler<Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs>(this.thumbnailViewer1_FocusedIndexChanged);
            // 
            // imageViewer1
            // 
            this.imageViewer1.AutoScroll = true;
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.Location = new System.Drawing.Point(0, 0);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.RenderingQuality = Vintasoft.Imaging.ImageRenderingQuality.Low;
            this.imageViewer1.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.Size = new System.Drawing.Size(430, 541);
            this.imageViewer1.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.Text = "imageViewer1";
            this.imageViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseDown);
            this.imageViewer1.MouseLeave += new System.EventHandler(this.imageViewer1_MouseLeave);
            this.imageViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseMove);
            this.imageViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseUp);
            // 
            // changeSelectedColorButton
            // 
            this.changeSelectedColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeSelectedColorButton.Location = new System.Drawing.Point(176, 201);
            this.changeSelectedColorButton.Name = "changeSelectedColorButton";
            this.changeSelectedColorButton.Size = new System.Drawing.Size(137, 23);
            this.changeSelectedColorButton.TabIndex = 9;
            this.changeSelectedColorButton.Text = "Change Selected Color";
            this.changeSelectedColorButton.UseVisualStyleBackColor = true;
            this.changeSelectedColorButton.Click += new System.EventHandler(this.changeSelectedColorButton_Click);
            // 
            // hotspotGroupBox
            // 
            this.hotspotGroupBox.Controls.Add(this.hotspotYLabel);
            this.hotspotGroupBox.Controls.Add(this.hotspotXLabel);
            this.hotspotGroupBox.Controls.Add(this.hotspotYNumericUpDown);
            this.hotspotGroupBox.Controls.Add(this.hotspotXNumericUpDown);
            this.hotspotGroupBox.Location = new System.Drawing.Point(12, 141);
            this.hotspotGroupBox.Name = "hotspotGroupBox";
            this.hotspotGroupBox.Size = new System.Drawing.Size(296, 54);
            this.hotspotGroupBox.TabIndex = 8;
            this.hotspotGroupBox.TabStop = false;
            this.hotspotGroupBox.Text = "Hotspot";
            // 
            // hotspotYLabel
            // 
            this.hotspotYLabel.AutoSize = true;
            this.hotspotYLabel.Location = new System.Drawing.Point(143, 23);
            this.hotspotYLabel.Name = "hotspotYLabel";
            this.hotspotYLabel.Size = new System.Drawing.Size(26, 13);
            this.hotspotYLabel.TabIndex = 3;
            this.hotspotYLabel.Text = "Y = ";
            // 
            // hotspotXLabel
            // 
            this.hotspotXLabel.AutoSize = true;
            this.hotspotXLabel.Location = new System.Drawing.Point(12, 23);
            this.hotspotXLabel.Name = "hotspotXLabel";
            this.hotspotXLabel.Size = new System.Drawing.Size(26, 13);
            this.hotspotXLabel.TabIndex = 2;
            this.hotspotXLabel.Text = "X = ";
            // 
            // hotspotYNumericUpDown
            // 
            this.hotspotYNumericUpDown.Location = new System.Drawing.Point(175, 21);
            this.hotspotYNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hotspotYNumericUpDown.Name = "hotspotYNumericUpDown";
            this.hotspotYNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.hotspotYNumericUpDown.TabIndex = 1;
            this.hotspotYNumericUpDown.ValueChanged += new System.EventHandler(this.hotspotYNumericUpDown_ValueChanged);
            // 
            // hotspotXNumericUpDown
            // 
            this.hotspotXNumericUpDown.Location = new System.Drawing.Point(44, 21);
            this.hotspotXNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hotspotXNumericUpDown.Name = "hotspotXNumericUpDown";
            this.hotspotXNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.hotspotXNumericUpDown.TabIndex = 0;
            this.hotspotXNumericUpDown.ValueChanged += new System.EventHandler(this.hotspotXNumericUpDown_ValueChanged);
            // 
            // paletteEditorGroupBox
            // 
            this.paletteEditorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.paletteEditorGroupBox.Controls.Add(this.pagePaletteViewer);
            this.paletteEditorGroupBox.Location = new System.Drawing.Point(12, 224);
            this.paletteEditorGroupBox.Name = "paletteEditorGroupBox";
            this.paletteEditorGroupBox.Size = new System.Drawing.Size(301, 314);
            this.paletteEditorGroupBox.TabIndex = 7;
            this.paletteEditorGroupBox.TabStop = false;
            this.paletteEditorGroupBox.Text = "Palette Editor";
            // 
            // pagePaletteViewer
            // 
            this.pagePaletteViewer.CanChangePalette = false;
            this.pagePaletteViewer.CellPadding = 2;
            this.pagePaletteViewer.CellSize = 16;
            this.pagePaletteViewer.EmptyCellColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.pagePaletteViewer.Location = new System.Drawing.Point(6, 19);
            this.pagePaletteViewer.Name = "pagePaletteViewer";
            this.pagePaletteViewer.Palette = palette1;
            this.pagePaletteViewer.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.pagePaletteViewer.SelectedColorIndex = ((byte)(0));
            this.pagePaletteViewer.SelectionColor = System.Drawing.Color.Lime;
            this.pagePaletteViewer.Size = new System.Drawing.Size(290, 290);
            this.pagePaletteViewer.TabIndex = 0;
            this.pagePaletteViewer.Text = "paletteViewer1";
            this.pagePaletteViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pagePaletteViewer_MouseClick);
            // 
            // setRightColorTransparentButton
            // 
            this.setRightColorTransparentButton.Location = new System.Drawing.Point(105, 65);
            this.setRightColorTransparentButton.Name = "setRightColorTransparentButton";
            this.setRightColorTransparentButton.Size = new System.Drawing.Size(203, 35);
            this.setRightColorTransparentButton.TabIndex = 6;
            this.setRightColorTransparentButton.Text = "Set right mouse button color to transparent";
            this.setRightColorTransparentButton.UseVisualStyleBackColor = true;
            this.setRightColorTransparentButton.Click += new System.EventHandler(this.setRightColorTransparentButton_Click);
            // 
            // setLeftColorTransparentButton
            // 
            this.setLeftColorTransparentButton.Location = new System.Drawing.Point(105, 20);
            this.setLeftColorTransparentButton.Name = "setLeftColorTransparentButton";
            this.setLeftColorTransparentButton.Size = new System.Drawing.Size(203, 36);
            this.setLeftColorTransparentButton.TabIndex = 5;
            this.setLeftColorTransparentButton.Text = "Set left mouse button color to transparent";
            this.setLeftColorTransparentButton.UseVisualStyleBackColor = true;
            this.setLeftColorTransparentButton.Click += new System.EventHandler(this.setLeftColorTransparentButton_Click);
            // 
            // leftColorPanel
            // 
            this.leftColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftColorPanel.Location = new System.Drawing.Point(22, 20);
            this.leftColorPanel.Name = "leftColorPanel";
            this.leftColorPanel.Size = new System.Drawing.Size(50, 50);
            this.leftColorPanel.TabIndex = 1;
            this.leftColorPanel.DoubleClick += new System.EventHandler(this.leftColorPanel_DoubleClick);
            // 
            // rightColorPanel
            // 
            this.rightColorPanel.BackColor = System.Drawing.SystemColors.Control;
            this.rightColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightColorPanel.Location = new System.Drawing.Point(49, 50);
            this.rightColorPanel.Name = "rightColorPanel";
            this.rightColorPanel.Size = new System.Drawing.Size(50, 50);
            this.rightColorPanel.TabIndex = 2;
            this.rightColorPanel.DoubleClick += new System.EventHandler(this.rightColorPanel_DoubleClick);
            // 
            // swapColorsButton
            // 
            this.swapColorsButton.Location = new System.Drawing.Point(22, 106);
            this.swapColorsButton.Name = "swapColorsButton";
            this.swapColorsButton.Size = new System.Drawing.Size(77, 27);
            this.swapColorsButton.TabIndex = 3;
            this.swapColorsButton.Text = "Swap colors";
            this.swapColorsButton.UseVisualStyleBackColor = true;
            this.swapColorsButton.Click += new System.EventHandler(this.swapColorsButton_Click);
            // 
            // saveIcoFileDialog
            // 
            this.saveIcoFileDialog.Filter = "Icon Files (*.ico)|*.ico|Cursor Files (*.cur)|*.cur";
            // 
            // viewerToolStrip
            // 
            this.viewerToolStrip.AssociatedZoomTrackBar = null;
            this.viewerToolStrip.CanPrint = false;
            this.viewerToolStrip.ImageViewer = this.imageViewer1;
            this.viewerToolStrip.ScanButtonEnabled = true;
            this.viewerToolStrip.Location = new System.Drawing.Point(0, 24);
            this.viewerToolStrip.Name = "viewerToolStrip";
            this.viewerToolStrip.PageCount = 0;
            this.viewerToolStrip.PrintButtonEnabled = false;
            this.viewerToolStrip.SaveButtonEnabled = true;
            this.viewerToolStrip.Size = new System.Drawing.Size(978, 25);
            this.viewerToolStrip.TabIndex = 3;
            this.viewerToolStrip.Text = "imageViewerToolStrip1";
            this.viewerToolStrip.UseImageViewerImages = false;
            this.viewerToolStrip.OpenFile += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.viewerToolStrip.SaveFile += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            this.viewerToolStrip.PageIndexChanged += new System.EventHandler<DemosCommonCode.Imaging.PageIndexChangedEventArgs>(this.viewerToolStrip_PageIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 612);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.viewerToolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(640, 630);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft Icon Editor Demo";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.hotspotGroupBox.ResumeLayout(false);
            this.hotspotGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hotspotYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotspotXNumericUpDown)).EndInit();
            this.paletteEditorGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openIcoFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DemosCommonCode.Imaging.ImageViewerToolStrip viewerToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Vintasoft.Imaging.UI.ThumbnailViewer thumbnailViewer1;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel imageInfoLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thumbnailViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveIcoFileDialog;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Vintasoft.Imaging.UI.PaletteViewer pagePaletteViewer;
        private System.Windows.Forms.Button swapColorsButton;
        private System.Windows.Forms.Panel rightColorPanel;
        private System.Windows.Forms.Panel leftColorPanel;
        private System.Windows.Forms.Button setRightColorTransparentButton;
        private System.Windows.Forms.Button setLeftColorTransparentButton;
        private System.Windows.Forms.GroupBox paletteEditorGroupBox;
        private System.Windows.Forms.GroupBox hotspotGroupBox;
        private System.Windows.Forms.NumericUpDown hotspotYNumericUpDown;
        private System.Windows.Forms.NumericUpDown hotspotXNumericUpDown;
        private System.Windows.Forms.Label hotspotYLabel;
        private System.Windows.Forms.Label hotspotXLabel;
        private System.Windows.Forms.ToolStripStatusLabel cursorCoordinatesLabel;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button changeSelectedColorButton;
    }
}
