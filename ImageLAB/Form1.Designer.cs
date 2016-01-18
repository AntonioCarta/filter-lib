namespace ImageLAB
{
    partial class Form1
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
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.filterPropertiesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.tbRed = new System.Windows.Forms.TrackBar();
            this.tbBlue = new System.Windows.Forms.TrackBar();
            this.tbGreen = new System.Windows.Forms.TrackBar();
            this.btnMedian = new System.Windows.Forms.Button();
            this.btnSepia = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.btnPosterize = new System.Windows.Forms.Button();
            this.btnCloseSelection = new System.Windows.Forms.Button();
            this.btnCancelSelection = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbloffY = new System.Windows.Forms.Label();
            this.lbloffX = new System.Windows.Forms.Label();
            this.tbOffY = new System.Windows.Forms.TrackBar();
            this.tbOffX = new System.Windows.Forms.TrackBar();
            this.btnSphere = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPixelSize = new System.Windows.Forms.Label();
            this.tbPixelSize = new System.Windows.Forms.TrackBar();
            this.btnPixel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.btnEmboss = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            this.mainPic = new ImageLAB.MyPictureBox();
            this.filterPropertiesPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPixelSize)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 2;
            this.openBtn.Text = "Apri";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(93, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Salva";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Location = new System.Drawing.Point(174, 12);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Location = new System.Drawing.Point(50, 171);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 24);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Applica";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // filterPropertiesPanel
            // 
            this.filterPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterPropertiesPanel.Controls.Add(this.groupBox1);
            this.filterPropertiesPanel.Controls.Add(this.btnMedian);
            this.filterPropertiesPanel.Controls.Add(this.btnSepia);
            this.filterPropertiesPanel.Controls.Add(this.btnGray);
            this.filterPropertiesPanel.Controls.Add(this.btnPosterize);
            this.filterPropertiesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.filterPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPropertiesPanel.Margin = new System.Windows.Forms.Padding(10);
            this.filterPropertiesPanel.Name = "filterPropertiesPanel";
            this.filterPropertiesPanel.Padding = new System.Windows.Forms.Padding(10);
            this.filterPropertiesPanel.Size = new System.Drawing.Size(244, 380);
            this.filterPropertiesPanel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBlue);
            this.groupBox1.Controls.Add(this.lblGreen);
            this.groupBox1.Controls.Add(this.lblRed);
            this.groupBox1.Controls.Add(this.tbRed);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.tbBlue);
            this.groupBox1.Controls.Add(this.tbGreen);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 201);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canali RGB";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(6, 121);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(34, 13);
            this.lblBlue.TabIndex = 14;
            this.lblBlue.Text = "Blu: 0";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(6, 70);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(47, 13);
            this.lblGreen.TabIndex = 13;
            this.lblGreen.Text = "Verde: 0";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(6, 19);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(49, 13);
            this.lblRed.TabIndex = 12;
            this.lblRed.Text = "Rosso: 0";
            // 
            // tbRed
            // 
            this.tbRed.Location = new System.Drawing.Point(90, 19);
            this.tbRed.Maximum = 255;
            this.tbRed.Minimum = -255;
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(104, 45);
            this.tbRed.TabIndex = 9;
            this.tbRed.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // tbBlue
            // 
            this.tbBlue.Location = new System.Drawing.Point(90, 121);
            this.tbBlue.Maximum = 255;
            this.tbBlue.Minimum = -255;
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Size = new System.Drawing.Size(104, 45);
            this.tbBlue.TabIndex = 11;
            this.tbBlue.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // tbGreen
            // 
            this.tbGreen.Location = new System.Drawing.Point(90, 70);
            this.tbGreen.Maximum = 255;
            this.tbGreen.Minimum = -255;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(104, 45);
            this.tbGreen.TabIndex = 10;
            this.tbGreen.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // btnMedian
            // 
            this.btnMedian.Location = new System.Drawing.Point(13, 220);
            this.btnMedian.Name = "btnMedian";
            this.btnMedian.Size = new System.Drawing.Size(75, 23);
            this.btnMedian.TabIndex = 15;
            this.btnMedian.Text = "Median";
            this.btnMedian.UseVisualStyleBackColor = true;
            this.btnMedian.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnSepia
            // 
            this.btnSepia.Location = new System.Drawing.Point(13, 249);
            this.btnSepia.Name = "btnSepia";
            this.btnSepia.Size = new System.Drawing.Size(75, 23);
            this.btnSepia.TabIndex = 14;
            this.btnSepia.Text = "Seppia";
            this.btnSepia.UseVisualStyleBackColor = true;
            this.btnSepia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnGray
            // 
            this.btnGray.Location = new System.Drawing.Point(13, 278);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(75, 23);
            this.btnGray.TabIndex = 13;
            this.btnGray.Text = "Scala di grigi";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnPosterize
            // 
            this.btnPosterize.Location = new System.Drawing.Point(13, 307);
            this.btnPosterize.Name = "btnPosterize";
            this.btnPosterize.Size = new System.Drawing.Size(75, 23);
            this.btnPosterize.TabIndex = 13;
            this.btnPosterize.Text = "Posterize";
            this.btnPosterize.UseVisualStyleBackColor = true;
            this.btnPosterize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnCloseSelection
            // 
            this.btnCloseSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseSelection.Location = new System.Drawing.Point(743, 12);
            this.btnCloseSelection.Name = "btnCloseSelection";
            this.btnCloseSelection.Size = new System.Drawing.Size(96, 23);
            this.btnCloseSelection.TabIndex = 6;
            this.btnCloseSelection.Text = "Chiudi selezione";
            this.btnCloseSelection.UseVisualStyleBackColor = true;
            this.btnCloseSelection.Click += new System.EventHandler(this.btnCloseSelection_Click);
            // 
            // btnCancelSelection
            // 
            this.btnCancelSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSelection.Location = new System.Drawing.Point(845, 12);
            this.btnCancelSelection.Name = "btnCancelSelection";
            this.btnCancelSelection.Size = new System.Drawing.Size(97, 23);
            this.btnCancelSelection.TabIndex = 8;
            this.btnCancelSelection.Text = "Annulla selezione";
            this.btnCancelSelection.UseVisualStyleBackColor = true;
            this.btnCancelSelection.Click += new System.EventHandler(this.btnCancelSelection_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.CausesValidation = false;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(742, 47);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(255, 406);
            this.tabControl.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.filterPropertiesPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(247, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Colore";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(247, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Displacement";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbloffY);
            this.groupBox3.Controls.Add(this.lbloffX);
            this.groupBox3.Controls.Add(this.tbOffY);
            this.groupBox3.Controls.Add(this.tbOffX);
            this.groupBox3.Controls.Add(this.btnSphere);
            this.groupBox3.Location = new System.Drawing.Point(25, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 160);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sfera";
            // 
            // lbloffY
            // 
            this.lbloffY.AutoSize = true;
            this.lbloffY.Location = new System.Drawing.Point(19, 80);
            this.lbloffY.Name = "lbloffY";
            this.lbloffY.Size = new System.Drawing.Size(38, 13);
            this.lbloffY.TabIndex = 18;
            this.lbloffY.Text = "offY: 0";
            // 
            // lbloffX
            // 
            this.lbloffX.AutoSize = true;
            this.lbloffX.Location = new System.Drawing.Point(19, 19);
            this.lbloffX.Name = "lbloffX";
            this.lbloffX.Size = new System.Drawing.Size(38, 13);
            this.lbloffX.TabIndex = 17;
            this.lbloffX.Text = "offX: 0";
            // 
            // tbOffY
            // 
            this.tbOffY.Location = new System.Drawing.Point(90, 80);
            this.tbOffY.Maximum = 1000;
            this.tbOffY.Minimum = -1000;
            this.tbOffY.Name = "tbOffY";
            this.tbOffY.Size = new System.Drawing.Size(104, 45);
            this.tbOffY.TabIndex = 16;
            this.tbOffY.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // tbOffX
            // 
            this.tbOffX.Location = new System.Drawing.Point(90, 19);
            this.tbOffX.Maximum = 1000;
            this.tbOffX.Minimum = -1000;
            this.tbOffX.Name = "tbOffX";
            this.tbOffX.Size = new System.Drawing.Size(104, 45);
            this.tbOffX.TabIndex = 15;
            this.tbOffX.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // btnSphere
            // 
            this.btnSphere.Location = new System.Drawing.Point(101, 131);
            this.btnSphere.Name = "btnSphere";
            this.btnSphere.Size = new System.Drawing.Size(75, 23);
            this.btnSphere.TabIndex = 14;
            this.btnSphere.Text = "Applica";
            this.btnSphere.UseVisualStyleBackColor = true;
            this.btnSphere.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPixelSize);
            this.groupBox2.Controls.Add(this.tbPixelSize);
            this.groupBox2.Controls.Add(this.btnPixel);
            this.groupBox2.Location = new System.Drawing.Point(25, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 103);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pixelato";
            // 
            // lblPixelSize
            // 
            this.lblPixelSize.AutoSize = true;
            this.lblPixelSize.Location = new System.Drawing.Point(6, 19);
            this.lblPixelSize.Name = "lblPixelSize";
            this.lblPixelSize.Size = new System.Drawing.Size(74, 13);
            this.lblPixelSize.TabIndex = 16;
            this.lblPixelSize.Text = " Dim. Pixel: 20";
            // 
            // tbPixelSize
            // 
            this.tbPixelSize.Location = new System.Drawing.Point(90, 19);
            this.tbPixelSize.Maximum = 40;
            this.tbPixelSize.Minimum = 1;
            this.tbPixelSize.Name = "tbPixelSize";
            this.tbPixelSize.Size = new System.Drawing.Size(104, 45);
            this.tbPixelSize.TabIndex = 15;
            this.tbPixelSize.Value = 20;
            this.tbPixelSize.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // btnPixel
            // 
            this.btnPixel.Location = new System.Drawing.Point(101, 70);
            this.btnPixel.Name = "btnPixel";
            this.btnPixel.Size = new System.Drawing.Size(75, 23);
            this.btnPixel.TabIndex = 13;
            this.btnPixel.Text = "Applica";
            this.btnPixel.UseVisualStyleBackColor = true;
            this.btnPixel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSharpen);
            this.tabPage3.Controls.Add(this.btnEmboss);
            this.tabPage3.Controls.Add(this.btnBlur);
            this.tabPage3.Controls.Add(this.btnSobel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(247, 380);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Altro";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSharpen
            // 
            this.btnSharpen.Location = new System.Drawing.Point(77, 119);
            this.btnSharpen.Margin = new System.Windows.Forms.Padding(20);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(75, 23);
            this.btnSharpen.TabIndex = 3;
            this.btnSharpen.Text = "Sharpen";
            this.btnSharpen.UseVisualStyleBackColor = true;
            this.btnSharpen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnEmboss
            // 
            this.btnEmboss.Location = new System.Drawing.Point(77, 90);
            this.btnEmboss.Margin = new System.Windows.Forms.Padding(20);
            this.btnEmboss.Name = "btnEmboss";
            this.btnEmboss.Size = new System.Drawing.Size(75, 23);
            this.btnEmboss.TabIndex = 2;
            this.btnEmboss.Text = "Emboss";
            this.btnEmboss.UseVisualStyleBackColor = true;
            this.btnEmboss.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnBlur
            // 
            this.btnBlur.Location = new System.Drawing.Point(77, 61);
            this.btnBlur.Margin = new System.Windows.Forms.Padding(20);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(75, 23);
            this.btnBlur.TabIndex = 1;
            this.btnBlur.Text = "Blur";
            this.btnBlur.UseVisualStyleBackColor = true;
            this.btnBlur.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(77, 35);
            this.btnSobel.Margin = new System.Windows.Forms.Padding(20);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(75, 23);
            this.btnSobel.TabIndex = 0;
            this.btnSobel.Text = "Sobel";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_filter_click);
            // 
            // mainPic
            // 
            this.mainPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPic.Location = new System.Drawing.Point(12, 49);
            this.mainPic.Name = "mainPic";
            this.mainPic.Size = new System.Drawing.Size(721, 400);
            this.mainPic.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 465);
            this.Controls.Add(this.mainPic);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancelSelection);
            this.Controls.Add(this.btnCloseSelection);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Name = "Form1";
            this.Text = "ImageLAB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.filterPropertiesPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPixelSize)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.FlowLayoutPanel filterPropertiesPanel;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnCloseSelection;
        private System.Windows.Forms.Button btnCancelSelection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.TrackBar tbRed;
        private System.Windows.Forms.TrackBar tbBlue;
        private System.Windows.Forms.TrackBar tbGreen;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSepia;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.Button btnPosterize;
        private System.Windows.Forms.Button btnMedian;
        private System.Windows.Forms.Button btnPixel;
        private System.Windows.Forms.Button btnSphere;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSharpen;
        private System.Windows.Forms.Button btnEmboss;
        private System.Windows.Forms.Button btnBlur;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPixelSize;
        private System.Windows.Forms.TrackBar tbPixelSize;
        private MyPictureBox mainPic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbloffY;
        private System.Windows.Forms.Label lbloffX;
        private System.Windows.Forms.TrackBar tbOffY;
        private System.Windows.Forms.TrackBar tbOffX;
    }
}

