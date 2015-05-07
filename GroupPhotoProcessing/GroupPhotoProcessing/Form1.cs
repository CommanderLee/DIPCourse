using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace GroupPhotoProcessing
{
    public partial class Form1 : Form
    {
        // List of images and their control buttons
        List<Image<Bgr, byte>>  imgList;
        List<Button>            imgBtnList;

        int                     currImgId;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imgList = new List<Image<Bgr, byte>>();
            imgBtnList = new List<Button>();
        }

        /// <summary>
        /// Load an image from disk.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                int btnId = imgList.Count;
                Console.WriteLine("Button Id: " + btnId);

                // Load and show
                Image<Bgr, byte> tmpImg = new Image<Bgr, byte>(openFile.FileName);
                pictureBoxImg.Image = tmpImg.ToBitmap();
                imgList.Add(tmpImg);

                // Add a button
                // Magic numbers: Fixed button location/size in the 'panelImageNames'
                Button tmpBtn = new Button();
                tmpBtn.Text = btnId + ":" + openFile.FileName.Substring(openFile.FileName.Length - 8, 4);
                tmpBtn.Name = btnId.ToString();
                tmpBtn.Click += imgBtns_Click;
                tmpBtn.Size = new Size(90, 45);
                tmpBtn.Location = new Point(90 * btnId, 0);

                panelImgNames.Controls.Add(tmpBtn);
                imgBtnList.Add(tmpBtn);
            }
        }

        private void imgBtns_Click(object sender, EventArgs e)
        {
            int btnId = Convert.ToInt32(((Button)sender).Name);
            Console.WriteLine("Click on Button No." + btnId);
            if (btnId >= 0 && btnId < imgList.Count)
            {
                pictureBoxImg.Image = imgList[btnId].ToBitmap();
                currImgId = btnId;
                labelImgName.Text = imgBtnList[btnId].Text + ": ";
            }
            else
            {
                Console.WriteLine("Error: Image Button Index out of range.");
            }
        }
    }
}
