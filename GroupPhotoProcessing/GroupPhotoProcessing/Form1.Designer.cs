﻿namespace GroupPhotoProcessing
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
            this.buttonImgType = new System.Windows.Forms.Button();
            this.buttonGammaDec = new System.Windows.Forms.Button();
            this.buttonGammaInc = new System.Windows.Forms.Button();
            this.buttonBlueDec = new System.Windows.Forms.Button();
            this.buttonBlueInc = new System.Windows.Forms.Button();
            this.buttonGreenDec = new System.Windows.Forms.Button();
            this.buttonGreenInc = new System.Windows.Forms.Button();
            this.buttonRedDec = new System.Windows.Forms.Button();
            this.buttonRedInc = new System.Windows.Forms.Button();
            this.buttonContrastDec = new System.Windows.Forms.Button();
            this.buttonContrastInc = new System.Windows.Forms.Button();
            this.buttonBrightnessDec = new System.Windows.Forms.Button();
            this.buttonBrightnessInc = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tabFusion = new System.Windows.Forms.TabPage();
            this.panelImgFusion = new System.Windows.Forms.Panel();
            this.pictureBoxImgFusion = new System.Windows.Forms.PictureBox();
            this.panelSingleImgNames = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGroupImgNames = new System.Windows.Forms.Panel();
            this.labelGroup = new System.Windows.Forms.Label();
            this.panelImgMethodsFusion = new System.Windows.Forms.Panel();
            this.buttonFusionPreparing = new System.Windows.Forms.Button();
            this.tabStiching = new System.Windows.Forms.TabPage();
            this.labelStatusFusion = new System.Windows.Forms.Label();
            this.buttonDrawBoundary = new System.Windows.Forms.Button();
            this.buttonClearBoundary = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPoint.SuspendLayout();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
            this.panelImgMethods.SuspendLayout();
            this.tabFusion.SuspendLayout();
            this.panelImgFusion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgFusion)).BeginInit();
            this.panelSingleImgNames.SuspendLayout();
            this.panelGroupImgNames.SuspendLayout();
            this.panelImgMethodsFusion.SuspendLayout();
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
            this.pictureBoxImg.Location = new System.Drawing.Point(0, 0);
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
            this.panelImgMethods.Controls.Add(this.buttonImgType);
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
            this.panelImgMethods.Controls.Add(this.labelStatus);
            this.panelImgMethods.Controls.Add(this.buttonLoad);
            this.panelImgMethods.Location = new System.Drawing.Point(10, 10);
            this.panelImgMethods.Name = "panelImgMethods";
            this.panelImgMethods.Size = new System.Drawing.Size(1530, 50);
            this.panelImgMethods.TabIndex = 0;
            // 
            // buttonImgType
            // 
            this.buttonImgType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonImgType.Location = new System.Drawing.Point(850, 3);
            this.buttonImgType.Name = "buttonImgType";
            this.buttonImgType.Size = new System.Drawing.Size(110, 40);
            this.buttonImgType.TabIndex = 14;
            this.buttonImgType.Text = "Group";
            this.buttonImgType.UseVisualStyleBackColor = true;
            this.buttonImgType.Click += new System.EventHandler(this.buttonImgType_Click);
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
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(120, 8);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(55, 29);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "N/A";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLoad.Location = new System.Drawing.Point(3, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(110, 40);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // tabFusion
            // 
            this.tabFusion.Controls.Add(this.panelImgFusion);
            this.tabFusion.Controls.Add(this.panelSingleImgNames);
            this.tabFusion.Controls.Add(this.panelGroupImgNames);
            this.tabFusion.Controls.Add(this.panelImgMethodsFusion);
            this.tabFusion.Location = new System.Drawing.Point(4, 25);
            this.tabFusion.Name = "tabFusion";
            this.tabFusion.Padding = new System.Windows.Forms.Padding(3);
            this.tabFusion.Size = new System.Drawing.Size(1552, 901);
            this.tabFusion.TabIndex = 1;
            this.tabFusion.Text = "ImageFusion";
            this.tabFusion.UseVisualStyleBackColor = true;
            // 
            // panelImgFusion
            // 
            this.panelImgFusion.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelImgFusion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImgFusion.Controls.Add(this.pictureBoxImgFusion);
            this.panelImgFusion.Location = new System.Drawing.Point(10, 130);
            this.panelImgFusion.Name = "panelImgFusion";
            this.panelImgFusion.Size = new System.Drawing.Size(1530, 760);
            this.panelImgFusion.TabIndex = 4;
            // 
            // pictureBoxImgFusion
            // 
            this.pictureBoxImgFusion.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImgFusion.Name = "pictureBoxImgFusion";
            this.pictureBoxImgFusion.Size = new System.Drawing.Size(1525, 755);
            this.pictureBoxImgFusion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImgFusion.TabIndex = 0;
            this.pictureBoxImgFusion.TabStop = false;
            // 
            // panelSingleImgNames
            // 
            this.panelSingleImgNames.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelSingleImgNames.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSingleImgNames.Controls.Add(this.label2);
            this.panelSingleImgNames.Location = new System.Drawing.Point(780, 70);
            this.panelSingleImgNames.Name = "panelSingleImgNames";
            this.panelSingleImgNames.Size = new System.Drawing.Size(760, 50);
            this.panelSingleImgNames.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Single Photos: ";
            // 
            // panelGroupImgNames
            // 
            this.panelGroupImgNames.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelGroupImgNames.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGroupImgNames.Controls.Add(this.labelGroup);
            this.panelGroupImgNames.Location = new System.Drawing.Point(10, 70);
            this.panelGroupImgNames.Name = "panelGroupImgNames";
            this.panelGroupImgNames.Size = new System.Drawing.Size(760, 50);
            this.panelGroupImgNames.TabIndex = 2;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGroup.Location = new System.Drawing.Point(3, 8);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(157, 25);
            this.labelGroup.TabIndex = 15;
            this.labelGroup.Text = "Group Photos: ";
            // 
            // panelImgMethodsFusion
            // 
            this.panelImgMethodsFusion.BackColor = System.Drawing.Color.AliceBlue;
            this.panelImgMethodsFusion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImgMethodsFusion.Controls.Add(this.buttonClearBoundary);
            this.panelImgMethodsFusion.Controls.Add(this.buttonDrawBoundary);
            this.panelImgMethodsFusion.Controls.Add(this.labelStatusFusion);
            this.panelImgMethodsFusion.Controls.Add(this.buttonFusionPreparing);
            this.panelImgMethodsFusion.Location = new System.Drawing.Point(10, 10);
            this.panelImgMethodsFusion.Name = "panelImgMethodsFusion";
            this.panelImgMethodsFusion.Size = new System.Drawing.Size(1530, 50);
            this.panelImgMethodsFusion.TabIndex = 1;
            // 
            // buttonFusionPreparing
            // 
            this.buttonFusionPreparing.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFusionPreparing.Location = new System.Drawing.Point(3, 3);
            this.buttonFusionPreparing.Name = "buttonFusionPreparing";
            this.buttonFusionPreparing.Size = new System.Drawing.Size(110, 40);
            this.buttonFusionPreparing.TabIndex = 0;
            this.buttonFusionPreparing.Text = "Pre-Process";
            this.buttonFusionPreparing.UseVisualStyleBackColor = true;
            this.buttonFusionPreparing.Click += new System.EventHandler(this.buttonFusionPreparing_Click);
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
            // labelStatusFusion
            // 
            this.labelStatusFusion.AutoSize = true;
            this.labelStatusFusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatusFusion.Location = new System.Drawing.Point(120, 8);
            this.labelStatusFusion.Name = "labelStatusFusion";
            this.labelStatusFusion.Size = new System.Drawing.Size(55, 29);
            this.labelStatusFusion.TabIndex = 2;
            this.labelStatusFusion.Text = "N/A";
            // 
            // buttonDrawBoundary
            // 
            this.buttonDrawBoundary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDrawBoundary.Location = new System.Drawing.Point(250, 3);
            this.buttonDrawBoundary.Name = "buttonDrawBoundary";
            this.buttonDrawBoundary.Size = new System.Drawing.Size(130, 40);
            this.buttonDrawBoundary.TabIndex = 3;
            this.buttonDrawBoundary.Text = "Draw Boundary";
            this.buttonDrawBoundary.UseVisualStyleBackColor = true;
            this.buttonDrawBoundary.Click += new System.EventHandler(this.buttonDrawBoundary_Click);
            // 
            // buttonClearBoundary
            // 
            this.buttonClearBoundary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearBoundary.Location = new System.Drawing.Point(390, 3);
            this.buttonClearBoundary.Name = "buttonClearBoundary";
            this.buttonClearBoundary.Size = new System.Drawing.Size(130, 40);
            this.buttonClearBoundary.TabIndex = 4;
            this.buttonClearBoundary.Text = "Clear Boundary";
            this.buttonClearBoundary.UseVisualStyleBackColor = true;
            this.buttonClearBoundary.Click += new System.EventHandler(this.buttonClearBoundary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 953);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Group Photo Processing - Zhen Li - Tsinghua University";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPoint.ResumeLayout(false);
            this.panelImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
            this.panelImgMethods.ResumeLayout(false);
            this.panelImgMethods.PerformLayout();
            this.tabFusion.ResumeLayout(false);
            this.panelImgFusion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgFusion)).EndInit();
            this.panelSingleImgNames.ResumeLayout(false);
            this.panelSingleImgNames.PerformLayout();
            this.panelGroupImgNames.ResumeLayout(false);
            this.panelGroupImgNames.PerformLayout();
            this.panelImgMethodsFusion.ResumeLayout(false);
            this.panelImgMethodsFusion.PerformLayout();
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
        private System.Windows.Forms.Label labelStatus;
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
        private System.Windows.Forms.Button buttonImgType;
        private System.Windows.Forms.Panel panelImgMethodsFusion;
        private System.Windows.Forms.Button buttonFusionPreparing;
        private System.Windows.Forms.Panel panelGroupImgNames;
        private System.Windows.Forms.Panel panelSingleImgNames;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelImgFusion;
        private System.Windows.Forms.PictureBox pictureBoxImgFusion;
        private System.Windows.Forms.Label labelStatusFusion;
        private System.Windows.Forms.Button buttonDrawBoundary;
        private System.Windows.Forms.Button buttonClearBoundary;
    }
}

