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
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorBtn = new System.Windows.Forms.Button();
            this.redBar = new System.Windows.Forms.TrackBar();
            this.greenBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.blueBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.medianBtn = new System.Windows.Forms.Button();
            this.posterBtn = new System.Windows.Forms.Button();
            this.grayBtn = new System.Windows.Forms.Button();
            this.sepBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pixelBar = new System.Windows.Forms.TrackBar();
            this.pixelBtn = new System.Windows.Forms.Button();
            this.sphereBtn = new System.Windows.Forms.Button();
            this.sharpBtn = new System.Windows.Forms.Button();
            this.embossBtn = new System.Windows.Forms.Button();
            this.blurBtn = new System.Windows.Forms.Button();
            this.sobelBtn = new System.Windows.Forms.Button();
            this.previewPic = new System.Windows.Forms.PictureBox();
            this.mainPic = new System.Windows.Forms.PictureBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.colorBtn);
            this.panel1.Controls.Add(this.redBar);
            this.panel1.Controls.Add(this.greenBar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.blueBar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 139);
            this.panel1.TabIndex = 16;
            // 
            // colorBtn
            // 
            this.colorBtn.Location = new System.Drawing.Point(21, 87);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(75, 23);
            this.colorBtn.TabIndex = 14;
            this.colorBtn.Text = "Color";
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.colorBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // redBar
            // 
            this.redBar.Location = new System.Drawing.Point(129, 87);
            this.redBar.Maximum = 255;
            this.redBar.Minimum = -255;
            this.redBar.Name = "redBar";
            this.redBar.Size = new System.Drawing.Size(104, 45);
            this.redBar.TabIndex = 8;
            this.redBar.ValueChanged += new System.EventHandler(this.previewControlActivated);
            // 
            // greenBar
            // 
            this.greenBar.Location = new System.Drawing.Point(129, 23);
            this.greenBar.Maximum = 255;
            this.greenBar.Minimum = -255;
            this.greenBar.Name = "greenBar";
            this.greenBar.Size = new System.Drawing.Size(104, 45);
            this.greenBar.TabIndex = 9;
            this.greenBar.ValueChanged += new System.EventHandler(this.previewControlActivated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Blue";
            // 
            // blueBar
            // 
            this.blueBar.Location = new System.Drawing.Point(13, 23);
            this.blueBar.Maximum = 255;
            this.blueBar.Minimum = -255;
            this.blueBar.Name = "blueBar";
            this.blueBar.Size = new System.Drawing.Size(104, 45);
            this.blueBar.TabIndex = 10;
            this.blueBar.ValueChanged += new System.EventHandler(this.previewControlActivated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Green";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Red";
            // 
            // medianBtn
            // 
            this.medianBtn.Location = new System.Drawing.Point(113, 259);
            this.medianBtn.Name = "medianBtn";
            this.medianBtn.Size = new System.Drawing.Size(75, 23);
            this.medianBtn.TabIndex = 15;
            this.medianBtn.Text = "Median";
            this.medianBtn.UseVisualStyleBackColor = true;
            this.medianBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.medianBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // posterBtn
            // 
            this.posterBtn.Location = new System.Drawing.Point(113, 230);
            this.posterBtn.Name = "posterBtn";
            this.posterBtn.Size = new System.Drawing.Size(75, 23);
            this.posterBtn.TabIndex = 7;
            this.posterBtn.Text = "Posterize";
            this.posterBtn.UseVisualStyleBackColor = true;
            this.posterBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.posterBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // grayBtn
            // 
            this.grayBtn.Location = new System.Drawing.Point(32, 260);
            this.grayBtn.Name = "grayBtn";
            this.grayBtn.Size = new System.Drawing.Size(75, 23);
            this.grayBtn.TabIndex = 6;
            this.grayBtn.Text = "Gray";
            this.grayBtn.UseVisualStyleBackColor = true;
            this.grayBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.grayBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // sepBtn
            // 
            this.sepBtn.Location = new System.Drawing.Point(32, 230);
            this.sepBtn.Name = "sepBtn";
            this.sepBtn.Size = new System.Drawing.Size(75, 23);
            this.sepBtn.TabIndex = 5;
            this.sepBtn.Text = "Sepia";
            this.sepBtn.UseVisualStyleBackColor = true;
            this.sepBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filterBtn_MouseClick);
            this.sepBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "pixel size";
            // 
            // pixelBar
            // 
            this.pixelBar.Location = new System.Drawing.Point(32, 35);
            this.pixelBar.Maximum = 50;
            this.pixelBar.Name = "pixelBar";
            this.pixelBar.Size = new System.Drawing.Size(104, 45);
            this.pixelBar.TabIndex = 2;
            this.pixelBar.ValueChanged += new System.EventHandler(this.previewControlActivated);
            // 
            // pixelBtn
            // 
            this.pixelBtn.Location = new System.Drawing.Point(32, 86);
            this.pixelBtn.Name = "pixelBtn";
            this.pixelBtn.Size = new System.Drawing.Size(75, 23);
            this.pixelBtn.TabIndex = 1;
            this.pixelBtn.Text = "Pixelate";
            this.pixelBtn.UseVisualStyleBackColor = true;
            this.pixelBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.pixelBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // sphereBtn
            // 
            this.sphereBtn.Location = new System.Drawing.Point(113, 86);
            this.sphereBtn.Name = "sphereBtn";
            this.sphereBtn.Size = new System.Drawing.Size(75, 23);
            this.sphereBtn.TabIndex = 0;
            this.sphereBtn.Text = "Sphere";
            this.sphereBtn.UseVisualStyleBackColor = true;
            this.sphereBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.sphereBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // sharpBtn
            // 
            this.sharpBtn.Location = new System.Drawing.Point(112, 179);
            this.sharpBtn.Name = "sharpBtn";
            this.sharpBtn.Size = new System.Drawing.Size(75, 23);
            this.sharpBtn.TabIndex = 3;
            this.sharpBtn.Text = "Sharpen";
            this.sharpBtn.UseVisualStyleBackColor = true;
            this.sharpBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.sharpBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // embossBtn
            // 
            this.embossBtn.Location = new System.Drawing.Point(112, 149);
            this.embossBtn.Name = "embossBtn";
            this.embossBtn.Size = new System.Drawing.Size(75, 23);
            this.embossBtn.TabIndex = 2;
            this.embossBtn.Text = "Emboss";
            this.embossBtn.UseVisualStyleBackColor = true;
            this.embossBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.embossBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // blurBtn
            // 
            this.blurBtn.Location = new System.Drawing.Point(31, 179);
            this.blurBtn.Name = "blurBtn";
            this.blurBtn.Size = new System.Drawing.Size(75, 23);
            this.blurBtn.TabIndex = 1;
            this.blurBtn.Text = "Blur";
            this.blurBtn.UseVisualStyleBackColor = true;
            this.blurBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.blurBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // sobelBtn
            // 
            this.sobelBtn.Location = new System.Drawing.Point(31, 149);
            this.sobelBtn.Name = "sobelBtn";
            this.sobelBtn.Size = new System.Drawing.Size(75, 23);
            this.sobelBtn.TabIndex = 0;
            this.sobelBtn.Text = "Sobel";
            this.sobelBtn.UseVisualStyleBackColor = true;
            this.sobelBtn.Click += new System.EventHandler(this.filterBtn_MouseClick);
            this.sobelBtn.MouseHover += new System.EventHandler(this.previewControlActivated);
            // 
            // previewPic
            // 
            this.previewPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previewPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPic.Location = new System.Drawing.Point(12, 449);
            this.previewPic.Name = "previewPic";
            this.previewPic.Size = new System.Drawing.Size(279, 156);
            this.previewPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewPic.TabIndex = 0;
            this.previewPic.TabStop = false;
            // 
            // mainPic
            // 
            this.mainPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPic.Location = new System.Drawing.Point(0, 3);
            this.mainPic.Name = "mainPic";
            this.mainPic.Size = new System.Drawing.Size(638, 612);
            this.mainPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPic.TabIndex = 1;
            this.mainPic.TabStop = false;
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainPic);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sharpBtn);
            this.splitContainer1.Panel2.Controls.Add(this.sphereBtn);
            this.splitContainer1.Panel2.Controls.Add(this.embossBtn);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.blurBtn);
            this.splitContainer1.Panel2.Controls.Add(this.medianBtn);
            this.splitContainer1.Panel2.Controls.Add(this.sobelBtn);
            this.splitContainer1.Panel2.Controls.Add(this.pixelBar);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.pixelBtn);
            this.splitContainer1.Panel2.Controls.Add(this.posterBtn);
            this.splitContainer1.Panel2.Controls.Add(this.grayBtn);
            this.splitContainer1.Panel2.Controls.Add(this.previewPic);
            this.splitContainer1.Panel2.Controls.Add(this.sepBtn);
            this.splitContainer1.Size = new System.Drawing.Size(943, 618);
            this.splitContainer1.SplitterDistance = 641;
            this.splitContainer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 671);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPic)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox previewPic;
        private System.Windows.Forms.PictureBox mainPic;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button sepBtn;
        private System.Windows.Forms.Button grayBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button posterBtn;
        private System.Windows.Forms.TrackBar blueBar;
        private System.Windows.Forms.TrackBar greenBar;
        private System.Windows.Forms.TrackBar redBar;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sphereBtn;
        private System.Windows.Forms.Button medianBtn;
        private System.Windows.Forms.Button pixelBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar pixelBar;
        private System.Windows.Forms.Button sharpBtn;
        private System.Windows.Forms.Button embossBtn;
        private System.Windows.Forms.Button blurBtn;
        private System.Windows.Forms.Button sobelBtn;
        private System.Windows.Forms.Panel panel1;
    }
}

