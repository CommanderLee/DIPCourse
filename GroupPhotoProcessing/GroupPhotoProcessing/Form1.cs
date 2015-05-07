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

// Math.Net Numerics Library.
// Using 'LA.Matrix' to avoid conflit with Emgu.CV.Matrix
using MathNet.Numerics;
using LA = MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace GroupPhotoProcessing
{
    public partial class Form1 : Form
    {
        enum ImageTypes { Group, Single };
        enum Channels { Blue, Green, Red, All };

        // 1st Tab: List of images, their control buttons, and their types
        List<Image<Bgr, byte>>  imgList;
        List<Button>            imgBtnList;
        List<ImageTypes>        imgTypeList;

        int                     currImgId;
        ImageTypes              currType;

        // Look-Up Tables
        int[]                   incBrightnessLUT, decBrightnessLUT;
        int[]                   incContrastLUT, decContrastLUT;
        int[]                   incGammaLUT, decGammaLUT;

        // 2nd Tab: List of Group/Single Buttons
        List<Button>            imgGroupBtnList, imgSingleBtnList;

        int                     currImgIdFusion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1st Tab
            imgList = new List<Image<Bgr, byte>>();
            imgBtnList = new List<Button>();
            imgTypeList = new List<ImageTypes>();

            initLUT();

            currImgId = -1;
            currType = ImageTypes.Group;
            buttonImgType.Text = currType.ToString();

            // 2nd Tab
            imgGroupBtnList = new List<Button>();
            imgSingleBtnList = new List<Button>();

            currImgIdFusion = -1;
        }

        /*** 1st Tab: Point Processing ***/

        /// <summary>
        /// Initialize Look-Up Tables
        /// </summary>
        private void initLUT()
        {
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
                // Load and show
                Image<Bgr, byte> tmpImg = new Image<Bgr, byte>(openFile.FileName);
                pictureBoxImg.Image = tmpImg.ToBitmap();
                imgList.Add(tmpImg);
                currImgId = imgList.Count - 1;
                Console.WriteLine("Button Id: " + currImgId);

                // Show the imgName on status bar.
                string shortImgName = openFile.FileName.Substring(openFile.FileName.Length - 7, 4);
                labelStatus.Text = currImgId + ":" + shortImgName;

                // Add a button
                // Magic numbers: Fixed button location/size in the 'panelImageNames'
                Button tmpBtn = new Button();
                tmpBtn.Text = labelStatus.Text;
                tmpBtn.Name = currImgId.ToString();
                tmpBtn.Click += imgBtns_Click;
                tmpBtn.Size = new Size(90, 45);
                tmpBtn.Location = new Point(90 * currImgId, 0);

                panelImgNames.Controls.Add(tmpBtn);
                imgBtnList.Add(tmpBtn);
                imgTypeList.Add(currType);
            }
        }

        /// <summary>
        /// Select an image by clicking corresponding button on the 1st Tab (Point Processing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgBtns_Click(object sender, EventArgs e)
        {
            int btnId = Convert.ToInt32(((Button)sender).Name);
            Console.WriteLine("Click on Button No." + btnId);
            if (btnId >= 0 && btnId < imgList.Count)
            {
                pictureBoxImg.Image = imgList[btnId].ToBitmap();
                currImgId = btnId;
                labelStatus.Text = imgBtnList[btnId].Text;
                currType = imgTypeList[btnId];
                buttonImgType.Text = currType.ToString();
            }
            else
            {
                Console.WriteLine("Error: Image Button Index out of range.");
            }
        }

        /// <summary>
        /// Do the Look-Up Table mapping.
        /// </summary>
        /// <param name="myLut"></param>
        private void doLUT(int[] myLut, Channels ch)
        {
            Image<Bgr, byte> currImg = imgList[currImgId];
            Console.WriteLine(String.Format("Do LUT: ImgNo.{0}, RxC: {1}x{2}, Channel:{3}", 
                currImgId, currImg.Height, currImg.Width, ch));

            var chSt = 0;
            var chEd = 0;
            if (ch == Channels.All)
            {
                chSt = 0;
                chEd = 2;
            }
            else
            {
                chSt = chEd = (int)ch;
            }

            // Do the Parallel For-Loop
            System.Threading.Tasks.Parallel.For(0, currImg.Height, (r) =>
                {
                    System.Threading.Tasks.Parallel.For(0, currImg.Width, (c) =>
                        {
                            for (var k = chSt; k <= chEd; ++k)
                                currImg.Data[r, c, k] = (byte)myLut[(int)currImg.Data[r, c, k]];
                        });
                });

            // Do the Sequential version
            //for (var k = 0; k < 3; ++k)
            //    for (var r = 0; r < currImg.Height; ++r)
            //        for (var c = 0; c < currImg.Width; ++c)
            //            currImg.Data[r, c, k] = (byte)myLut[(int)currImg.Data[r, c, k]];

            pictureBoxImg.Image = currImg.ToBitmap();
        }

        /*** Point Processing: Brightness Increse/Decrese ***/

        private void buttonBrightnessInc_Click(object sender, EventArgs e)
        {
            doLUT(incBrightnessLUT, Channels.All);
        }

        private void buttonBrightnessDec_Click(object sender, EventArgs e)
        {
            doLUT(decBrightnessLUT, Channels.All);
        }

        /*** Point Processing: Contrast Increse/Decrese ***/

        private void buttonContrastInc_Click(object sender, EventArgs e)
        {
            doLUT(incContrastLUT, Channels.All);
        }

        private void buttonContrastDec_Click(object sender, EventArgs e)
        {
            doLUT(decContrastLUT, Channels.All);
        }

        /*** Point Processing: Gamma Increse/Decrese ***/

        private void buttonGammaInc_Click(object sender, EventArgs e)
        {
            doLUT(incGammaLUT, Channels.All);
        }

        private void buttonGammaDec_Click(object sender, EventArgs e)
        {
            doLUT(decGammaLUT, Channels.All);
        }

        /*** Point Processing: RGB Channel Increse/Decrese ***/

        private void buttonRedInc_Click(object sender, EventArgs e)
        {
            doLUT(incBrightnessLUT, Channels.Red);
        }

        private void buttonRedDec_Click(object sender, EventArgs e)
        {
            doLUT(decBrightnessLUT, Channels.Red);
        }

        private void buttonGreenInc_Click(object sender, EventArgs e)
        {
            doLUT(incBrightnessLUT, Channels.Green);
        }

        private void buttonGreenDec_Click(object sender, EventArgs e)
        {
            doLUT(decBrightnessLUT, Channels.Green);
        }

        private void buttonBlueInc_Click(object sender, EventArgs e)
        {
            doLUT(incBrightnessLUT, Channels.Blue);
        }

        private void buttonBlueDec_Click(object sender, EventArgs e)
        {
            doLUT(decBrightnessLUT, Channels.Blue);
        }

        /// <summary>
        /// Change current image type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImgType_Click(object sender, EventArgs e)
        {
            if (currType == ImageTypes.Group)
                currType = ImageTypes.Single;
            else
                currType = ImageTypes.Group;

            imgTypeList[currImgId] = currType;
            buttonImgType.Text = currType.ToString();
        }

        /*** 2nd Tab: Image Fusion ***/

        private void buttonFusionPreparing_Click(object sender, EventArgs e)
        {
            // Clear
            foreach (Button btn in imgGroupBtnList)
                panelGroupImgNames.Controls.Remove(btn);
            foreach (Button btn in imgSingleBtnList)
                panelSingleImgNames.Controls.Remove(btn);
            imgGroupBtnList.Clear();
            imgSingleBtnList.Clear();

            for (var i = 0; i < imgBtnList.Count; ++i)
            {
                Panel parentPanel;
                List<Button> parentList;
                if (imgTypeList[i] == ImageTypes.Group)
                {
                    parentPanel = panelGroupImgNames;
                    parentList = imgGroupBtnList;
                }
                else
                {
                    parentPanel = panelSingleImgNames;
                    parentList = imgSingleBtnList;
                }

                int btnId = parentList.Count;
                // Add a button
                // Magic numbers: Fixed button location/size in the 'panelGroup(Single)ImgNames'
                Button tmpBtn = new Button();
                tmpBtn.Text = imgBtnList[i].Text;
                tmpBtn.Name = imgBtnList[i].Name;
                tmpBtn.Click += imgFusionBtns_Click;
                tmpBtn.Size = new Size(90, 45);
                tmpBtn.Location = new Point(90 * btnId + 160, 0);

                parentPanel.Controls.Add(tmpBtn);
                parentList.Add(tmpBtn);
            }
        }

        /// <summary>
        /// Select an image by clicking corresponding button on the 2nd Tab (Image Fusion)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgFusionBtns_Click(object sender, EventArgs e)
        {
            int btnId = Convert.ToInt32(((Button)sender).Name);
            Console.WriteLine("Click on Button No." + btnId);
            if (btnId >= 0 && btnId < imgList.Count)
            {
                pictureBoxImgFusion.Image = imgList[btnId].ToBitmap();
                currImgIdFusion = btnId;
                labelStatusFusion.Text = imgBtnList[btnId].Text;
            }
            else
            {
                Console.WriteLine("Error: Image Button Index out of range.");
            }
        }

        /// <summary>
        /// Draw Boundary (Rectangular) on the image. Log and paint to Red
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDrawBoundary_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clear Boundary of the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearBoundary_Click(object sender, EventArgs e)
        {

        }
    }
}
