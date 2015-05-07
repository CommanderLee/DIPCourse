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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPoint = new System.Windows.Forms.TabPage();
            this.panelImgNames = new System.Windows.Forms.Panel();
            this.panelImgMethods = new System.Windows.Forms.Panel();
            this.labelImgName = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tabFusion = new System.Windows.Forms.TabPage();
            this.tabStiching = new System.Windows.Forms.TabPage();
            this.panelImg = new System.Windows.Forms.Panel();
            this.pictureBoxImg = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPoint.SuspendLayout();
            this.panelImgMethods.SuspendLayout();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
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
            this.panelImgMethods.Controls.Add(this.labelImgName);
            this.panelImgMethods.Controls.Add(this.buttonLoad);
            this.panelImgMethods.Location = new System.Drawing.Point(10, 10);
            this.panelImgMethods.Name = "panelImgMethods";
            this.panelImgMethods.Size = new System.Drawing.Size(1530, 50);
            this.panelImgMethods.TabIndex = 0;
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
            this.panelImgMethods.ResumeLayout(false);
            this.panelImgMethods.PerformLayout();
            this.panelImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
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
    }
}

