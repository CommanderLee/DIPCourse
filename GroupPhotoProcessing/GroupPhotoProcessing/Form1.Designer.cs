namespace GroupPhotoProcessing
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPoint = new System.Windows.Forms.TabPage();
            this.panelImg = new System.Windows.Forms.Panel();
            this.pictureBoxImg = new System.Windows.Forms.PictureBox();
            this.panelImgNames = new System.Windows.Forms.Panel();
            this.panelImgMethods = new System.Windows.Forms.Panel();
            this.buttonContrastInc = new System.Windows.Forms.Button();
            this.buttonBrightnessDec = new System.Windows.Forms.Button();
            this.buttonBrightnessInc = new System.Windows.Forms.Button();
            this.labelImgName = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tabFusion = new System.Windows.Forms.TabPage();
            this.tabStiching = new System.Windows.Forms.TabPage();
            this.buttonContrastDec = new System.Windows.Forms.Button();
            this.buttonRedInc = new System.Windows.Forms.Button();
            this.buttonRedDec = new System.Windows.Forms.Button();
            this.buttonGreenInc = new System.Windows.Forms.Button();
            this.buttonGreenDec = new System.Windows.Forms.Button();
            this.buttonBlueInc = new System.Windows.Forms.Button();
            this.buttonBlueDec = new System.Windows.Forms.Button();
            this.buttonGammaInc = new System.Windows.Forms.Button();
            this.buttonGammaDec = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPoint.SuspendLayout();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
            this.panelImgMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPoint);
            this.tabControl1.Controls.Add(this.tabFusion);
            this.tabControl1.Controls.Add(this.tabStiching);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1560, 930);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPoint
            // 
            this.tabPoint.Controls.Add(this.panelImg);
            this.tabPoint.Controls.Add(this.panelImgNames);
            this.tabPoint.Controls.Add(this.panelImgMethods);
            this.tabPoint.Location = new System.Drawing.Point(4, 25);
            this.tabPoint.Name = "tabPoint";
            this.tabPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPoint.Size = new System.Drawing.Size(1552, 901);
            this.tabPoint.TabIndex = 0;
            this.tabPoint.Text = "PointProcessing";
            this.tabPoint.UseVisualStyleBackColor = true;
            // 
            // panelImg
            // 
            this.panelImg.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImg.Controls.Add(this.pictureBoxImg);
            this.panelImg.Location = new System.Drawing.Point(10, 130);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(1530, 760);
            this.panelImg.TabIndex = 2;
            // 
            // pictureBoxImg
            // 
            this.pictureBoxImg.Location = new System.Drawing.Point(15, -2);
            this.pictureBoxImg.Name = "pictureBoxImg";
            this.pictureBoxImg.Size = new System.Drawing.Size(1525, 755);
            this.pictureBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImg.TabIndex = 0;
            this.pictureBoxImg.TabStop = false;
            // 
            // panelImgNames
            // 
            this.panelImgNames.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelImgNames.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImgNames.Location = new System.Drawing.Point(10, 70);
            this.panelImgNames.Name = "panelImgNames";
            this.panelImgNames.Size = new System.Drawing.Size(1530, 50);
            this.panelImgNames.TabIndex = 1;
            // 
            // panelImgMethods
            // 
            this.panelImgMethods.BackColor = System.Drawing.Color.AliceBlue;
            this.panelImgMethods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImgMethods.Controls.Add(this.buttonGammaDec);
            this.panelImgMethods.Controls.Add(this.buttonGammaInc);
            this.panelImgMethods.Controls.Add(this.buttonBlueDec);
            this.panelImgMethods.Controls.Add(this.buttonBlueInc);
            this.panelImgMethods.Controls.Add(this.buttonGreenDec);
            this.panelImgMethods.Controls.Add(this.buttonGreenInc);
            this.panelImgMethods.Controls.Add(this.buttonRedDec);
            this.panelImgMethods.Controls.Add(this.buttonRedInc);
            this.panelImgMethods.Controls.Add(this.buttonContrastDec);
            this.panelImgMethods.Controls.Add(this.buttonContrastInc);
            this.panelImgMethods.Controls.Add(this.buttonBrightnessDec);
            this.panelImgMethods.Controls.Add(this.buttonBrightnessInc);
            this.panelImgMethods.Controls.Add(this.labelImgName);
            this.panelImgMethods.Controls.Add(this.buttonLoad);
            this.panelImgMethods.Location = new System.Drawing.Point(10, 10);
            this.panelImgMethods.Name = "panelImgMethods";
            this.panelImgMethods.Size = new System.Drawing.Size(1530, 50);
            this.panelImgMethods.TabIndex = 0;
            // 
            // buttonContrastInc
            // 
            this.buttonContrastInc.BackColor = System.Drawing.Color.Azure;
            this.buttonContrastInc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonContrastInc.BackgroundImage")));
            this.buttonContrastInc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonContrastInc.Location = new System.Drawing.Point(350, 3);
            this.buttonContrastInc.Name = "buttonContrastInc";
            this.buttonContrastInc.Size = new System.Drawing.Size(40, 40);
            this.buttonContrastInc.TabIndex = 4;
            this.buttonContrastInc.UseVisualStyleBackColor = false;
            this.buttonContrastInc.Click += new System.EventHandler(this.buttonContrastInc_Click);
            // 
            // buttonBrightnessDec
            // 
            this.buttonBrightnessDec.BackColor = System.Drawing.Color.Azure;
            this.buttonBrightnessDec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBrightnessDec.BackgroundImage")));
            this.buttonBrightnessDec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonBrightnessDec.Location = new System.Drawing.Point(300, 3);
            this.buttonBrightnessDec.Name = "buttonBrightnessDec";
            this.buttonBrightnessDec.Size = new System.Drawing.Size(40, 40);
            this.buttonBrightnessDec.TabIndex = 3;
            this.buttonBrightnessDec.UseVisualStyleBackColor = false;
            this.buttonBrightnessDec.Click += new System.EventHandler(this.buttonBrightnessDec_Click);
            // 
            // buttonBrightnessInc
            // 
            this.buttonBrightnessInc.BackColor = System.Drawing.Color.Azure;
            this.buttonBrightnessInc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBrightnessInc.BackgroundImage")));
            this.buttonBrightnessInc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonBrightnessInc.Location = new System.Drawing.Point(250, 3);
            this.buttonBrightnessInc.Name = "buttonBrightnessInc";
            this.buttonBrightnessInc.Size = new System.Drawing.Size(40, 40);
            this.buttonBrightnessInc.TabIndex = 2;
            this.buttonBrightnessInc.UseVisualStyleBackColor = false;
            this.buttonBrightnessInc.Click += new System.EventHandler(this.buttonBrightnessInc_Click);
            // 
            // labelImgName
            // 
            this.labelImgName.AutoSize = true;
            this.labelImgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelImgName.Location = new System.Drawing.Point(100, 8);
            this.labelImgName.Name = "labelImgName";
            this.labelImgName.Size = new System.Drawing.Size(55, 29);
            this.labelImgName.TabIndex = 1;
            this.labelImgName.Text = "N/A";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(3, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(90, 40);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // tabFusion
            // 
            this.tabFusion.Location = new System.Drawing.Point(4, 25);
            this.tabFusion.Name = "tabFusion";
            this.tabFusion.Padding = new System.Windows.Forms.Padding(3);
            this.tabFusion.Size = new System.Drawing.Size(1552, 901);
            this.tabFusion.TabIndex = 1;
            this.tabFusion.Text = "ImageFusion";
            this.tabFusion.UseVisualStyleBackColor = true;
            // 
            // tabStiching
            // 
            this.tabStiching.Location = new System.Drawing.Point(4, 25);
            this.tabStiching.Name = "tabStiching";
            this.tabStiching.Size = new System.Drawing.Size(1552, 901);
            this.tabStiching.TabIndex = 2;
            this.tabStiching.Text = "ImageStiching";
            this.tabStiching.UseVisualStyleBackColor = true;
            // 
            // buttonContrastDec
            // 
            this.buttonContrastDec.BackColor = System.Drawing.Color.Azure;
            this.buttonContrastDec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonContrastDec.BackgroundImage")));
            this.buttonContrastDec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonContrastDec.Location = new System.Drawing.Point(400, 3);
            this.buttonContrastDec.Name = "buttonContrastDec";
            this.buttonContrastDec.Size = new System.Drawing.Size(40, 40);
            this.buttonContrastDec.TabIndex = 5;
            this.buttonContrastDec.UseVisualStyleBackColor = false;
            this.buttonContrastDec.Click += new System.EventHandler(this.buttonContrastDec_Click);
            // 
            // buttonRedInc
            // 
            this.buttonRedInc.BackColor = System.Drawing.Color.Red;
            this.buttonRedInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRedInc.Location = new System.Drawing.Point(550, 3);
            this.buttonRedInc.Name = "buttonRedInc";
            this.buttonRedInc.Size = new System.Drawing.Size(40, 40);
            this.buttonRedInc.TabIndex = 6;
            this.buttonRedInc.Text = "+";
            this.buttonRedInc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRedInc.UseVisualStyleBackColor = false;
            this.buttonRedInc.Click += new System.EventHandler(this.buttonRedInc_Click);
            // 
            // buttonRedDec
            // 
            this.buttonRedDec.BackColor = System.Drawing.Color.Red;
            this.buttonRedDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRedDec.Location = new System.Drawing.Point(600, 3);
            this.buttonRedDec.Name = "buttonRedDec";
            this.buttonRedDec.Size = new System.Drawing.Size(40, 40);
            this.buttonRedDec.TabIndex = 7;
            this.buttonRedDec.Text = "-";
            this.buttonRedDec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRedDec.UseVisualStyleBackColor = false;
            this.buttonRedDec.Click += new System.EventHandler(this.buttonRedDec_Click);
            // 
            // buttonGreenInc
            // 
            this.buttonGreenInc.BackColor = System.Drawing.Color.Lime;
            this.buttonGreenInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGreenInc.Location = new System.Drawing.Point(650, 3);
            this.buttonGreenInc.Name = "buttonGreenInc";
            this.buttonGreenInc.Size = new System.Drawing.Size(40, 40);
            this.buttonGreenInc.TabIndex = 8;
            this.buttonGreenInc.Text = "+";
            this.buttonGreenInc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGreenInc.UseVisualStyleBackColor = false;
            this.buttonGreenInc.Click += new System.EventHandler(this.buttonGreenInc_Click);
            // 
            // buttonGreenDec
            // 
            this.buttonGreenDec.BackColor = System.Drawing.Color.Lime;
            this.buttonGreenDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGreenDec.Location = new System.Drawing.Point(700, 3);
            this.buttonGreenDec.Name = "buttonGreenDec";
            this.buttonGreenDec.Size = new System.Drawing.Size(40, 40);
            this.buttonGreenDec.TabIndex = 9;
            this.buttonGreenDec.Text = "-";
            this.buttonGreenDec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGreenDec.UseVisualStyleBackColor = false;
            this.buttonGreenDec.Click += new System.EventHandler(this.buttonGreenDec_Click);
            // 
            // buttonBlueInc
            // 
            this.buttonBlueInc.BackColor = System.Drawing.Color.Blue;
            this.buttonBlueInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBlueInc.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBlueInc.Location = new System.Drawing.Point(750, 3);
            this.buttonBlueInc.Name = "buttonBlueInc";
            this.buttonBlueInc.Size = new System.Drawing.Size(40, 40);
            this.buttonBlueInc.TabIndex = 10;
            this.buttonBlueInc.Text = "+";
            this.buttonBlueInc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBlueInc.UseVisualStyleBackColor = false;
            this.buttonBlueInc.Click += new System.EventHandler(this.buttonBlueInc_Click);
            // 
            // buttonBlueDec
            // 
            this.buttonBlueDec.BackColor = System.Drawing.Color.Blue;
            this.buttonBlueDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBlueDec.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBlueDec.Location = new System.Drawing.Point(800, 3);
            this.buttonBlueDec.Name = "buttonBlueDec";
            this.buttonBlueDec.Size = new System.Drawing.Size(40, 40);
            this.buttonBlueDec.TabIndex = 11;
            this.buttonBlueDec.Text = "-";
            this.buttonBlueDec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBlueDec.UseVisualStyleBackColor = false;
            this.buttonBlueDec.Click += new System.EventHandler(this.buttonBlueDec_Click);
            // 
            // buttonGammaInc
            // 
            this.buttonGammaInc.BackColor = System.Drawing.Color.Azure;
            this.buttonGammaInc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGammaInc.BackgroundImage")));
            this.buttonGammaInc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGammaInc.Location = new System.Drawing.Point(450, 3);
            this.buttonGammaInc.Name = "buttonGammaInc";
            this.buttonGammaInc.Size = new System.Drawing.Size(40, 40);
            this.buttonGammaInc.TabIndex = 12;
            this.buttonGammaInc.UseVisualStyleBackColor = false;
            this.buttonGammaInc.Click += new System.EventHandler(this.buttonGammaInc_Click);
            // 
            // buttonGammaDec
            // 
            this.buttonGammaDec.BackColor = System.Drawing.Color.Azure;
            this.buttonGammaDec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGammaDec.BackgroundImage")));
            this.buttonGammaDec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGammaDec.Location = new System.Drawing.Point(500, 3);
            this.buttonGammaDec.Name = "buttonGammaDec";
            this.buttonGammaDec.Size = new System.Drawing.Size(40, 40);
            this.buttonGammaDec.TabIndex = 13;
            this.buttonGammaDec.UseVisualStyleBackColor = false;
            this.buttonGammaDec.Click += new System.EventHandler(this.buttonGammaDec_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 953);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPoint.ResumeLayout(false);
            this.panelImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
            this.panelImgMethods.ResumeLayout(false);
            this.panelImgMethods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPoint;
        private System.Windows.Forms.TabPage tabFusion;
        private System.Windows.Forms.TabPage tabStiching;
        private System.Windows.Forms.Panel panelImgMethods;
        private System.Windows.Forms.Panel panelImgNames;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label labelImgName;
        private System.Windows.Forms.Panel panelImg;
        private System.Windows.Forms.PictureBox pictureBoxImg;
        private System.Windows.Forms.Button buttonBrightnessInc;
        private System.Windows.Forms.Button buttonBrightnessDec;
        private System.Windows.Forms.Button buttonContrastInc;
        private System.Windows.Forms.Button buttonContrastDec;
        private System.Windows.Forms.Button buttonRedInc;
        private System.Windows.Forms.Button buttonRedDec;
        private System.Windows.Forms.Button buttonGreenInc;
        private System.Windows.Forms.Button buttonGreenDec;
        private System.Windows.Forms.Button buttonBlueInc;
        private System.Windows.Forms.Button buttonBlueDec;
        private System.Windows.Forms.Button buttonGammaInc;
        private System.Windows.Forms.Button buttonGammaDec;
    }
}

