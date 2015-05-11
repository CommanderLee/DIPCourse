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
using Emgu.CV.Features2D;

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

        // Modified images
        List<Image<Bgr, byte>>  imgModifiedList;

        List<Point>             clickList;

        // The images which we are working on
        Image<Bgr, byte>        srcImg, tarImg, zoomSrcImg;

        // The user's specified center point, and top-left point
        int                     tarCenterX, tarCenterY;
        int                     tarTopLeftX, tarTopLeftY;

        // Mark the point Id. -1:boundary, [0,..):interior points
        int[,]                  pointId;

        int                     currImgIdFusion;

        // 3rd Tab: Image Stitching
        List<Image<Bgr, byte>>  imgStitchList;
        List<Button>            imgStitchBtnList;

        int                     currImgIdStitch;

        // Constants used in the Auto-Stitching algorithm
        const double            SIFT_FEAT_DIST_THRESHOLD = 0.49;
        const int               RANSAC_INIT_SET_SIZE = 4;
        const int               RANSAC_REPROJ_THRESHOLD = 3;

        // Homography matrix
        List<HomographyMatrix>  hMatList;

        // Painting
        Graphics                matchGraph;
        Pen                     matchPen, inlierPen;

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
            initFusionTab();

            // 3rd Tab
            initStitchTab();
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

        /// <summary>
        /// Initialize the UI/Data of Image Fusion Tab(2nd Tab)
        /// </summary>
        private void initFusionTab()
        {
            imgModifiedList = new List<Image<Bgr, byte>>();
            imgGroupBtnList = new List<Button>();
            imgSingleBtnList = new List<Button>();
            clickList = new List<Point>();
            srcImg = null;
            tarImg = null;
            zoomSrcImg = null;
            currImgIdFusion = -1;
        }

        private void buttonFusionPreparing_Click(object sender, EventArgs e)
        {
            // Clear
            foreach (Button btn in imgGroupBtnList)
                panelGroupImgNames.Controls.Remove(btn);
            foreach (Button btn in imgSingleBtnList)
                panelSingleImgNames.Controls.Remove(btn);

            initFusionTab();

            pictureBoxImgFusion.Image = null;

            for (var i = 0; i < imgBtnList.Count; ++i)
            {
                // Copy image
                imgModifiedList.Add(imgList[i].Copy());

                // Copy buttons
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

                int localBtnId = parentList.Count;
                // Add a button
                // Magic numbers: Fixed button location/size in the 'panelGroup(Single)ImgNames'
                Button tmpBtn = new Button();
                tmpBtn.Text = imgBtnList[i].Text;
                tmpBtn.Name = imgBtnList[i].Name;
                tmpBtn.Click += imgFusionBtns_Click;
                tmpBtn.Size = new Size(90, 45);
                tmpBtn.Location = new Point(90 * localBtnId + 160, 0);

                parentPanel.Controls.Add(tmpBtn);
                parentList.Add(tmpBtn);
            }
        }

        /// <summary>
        /// Select an image by clicking corresponding button on the 2nd Tab (Image Fusion)
        /// Show the modified one, and clear the clickLists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgFusionBtns_Click(object sender, EventArgs e)
        {
            int globalBtnId = Convert.ToInt32(((Button)sender).Name);
            Console.WriteLine("Click on Button No." + globalBtnId);
            if (globalBtnId >= 0 && globalBtnId < imgList.Count)
            {
                pictureBoxImgFusion.Image = imgModifiedList[globalBtnId].ToBitmap();
                currImgIdFusion = globalBtnId;
                labelStatusFusion.Text = imgBtnList[globalBtnId].Text;
                clickList.Clear();
            }
            else
            {
                Console.WriteLine("Error: Image Button Index out of range.");
            }
        }

        /// <summary>
        /// Clear Boundary of the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearBoundary_Click(object sender, EventArgs e)
        {
            if (currImgId >= 0 && imgModifiedList.Count > 0)
            {
                imgModifiedList[currImgIdFusion] = imgList[currImgIdFusion].Copy();
                clickList.Clear();
                pictureBoxImgFusion.Image = imgModifiedList[currImgIdFusion].ToBitmap();
            }
        }

        /// <summary>
        /// Just show the raw result of image cloning.
        /// Put a zoomed source image on the target image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowImg_Click(object sender, EventArgs e)
        {
            if (srcImg != null && tarImg != null)
            {
                // Zoom the source rectangular to the target rectangular
                double zoomScale = Math.Min((double)tarImg.Width / srcImg.Width, (double)tarImg.Height / srcImg.Height);
                Console.WriteLine("Zoom scale:" + zoomScale);
                zoomSrcImg = srcImg.Resize(zoomScale, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

                // Assume that the user is currently watching the target image page
                // That is, the currImgIdFusion = target image id
                tarTopLeftX = tarCenterX - zoomSrcImg.Height / 2;
                tarTopLeftY = tarCenterY - zoomSrcImg.Width / 2;
                for (var r = 0; r < zoomSrcImg.Height; ++r)
                    for (var c = 0; c < zoomSrcImg.Width; ++c)
                        imgModifiedList[currImgIdFusion][r + tarTopLeftX, c + tarTopLeftY] = zoomSrcImg[r, c];

                pictureBoxImgFusion.Image = imgModifiedList[currImgIdFusion].ToBitmap();
            }
        }

        /// <summary>
        /// Start Image Fusion
        /// Based on Poisson Image Editing. P Perez et. al. SIGGRAPH 2003
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImageFusion_Click(object sender, EventArgs e)
        {
            if (zoomSrcImg != null && tarImg != null)
            {
                DateTime startTime = DateTime.Now;
                // Set the boundary value of zoomSrcImg
                pointId = new int [zoomSrcImg.Height, zoomSrcImg.Width];
                // +----------+
                // +          +
                // +----------+
                for (var r = 0; r < zoomSrcImg.Height; ++r)
                {
                    pointId[r, 0] = -1;
                    pointId[r, zoomSrcImg.Width - 1] = -1;
                }
                // -++++++++++-
                // -          -
                // -++++++++++-
                for (var c = 1; c < zoomSrcImg.Width - 1; ++c)
                {
                    pointId[0, c] = -1;
                    pointId[zoomSrcImg.Height - 1, c] = -1;
                }
                
                // Set mapping between point Id and the position
                List<Point> contentList = new List<Point>();
                for (var r = 1; r < zoomSrcImg.Height - 1; ++r)
                    for (var c = 1; c < zoomSrcImg.Width - 1; ++c)
                    {
                        pointId[r, c] = contentList.Count;
                        contentList.Add(new Point(r, c));
                    }
                Console.WriteLine("Mark every points with -1, 0, ...Time:" + DateTime.Now.Subtract(startTime).TotalSeconds);

                // Solve AX=B problem using solutions from the paper: Poisson Image Editing.
                int contentNum = contentList.Count;
                // To solve AX=B, get matrix A and B first
                //var matA = LA.Matrix<double>.Build.Sparse(contentNum, contentNum);
                //var matB = LA.Double.Vector.Build.Dense(contentNum);

                // top, right, bottom, left. In order to use for-loop.
                int[] dx = new int[] {-1, 0, 1, 0};
                int[] dy = new int[] { 0, 1, 0, -1 };

                Image<Bgr, byte> resultImg = imgList[currImgIdFusion].Copy();
                //int[,] contentColor = new int[3, contentNum];
                // Parallelize color channel B, G, R
                System.Threading.Tasks.Parallel.For(0, 3, (k) =>
                //for (var k = 0; k <= 2; ++k)
                {
                    Console.WriteLine("Generate Matrix No. " + k);

                    // Set matrix A & B to zero
                    var matA = LA.Matrix<double>.Build.Sparse(contentNum, contentNum);
                    var matB = LA.Double.Vector.Build.Dense(contentNum);
                    //matA.Clear();
                    //matB.Clear();

                    // Point P's neighbours.
                    List<Point> Np = new List<Point>();

                    // Generate matrix A & B
                    for (var id = 0; id < contentNum; ++id)
                    {
                        // For each point, use equation No.7 & No.8 in the paper
                        // Which means one row in the matrix

                        // Matrix A
                        
                        Np.Clear();
                        // Old Point P: position in the zoomSrcImg. New Point P: position in the tarImg
                        Point oldP = contentList[id];
                        Point newP = new Point(oldP.X + tarTopLeftX, oldP.Y + tarTopLeftY);
                        for (var i = 0; i < 4; ++i)
                        {
                            // New Point Q: P's neighbour in the WHOLE target image
                            Point newQ = new Point(newP.X + dx[i], newP.Y + dy[i]);
                            if (newQ.X >= 0 && newQ.X < resultImg.Height && newQ.Y >= 0 && newQ.Y < resultImg.Width)
                            {
                                // Point Q is inside the area Omiga
                                Np.Add(newQ);
                            }
                        }
                        matA.At(id, id, Np.Count);

                        foreach (Point newQ in Np)
                        {
                            // Check Point Id of Old Q
                            int qID = pointId[newQ.X - tarTopLeftX, newQ.Y - tarTopLeftY];
                            // Old Q is inside Omiga
                            if (qID >= 0)
                            {
                                matA.At(id, qID, -1);
                            }
                        }

                        // Matrix B

                        double Bi = 0;
                        foreach (Point newQ in Np)
                        {
                            // Check Point Id of Old Q
                            int qID = pointId[newQ.X - tarTopLeftX, newQ.Y - tarTopLeftY];
                            // Q is on the boundry
                            if (qID == -1)
                            {
                                Bi += resultImg.Data[newQ.X, newQ.Y, k];
                            }

                            Point oldQ = new Point(newQ.X - tarTopLeftX, newQ.Y - tarTopLeftY);
                            Bi += zoomSrcImg.Data[oldP.X, oldP.Y, k] - zoomSrcImg.Data[oldQ.X, oldQ.Y, k];
                        }
                        matB.At(id, Bi);
                    }//);
                    Console.WriteLine("Generate Matrix Done. Time:" + DateTime.Now.Subtract(startTime).TotalSeconds);

                    // Solve the sparse linear equation using BiCgStab (Bi-Conjugate Gradient Stabilized)
                    var fp = LA.Double.Vector.Build.Dense(contentNum);
                    BiCgStab solver = new BiCgStab();

                    // Choose stop criterias
                    // Learn about stop criteria from: wo80, http://mathnetnumerics.codeplex.com/discussions/404689
                    var stopCriterias = new List<IIterationStopCriterion<double>>()
                    {
                        new ResidualStopCriterion<double>(1e-5),
                        new IterationCountStopCriterion<double>(1000),
                        new DivergenceStopCriterion<double>(),
                        new FailureStopCriterion<double>()
                    };

                    solver.Solve(matA, matB, fp, new Iterator<double>(stopCriterias), new DiagonalPreconditioner());
                    Console.WriteLine("Equation Solved. Time:" + DateTime.Now.Subtract(startTime).TotalSeconds);
                    // Console.WriteLine(fp);

                    // Set the color
                    for (var id = 0; id < contentNum; ++id)
                    {
                        int color = (int)fp.At(id);
                        if (color < 0)
                            color = 0;
                        if (color > 255)
                            color = 255;
                        //contentColor[k, id] = color;
                        resultImg.Data[contentList[id].X + tarTopLeftX, contentList[id].Y + tarTopLeftY, k] = (Byte)color;
                    }
                });

                //Paint
                //for (var id = 0; id < contentNum; ++id)
                //{
                //    resultImg[contentList[id].X + tarTopLeftX, contentList[id].Y + tarTopLeftY] = new Bgr(
                //        contentColor[0, id], contentColor[1, id], contentColor[2, id]);
                //}
                imgModifiedList[currImgIdFusion] = resultImg.Copy();
                pictureBoxImgFusion.Image = resultImg.ToBitmap();
                Console.WriteLine("Painting Finished. Time:" + DateTime.Now.Subtract(startTime).TotalSeconds);
            }
        }

        /// <summary>
        /// Draw Boundary - Click on the two corners, for example, top-left then bottom-right corner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxImgFusion_Click(object sender, EventArgs e)
        {
            var mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null && currImgIdFusion >= 0)
            {
                // X: column number, Y: row number.
                Console.WriteLine(String.Format("Click on X:{0}, Y:{1}", mouseEvent.X, mouseEvent.Y));

                // If we still need more points
                if (clickList.Count < 2)
                {
                    // Inverse the mouse event order to fit the OpenCV order of index.
                    // So now x: row number, y: column number
                    Point myPoint = new Point(mouseEvent.Y, mouseEvent.X);
                    clickList.Add(myPoint);

                    // Paint that point as red
                    imgModifiedList[currImgIdFusion][myPoint.X, myPoint.Y] = new Bgr(Color.Red);

                    // Mark the Boundary
                    if (clickList.Count == 2)
                    {
                        // Get Top-Left and Bottom-Right corner even if the user clicks on other corners
                        Point pntTopLeft = new Point(Math.Min(clickList[0].X, clickList[1].X), 
                            Math.Min(clickList[0].Y, clickList[1].Y));
                        Point pntBottomRight = new Point(Math.Max(clickList[0].X, clickList[1].X),
                            Math.Max(clickList[0].Y, clickList[1].Y));

                        int selHeight = pntBottomRight.X - pntTopLeft.X + 1;
                        int selWidth = pntBottomRight.Y - pntTopLeft.Y + 1;

                        // Get the selected image
                        Image<Bgr, byte> selectedImg = new Image<Bgr, byte>(selWidth, selHeight);
                        for (var r = 0; r < selHeight; ++r)
                            for (var c = 0; c < selWidth; ++c)
                                selectedImg[r, c] = imgList[currImgIdFusion][r + pntTopLeft.X, c + pntTopLeft.Y];

                        if (imgTypeList[currImgIdFusion] == ImageTypes.Group)
                        {
                            tarImg = selectedImg;
                            tarCenterX = (pntTopLeft.X + pntBottomRight.X) / 2;
                            tarCenterY = (pntTopLeft.Y + pntBottomRight.Y) / 2;
                        }
                        else
                            srcImg = selectedImg;

                        // Paint the boundary
                        // +----------+
                        // +          +
                        // +----------+
                        for (var r = pntTopLeft.X; r <= pntBottomRight.X; ++r)
                        {
                            //boundryList.Add(new Point(i, pointA.Y));
                            //boundryList.Add(new Point(i, pointB.Y));

                            imgModifiedList[currImgIdFusion][r, pntTopLeft.Y] = new Bgr(Color.Red);
                            imgModifiedList[currImgIdFusion][r, pntBottomRight.Y] = new Bgr(Color.Red);

                            //pointID[i, pointA.Y] = -1;
                            //pointID[i, pointB.Y] = -1;
                        }
                        // -++++++++++-
                        // -          -
                        // -++++++++++-
                        for (var c = pntTopLeft.Y + 1; c < pntBottomRight.Y; ++c)
                        {
                            //boundryList.Add(new Point(pointA.X, j));
                            //boundryList.Add(new Point(pointB.X, j));

                            imgModifiedList[currImgIdFusion][pntTopLeft.X, c] = new Bgr(Color.Red);
                            imgModifiedList[currImgIdFusion][pntBottomRight.X, c] = new Bgr(Color.Red);

                            //pointID[pointA.X, j] = -1;
                            //pointID[pointB.X, j] = -1;
                        }


                    }

                    pictureBoxImgFusion.Image = imgModifiedList[currImgIdFusion].ToBitmap();
                }
            }
        }

        /*** Auto-Stitching ***/

        /// <summary>
        /// Initialize the UI/Data of Image Stitch Tab(3rd Tab)
        /// </summary>
        private void initStitchTab()
        {
            if (imgModifiedList.Count > 0)
                imgStitchList = imgModifiedList;
            else
                imgStitchList = imgList;

            imgStitchBtnList = new List<Button>();
            imgStitchList = new List<Image<Bgr, byte>>();
            hMatList = new List<HomographyMatrix>();

            // Painting
            matchGraph = pictureBoxImgStitch.CreateGraphics();
            matchPen = new Pen(Color.Red, 1);
            inlierPen = new Pen(Color.Blue, 2);
        }

        private void buttonStitchPreparing_Click(object sender, EventArgs e)
        {
            // Clear
            foreach (Button btn in imgStitchBtnList)
                panelStitchImgNames.Controls.Remove(btn);

            initStitchTab();

            // Generate group photos
            int maxHeight = 0, sumWidth = 0;
            for (var i = 0; i < imgBtnList.Count; ++i)
            {
                if (imgTypeList[i] == ImageTypes.Group)
                {
                    // Copy image
                    imgStitchList.Add(imgModifiedList[i].Copy());
                    if (imgModifiedList[i].Height > maxHeight)
                        maxHeight = imgModifiedList[i].Height;
                    sumWidth += imgModifiedList[i].Width;

                    int localBtnId = imgStitchBtnList.Count;
                    // Add a button
                    // Magic numbers: Fixed button location/size in the 'panelStitchImgNames'
                    Button tmpBtn = new Button();
                    tmpBtn.Text = imgBtnList[i].Text;
                    tmpBtn.Name = imgBtnList[i].Name;
                    tmpBtn.Click += imgStitchBtns_Click;
                    tmpBtn.Size = new Size(90, 45);
                    tmpBtn.Location = new Point(90 * localBtnId + 160, 0);

                    panelStitchImgNames.Controls.Add(tmpBtn);
                    imgStitchBtnList.Add(tmpBtn);
                }
            }

            // Paint horizontally
            Image<Bgr, byte> totalImage = new Image<Bgr, byte>(sumWidth, maxHeight);
            sumWidth = 0;
            foreach (Image<Bgr, byte> currImg in imgStitchList)
            {
                for (var r = 0; r < currImg.Height; ++r)
                    for (var c = 0; c < currImg.Width; ++c)
                        totalImage[r, sumWidth + c] = currImg[r, c];
                sumWidth += currImg.Width;
            }
            pictureBoxImgStitch.Image = totalImage.ToBitmap();
        }

        /// <summary>
        /// Select an image by clicking corresponding button on the 3rd Tab (Image Stitch)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgStitchBtns_Click(object sender, EventArgs e)
        {
            int globalBtnId = Convert.ToInt32(((Button)sender).Name);
            Console.WriteLine("Click on Button No." + globalBtnId);
            if (globalBtnId >= 0 && globalBtnId < imgModifiedList.Count)
            {
                pictureBoxImgStitch.Image = imgModifiedList[globalBtnId].ToBitmap();
                currImgIdStitch = globalBtnId;
                labelStatusStitch.Text = imgBtnList[globalBtnId].Text;
            }
            else
            {
                Console.WriteLine("Error: Image Button Index out of range.");
            }
        }

        private double getEuclidDistance(float[] f1, float[] f2)
        {
            double subSum = 0;
            for (var i = 0; i < f1.Length; ++i)
            {
                subSum += Math.Pow(f1[i] - f2[i], 2);
            }
            return Math.Sqrt(subSum);
        }

        /// <summary>
        /// Start matching period
        /// Based on Automatic Panoramic Image Stitching using Invariant Features. M Brown et. al. IJCV 2007
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImageMatch_Click(object sender, EventArgs e)
        {
            if (imgStitchList.Count >= 2)
            {
                // Calculate SIFT features
                // Get SIFT from srcImg and dstImg
                SIFTDetector sift = new SIFTDetector();
                List<ImageFeature<float>[]> features = new List<ImageFeature<float>[]>();
                for (var i = 0; i < imgStitchList.Count; ++i)
                {
                    Image<Gray, byte> grayImg = new Image<Gray, byte>(imgStitchList[i].ToBitmap());
                    features.Add(sift.DetectFeatures(grayImg, null));
                    Console.WriteLine(String.Format("Img No.{0}, Features: {1}", i, features[i].Length));
                }

                // Get matching pictures <srcId, dstId>, then generate an order
                // We assume that the images are in horizontal order
                hMatList.Clear();
                int sumWidth = 0;
                for (var srcId = 0; srcId + 1 < imgStitchList.Count; ++srcId)
                {
                    int dstId = srcId + 1;

                    ImageFeature<float>[] srcFeat = features[srcId];
                    ImageFeature<float>[] dstFeat = features[dstId];

                    int matchCount = 0;
                    List<PointF> srcPntList = new List<PointF>();
                    List<PointF> dstPntList = new List<PointF>();

                    for (var i = 0; i < srcFeat.Length; ++i)
                    {
                        // Calculate distance: Brute Force
                        double[] dist = new double[dstFeat.Length];
                        for (var j = 0; j < dstFeat.Length; ++j)
                        {
                            dist[j] = getEuclidDistance(srcFeat[i].Descriptor, dstFeat[j].Descriptor);
                        }

                        // Get 2-min distance points
                        int minIndex;
                        double minDist, minDist2;
                        if (dist[0] < dist[1])
                        {
                            minIndex = 0;
                            minDist = dist[0];
                            minDist2 = dist[1];
                        }
                        else
                        {
                            minIndex = 1;
                            minDist = dist[1];
                            minDist2 = dist[0];
                        }
                        for (var j = 2; j < dstFeat.Length; ++j)
                        {
                            if (dist[j] < minDist)
                            {
                                minIndex = j;
                                minDist2 = minDist;
                                minDist = dist[j];
                            }
                            else if (dist[j] < minDist2)
                            {
                                minDist2 = dist[j];
                            }
                        }

                        // If the distance is small enough. 
                        if (minDist / minDist2 < SIFT_FEAT_DIST_THRESHOLD)
                        {
                            PointF pi = srcFeat[i].KeyPoint.Point;
                            PointF pj = dstFeat[minIndex].KeyPoint.Point;
                            pi.X += sumWidth;
                            pj.X += sumWidth + imgStitchList[srcId].Width;
                            matchGraph.DrawLine(matchPen, pi, pj);
                            //rawMatchPairs.Add(new Tuple<int, int>(i, minIndex));
                            srcPntList.Add(pi);
                            dstPntList.Add(pj);
                            ++matchCount;
                        }
                    }
                    Console.WriteLine(String.Format("[{0}] <-> [{1}], {2} matching pairs.", srcId, dstId, matchCount));
                    sumWidth += imgStitchList[srcId].Width;

                    if (matchCount >= RANSAC_INIT_SET_SIZE)
                    {
                        // Use RANSAC (Ramdom Sample Consensus) as a filter
                        HomographyMatrix hMat = CameraCalibration.FindHomography(srcPntList.ToArray(), dstPntList.ToArray(),
                            Emgu.CV.CvEnum.HOMOGRAPHY_METHOD.RANSAC, RANSAC_REPROJ_THRESHOLD);
                        
                        if (hMat != null)
                        {
                            for (var r = 0; r < 3; ++r)
                            {
                                for (var c = 0; c < 3; ++c)
                                    Console.Write(hMat[r, c] + ", ");
                                Console.Write("\n");
                            }
                            hMatList.Add(hMat);

                            // Show inliers
                            for (var i = 0; i < srcPntList.Count; ++i)
                            {
                                // Calculate distance
                                Matrix<double> srcPntMat, dstProjMat;
                                double dstProjX, dstProjY;
                                double dist;
                                
                                srcPntMat = new Matrix<double>(3, 1);
                                srcPntMat[0, 0] = srcPntList[i].X;
                                srcPntMat[1, 0] = srcPntList[i].Y;
                                srcPntMat[2, 0] = 1;
                                
                                dstProjMat = hMat.Mul(srcPntMat);
                                dstProjX = dstProjMat[0, 0] / dstProjMat[2, 0];
                                dstProjY = dstProjMat[1, 0] / dstProjMat[2, 0];

                                dist = Math.Sqrt(Math.Pow(dstProjX - dstPntList[i].X, 2) + Math.Pow(dstProjY - dstPntList[i].Y, 2));
                                if (dist <= RANSAC_REPROJ_THRESHOLD)
                                {
                                    matchGraph.DrawLine(inlierPen, new Point((int)srcPntList[i].X, (int)srcPntList[i].Y),
                                        new Point((int)dstPntList[i].X, (int)dstPntList[i].Y));
                                }
                                Console.WriteLine("No." + i + " distance: " + dist);
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Main process of Image Stitching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImageStitch_Click(object sender, EventArgs e)
        {

        }


    }
}
