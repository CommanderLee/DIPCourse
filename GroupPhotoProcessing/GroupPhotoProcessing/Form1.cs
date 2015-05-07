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

        // Look-Up Tables
        int[]                   incBrightnessLUT, decBrightnessLUT;
        int[]                   incContrastLUT, decContrastLUT;
        int[]                   incGammaLUT, decGammaLUT;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imgList = new List<Image<Bgr, byte>>();
            imgBtnList = new List<Button>();

            // Initialize Look-Up Tables
            incBrightnessLUT = new int[256];
            decBrightnessLUT = new int[256];
            incContrastLUT = new int[256];
            decContrastLUT = new int[256];
            incGammaLUT = new int[256];
            decGammaLUT = new int[256];

            var tmpOffset = 30;
            for (var i = 0; i < 256; ++i)
            {
                if (i + tmpOffset <= 255)
                    incBrightnessLUT[i] = i + tmpOffset;
                else
                    incBrightnessLUT[i] = 255;
            }

            for (var i = 0; i < 256; ++i)
            {
                if (i - tmpOffset >= 0)
                    decBrightnessLUT[i] = i - tmpOffset;
                else
                    decBrightnessLUT[i] = 0;  
            }

            var tmpSlope = 1.2;
            for (var i = 0; i < 256; ++i)
            {
                var j = (int)(tmpSlope * (i - 127) + 127);
                if (j < 0)
                    incContrastLUT[i] = 0;
                else if (j > 255)
                    incContrastLUT[i] = 255;
                else
                    incContrastLUT[i] = j;
            }

            tmpSlope = 0.8;
            for (var i = 0; i < 256; ++i)
            {
                var j = (int)(tmpSlope * (i - 127) + 127);
                if (j < 0)
                    decContrastLUT[i] = 0;
                else if (j > 255)
                    decContrastLUT[i] = 255;
                else
                    decContrastLUT[i] = j;
            }

            var gamma = 1.2;
            for (var i = 0; i < 256; ++i)
            {
                incGammaLUT[i] = (int)(255 * Math.Pow(i / 255.0, 1 / gamma));
            }

            gamma = 0.8;
            for (var i = 0; i < 256; ++i)
            {
                decGammaLUT[i] = (int)(255 * Math.Pow(i / 255.0, 1 / gamma));
            }
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

        private void doLUT(int[] myLut)
        {
            Image<Bgr, byte> currImg = imgList[currImgId];
            Console.WriteLine(String.Format("Do LUT: ImgNo.{0}, RxC: {1}x{2}", currImgId, currImg.Height, currImg.Width));

            for (var k = 0; k < 3; ++k)
                for (var r = 0; r < currImg.Height; ++r)
                    for (var c = 0; c < currImg.Width; ++c)
                        currImg.Data[r, c, k] = (byte)myLut[(int)currImg.Data[r, c, k]];

            pictureBoxImg.Image = currImg.ToBitmap();
            //imgList[currImg] = currImg;
        }

        /*** Point Processing: Brightness Increse/Decrese ***/

        private void buttonBrightnessInc_Click(object sender, EventArgs e)
        {
            doLUT(incBrightnessLUT);
        }

        private void buttonBrightnessDec_Click(object sender, EventArgs e)
        {

        }

        /*** Point Processing: Contrast Increse/Decrese ***/

        private void buttonContrastInc_Click(object sender, EventArgs e)
        {

        }

        private void buttonContrastDec_Click(object sender, EventArgs e)
        {

        }

        /*** Point Processing: Gamma Increse/Decrese ***/

        private void buttonGammaInc_Click(object sender, EventArgs e)
        {

        }

        private void buttonGammaDec_Click(object sender, EventArgs e)
        {

        }

        /*** Point Processing: RGB Channel Increse/Decrese ***/

        private void buttonRedInc_Click(object sender, EventArgs e)
        {

        }

        private void buttonRedDec_Click(object sender, EventArgs e)
        {

        }

        private void buttonGreenInc_Click(object sender, EventArgs e)
        {

        }

        private void buttonGreenDec_Click(object sender, EventArgs e)
        {

        }

        private void buttonBlueInc_Click(object sender, EventArgs e)
        {

        }

        private void buttonBlueDec_Click(object sender, EventArgs e)
        {

        }
    }
}
