namespace IconEditorDemo
{
    partial class InsertPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertPageForm));
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pageFromImageRadioButton = new System.Windows.Forms.RadioButton();
            this.emptyPageRadioButton = new System.Windows.Forms.RadioButton();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.insertIndexLabel = new System.Windows.Forms.Label();
            this.insertIndexNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDepthGroupBox = new System.Windows.Forms.GroupBox();
            this.bpp32RadioButton = new System.Windows.Forms.RadioButton();
            this.bpp24RadioButton = new System.Windows.Forms.RadioButton();
            this.bpp8RadioButton = new System.Windows.Forms.RadioButton();
            this.bpp4RadioButton = new System.Windows.Forms.RadioButton();
            this.bpp1RadioButton = new System.Windows.Forms.RadioButton();
            this.sizeGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customSizeHeightTextBox = new System.Windows.Forms.TextBox();
            this.customSizeWidthTextBox = new System.Windows.Forms.TextBox();
            this.customSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.size256x256RadioButton = new System.Windows.Forms.RadioButton();
            this.size128x128RadioButton = new System.Windows.Forms.RadioButton();
            this.size64x64RadioButton = new System.Windows.Forms.RadioButton();
            this.size48x48RadioButton = new System.Windows.Forms.RadioButton();
            this.size32x32RadioButton = new System.Windows.Forms.RadioButton();
            this.size16x16RadioButton = new System.Windows.Forms.RadioButton();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.cursorRadioButton = new System.Windows.Forms.RadioButton();
            this.iconRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.insertIndexNumericUpDown)).BeginInit();
            this.colorDepthGroupBox.SuspendLayout();
            this.sizeGroupBox.SuspendLayout();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(188, 296);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(269, 296);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pageFromImageRadioButton
            // 
            this.pageFromImageRadioButton.AutoSize = true;
            this.pageFromImageRadioButton.Location = new System.Drawing.Point(9, 16);
            this.pageFromImageRadioButton.Name = "pageFromImageRadioButton";
            this.pageFromImageRadioButton.Size = new System.Drawing.Size(105, 17);
            this.pageFromImageRadioButton.TabIndex = 2;
            this.pageFromImageRadioButton.Text = "Page from Image";
            this.pageFromImageRadioButton.UseVisualStyleBackColor = true;
            this.pageFromImageRadioButton.CheckedChanged += new System.EventHandler(this.pageWithImageRadioButton_CheckedChanged);
            // 
            // emptyPageRadioButton
            // 
            this.emptyPageRadioButton.AutoSize = true;
            this.emptyPageRadioButton.Checked = true;
            this.emptyPageRadioButton.Location = new System.Drawing.Point(9, 43);
            this.emptyPageRadioButton.Name = "emptyPageRadioButton";
            this.emptyPageRadioButton.Size = new System.Drawing.Size(82, 17);
            this.emptyPageRadioButton.TabIndex = 3;
            this.emptyPageRadioButton.TabStop = true;
            this.emptyPageRadioButton.Text = "Empty Page";
            this.emptyPageRadioButton.UseVisualStyleBackColor = true;
            this.emptyPageRadioButton.CheckedChanged += new System.EventHandler(this.emptyPageRadioButton_CheckedChanged);
            // 
            // selectImageButton
            // 
            this.selectImageButton.Enabled = false;
            this.selectImageButton.Location = new System.Drawing.Point(123, 12);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(221, 23);
            this.selectImageButton.TabIndex = 8;
            this.selectImageButton.Text = "Select image...";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // insertIndexLabel
            // 
            this.insertIndexLabel.AutoSize = true;
            this.insertIndexLabel.Location = new System.Drawing.Point(25, 71);
            this.insertIndexLabel.Name = "insertIndexLabel";
            this.insertIndexLabel.Size = new System.Drawing.Size(68, 13);
            this.insertIndexLabel.TabIndex = 11;
            this.insertIndexLabel.Text = "Insert Index: ";
            // 
            // insertIndexNumericUpDown
            // 
            this.insertIndexNumericUpDown.Location = new System.Drawing.Point(124, 69);
            this.insertIndexNumericUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.insertIndexNumericUpDown.Name = "insertIndexNumericUpDown";
            this.insertIndexNumericUpDown.Size = new System.Drawing.Size(108, 20);
            this.insertIndexNumericUpDown.TabIndex = 12;
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = resources.GetString("openImageDialog.Filter");
            this.openImageDialog.FilterIndex = 0;
            // 
            // colorDepthGroupBox
            // 
            this.colorDepthGroupBox.Controls.Add(this.bpp32RadioButton);
            this.colorDepthGroupBox.Controls.Add(this.bpp24RadioButton);
            this.colorDepthGroupBox.Controls.Add(this.bpp8RadioButton);
            this.colorDepthGroupBox.Controls.Add(this.bpp4RadioButton);
            this.colorDepthGroupBox.Controls.Add(this.bpp1RadioButton);
            this.colorDepthGroupBox.Location = new System.Drawing.Point(12, 150);
            this.colorDepthGroupBox.Name = "colorDepthGroupBox";
            this.colorDepthGroupBox.Size = new System.Drawing.Size(104, 135);
            this.colorDepthGroupBox.TabIndex = 21;
            this.colorDepthGroupBox.TabStop = false;
            this.colorDepthGroupBox.Text = "Color depth";
            // 
            // bpp32RadioButton
            // 
            this.bpp32RadioButton.AutoSize = true;
            this.bpp32RadioButton.Location = new System.Drawing.Point(9, 111);
            this.bpp32RadioButton.Name = "bpp32RadioButton";
            this.bpp32RadioButton.Size = new System.Drawing.Size(56, 17);
            this.bpp32RadioButton.TabIndex = 4;
            this.bpp32RadioButton.Text = "32 bits";
            this.bpp32RadioButton.UseVisualStyleBackColor = true;
            // 
            // bpp24RadioButton
            // 
            this.bpp24RadioButton.AutoSize = true;
            this.bpp24RadioButton.Location = new System.Drawing.Point(9, 88);
            this.bpp24RadioButton.Name = "bpp24RadioButton";
            this.bpp24RadioButton.Size = new System.Drawing.Size(56, 17);
            this.bpp24RadioButton.TabIndex = 3;
            this.bpp24RadioButton.Text = "24 bits";
            this.bpp24RadioButton.UseVisualStyleBackColor = true;
            // 
            // bpp8RadioButton
            // 
            this.bpp8RadioButton.AutoSize = true;
            this.bpp8RadioButton.Checked = true;
            this.bpp8RadioButton.Location = new System.Drawing.Point(9, 65);
            this.bpp8RadioButton.Name = "bpp8RadioButton";
            this.bpp8RadioButton.Size = new System.Drawing.Size(50, 17);
            this.bpp8RadioButton.TabIndex = 2;
            this.bpp8RadioButton.TabStop = true;
            this.bpp8RadioButton.Text = "8 bits";
            this.bpp8RadioButton.UseVisualStyleBackColor = true;
            // 
            // bpp4RadioButton
            // 
            this.bpp4RadioButton.AutoSize = true;
            this.bpp4RadioButton.Location = new System.Drawing.Point(9, 42);
            this.bpp4RadioButton.Name = "bpp4RadioButton";
            this.bpp4RadioButton.Size = new System.Drawing.Size(50, 17);
            this.bpp4RadioButton.TabIndex = 1;
            this.bpp4RadioButton.Text = "4 bits";
            this.bpp4RadioButton.UseVisualStyleBackColor = true;
            // 
            // bpp1RadioButton
            // 
            this.bpp1RadioButton.AutoSize = true;
            this.bpp1RadioButton.Location = new System.Drawing.Point(9, 19);
            this.bpp1RadioButton.Name = "bpp1RadioButton";
            this.bpp1RadioButton.Size = new System.Drawing.Size(45, 17);
            this.bpp1RadioButton.TabIndex = 0;
            this.bpp1RadioButton.Text = "1 bit";
            this.bpp1RadioButton.UseVisualStyleBackColor = true;
            // 
            // sizeGroupBox
            // 
            this.sizeGroupBox.Controls.Add(this.label1);
            this.sizeGroupBox.Controls.Add(this.customSizeHeightTextBox);
            this.sizeGroupBox.Controls.Add(this.customSizeWidthTextBox);
            this.sizeGroupBox.Controls.Add(this.customSizeRadioButton);
            this.sizeGroupBox.Controls.Add(this.size256x256RadioButton);
            this.sizeGroupBox.Controls.Add(this.size128x128RadioButton);
            this.sizeGroupBox.Controls.Add(this.size64x64RadioButton);
            this.sizeGroupBox.Controls.Add(this.size48x48RadioButton);
            this.sizeGroupBox.Controls.Add(this.size32x32RadioButton);
            this.sizeGroupBox.Controls.Add(this.size16x16RadioButton);
            this.sizeGroupBox.Location = new System.Drawing.Point(123, 150);
            this.sizeGroupBox.Name = "sizeGroupBox";
            this.sizeGroupBox.Size = new System.Drawing.Size(221, 135);
            this.sizeGroupBox.TabIndex = 22;
            this.sizeGroupBox.TabStop = false;
            this.sizeGroupBox.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "x";
            // 
            // customSizeHeightTextBox
            // 
            this.customSizeHeightTextBox.Enabled = false;
            this.customSizeHeightTextBox.Location = new System.Drawing.Point(160, 95);
            this.customSizeHeightTextBox.Name = "customSizeHeightTextBox";
            this.customSizeHeightTextBox.Size = new System.Drawing.Size(52, 20);
            this.customSizeHeightTextBox.TabIndex = 8;
            // 
            // customSizeWidthTextBox
            // 
            this.customSizeWidthTextBox.Enabled = false;
            this.customSizeWidthTextBox.Location = new System.Drawing.Point(84, 95);
            this.customSizeWidthTextBox.Name = "customSizeWidthTextBox";
            this.customSizeWidthTextBox.Size = new System.Drawing.Size(52, 20);
            this.customSizeWidthTextBox.TabIndex = 7;
            // 
            // customSizeRadioButton
            // 
            this.customSizeRadioButton.AutoSize = true;
            this.customSizeRadioButton.Location = new System.Drawing.Point(9, 98);
            this.customSizeRadioButton.Name = "customSizeRadioButton";
            this.customSizeRadioButton.Size = new System.Drawing.Size(63, 17);
            this.customSizeRadioButton.TabIndex = 6;
            this.customSizeRadioButton.Text = "Custom:";
            this.customSizeRadioButton.UseVisualStyleBackColor = true;
            this.customSizeRadioButton.CheckedChanged += new System.EventHandler(this.customSizeRadioButton_CheckedChanged);
            // 
            // size256x256RadioButton
            // 
            this.size256x256RadioButton.AutoSize = true;
            this.size256x256RadioButton.Location = new System.Drawing.Point(104, 65);
            this.size256x256RadioButton.Name = "size256x256RadioButton";
            this.size256x256RadioButton.Size = new System.Drawing.Size(72, 17);
            this.size256x256RadioButton.TabIndex = 5;
            this.size256x256RadioButton.Text = "256 x 256";
            this.size256x256RadioButton.UseVisualStyleBackColor = true;
            // 
            // size128x128RadioButton
            // 
            this.size128x128RadioButton.AutoSize = true;
            this.size128x128RadioButton.Location = new System.Drawing.Point(104, 42);
            this.size128x128RadioButton.Name = "size128x128RadioButton";
            this.size128x128RadioButton.Size = new System.Drawing.Size(72, 17);
            this.size128x128RadioButton.TabIndex = 4;
            this.size128x128RadioButton.Text = "128 x 128";
            this.size128x128RadioButton.UseVisualStyleBackColor = true;
            // 
            // size64x64RadioButton
            // 
            this.size64x64RadioButton.AutoSize = true;
            this.size64x64RadioButton.Location = new System.Drawing.Point(104, 19);
            this.size64x64RadioButton.Name = "size64x64RadioButton";
            this.size64x64RadioButton.Size = new System.Drawing.Size(60, 17);
            this.size64x64RadioButton.TabIndex = 3;
            this.size64x64RadioButton.Text = "64 x 64";
            this.size64x64RadioButton.UseVisualStyleBackColor = true;
            // 
            // size48x48RadioButton
            // 
            this.size48x48RadioButton.AutoSize = true;
            this.size48x48RadioButton.Location = new System.Drawing.Point(9, 65);
            this.size48x48RadioButton.Name = "size48x48RadioButton";
            this.size48x48RadioButton.Size = new System.Drawing.Size(60, 17);
            this.size48x48RadioButton.TabIndex = 2;
            this.size48x48RadioButton.Text = "48 x 48";
            this.size48x48RadioButton.UseVisualStyleBackColor = true;
            // 
            // size32x32RadioButton
            // 
            this.size32x32RadioButton.AutoSize = true;
            this.size32x32RadioButton.Checked = true;
            this.size32x32RadioButton.Location = new System.Drawing.Point(9, 42);
            this.size32x32RadioButton.Name = "size32x32RadioButton";
            this.size32x32RadioButton.Size = new System.Drawing.Size(60, 17);
            this.size32x32RadioButton.TabIndex = 1;
            this.size32x32RadioButton.TabStop = true;
            this.size32x32RadioButton.Text = "32 x 32";
            this.size32x32RadioButton.UseVisualStyleBackColor = true;
            // 
            // size16x16RadioButton
            // 
            this.size16x16RadioButton.AutoSize = true;
            this.size16x16RadioButton.Location = new System.Drawing.Point(9, 19);
            this.size16x16RadioButton.Name = "size16x16RadioButton";
            this.size16x16RadioButton.Size = new System.Drawing.Size(60, 17);
            this.size16x16RadioButton.TabIndex = 0;
            this.size16x16RadioButton.Text = "16 x 16";
            this.size16x16RadioButton.UseVisualStyleBackColor = true;
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.cursorRadioButton);
            this.typeGroupBox.Controls.Add(this.iconRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(12, 95);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(332, 49);
            this.typeGroupBox.TabIndex = 23;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Type";
            // 
            // cursorRadioButton
            // 
            this.cursorRadioButton.AutoSize = true;
            this.cursorRadioButton.Location = new System.Drawing.Point(120, 19);
            this.cursorRadioButton.Name = "cursorRadioButton";
            this.cursorRadioButton.Size = new System.Drawing.Size(55, 17);
            this.cursorRadioButton.TabIndex = 1;
            this.cursorRadioButton.Text = "Cursor";
            this.cursorRadioButton.UseVisualStyleBackColor = true;
            // 
            // iconRadioButton
            // 
            this.iconRadioButton.AutoSize = true;
            this.iconRadioButton.Checked = true;
            this.iconRadioButton.Location = new System.Drawing.Point(9, 19);
            this.iconRadioButton.Name = "iconRadioButton";
            this.iconRadioButton.Size = new System.Drawing.Size(46, 17);
            this.iconRadioButton.TabIndex = 0;
            this.iconRadioButton.TabStop = true;
            this.iconRadioButton.Text = "Icon";
            this.iconRadioButton.UseVisualStyleBackColor = true;
            // 
            // backgroundColorPanelControl
            // 
            this.backgroundColorPanelControl.CanEditAlphaChannel = false;
            this.backgroundColorPanelControl.Color = System.Drawing.Color.White;
            this.backgroundColorPanelControl.ColorButtonMargin = 6;
            this.backgroundColorPanelControl.ColorButtonText = "Color...";
            this.backgroundColorPanelControl.ColorButtonWidth = 106;
            this.backgroundColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.backgroundColorPanelControl.Location = new System.Drawing.Point(123, 40);
            this.backgroundColorPanelControl.Name = "backgroundColorPanelControl";
            this.backgroundColorPanelControl.Size = new System.Drawing.Size(221, 22);
            this.backgroundColorPanelControl.TabIndex = 24;
            // 
            // InsertPageForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(354, 328);
            this.Controls.Add(this.backgroundColorPanelControl);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.sizeGroupBox);
            this.Controls.Add(this.colorDepthGroupBox);
            this.Controls.Add(this.insertIndexNumericUpDown);
            this.Controls.Add(this.insertIndexLabel);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.emptyPageRadioButton);
            this.Controls.Add(this.pageFromImageRadioButton);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert New Icon Page";
            ((System.ComponentModel.ISupportInitialize)(this.insertIndexNumericUpDown)).EndInit();
            this.colorDepthGroupBox.ResumeLayout(false);
            this.colorDepthGroupBox.PerformLayout();
            this.sizeGroupBox.ResumeLayout(false);
            this.sizeGroupBox.PerformLayout();
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton pageFromImageRadioButton;
        private System.Windows.Forms.RadioButton emptyPageRadioButton;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.Label insertIndexLabel;
        private System.Windows.Forms.NumericUpDown insertIndexNumericUpDown;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.GroupBox colorDepthGroupBox;
        private System.Windows.Forms.RadioButton bpp32RadioButton;
        private System.Windows.Forms.RadioButton bpp24RadioButton;
        private System.Windows.Forms.RadioButton bpp8RadioButton;
        private System.Windows.Forms.RadioButton bpp4RadioButton;
        private System.Windows.Forms.RadioButton bpp1RadioButton;
        private System.Windows.Forms.GroupBox sizeGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customSizeHeightTextBox;
        private System.Windows.Forms.TextBox customSizeWidthTextBox;
        private System.Windows.Forms.RadioButton customSizeRadioButton;
        private System.Windows.Forms.RadioButton size256x256RadioButton;
        private System.Windows.Forms.RadioButton size128x128RadioButton;
        private System.Windows.Forms.RadioButton size64x64RadioButton;
        private System.Windows.Forms.RadioButton size48x48RadioButton;
        private System.Windows.Forms.RadioButton size32x32RadioButton;
        private System.Windows.Forms.RadioButton size16x16RadioButton;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton cursorRadioButton;
        private System.Windows.Forms.RadioButton iconRadioButton;
        private DemosCommonCode.CustomControls.ColorPanelControl backgroundColorPanelControl;
    }
}