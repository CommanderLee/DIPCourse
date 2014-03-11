#include <iostream>
#include <opencv/cv.h>
#include <opencv/highgui.h> 
#include "PointProcessing.h"
using namespace std;
using namespace cv;

int main() 
{
	IplImage *img1 = 0, *img2 = 0; 

	// load an image  
	img1 = cvLoadImage("pic1.bmp");
	if (!img1) 
	{
		printf("Could not load image file.\n");
		exit(0);
	} 
	cvShowImage("img1", img1);
	cvWaitKey(0);
	
	// increase brightness
	img2 = cvCreateImage(cvGetSize(img1), img1->depth, img1->nChannels);
	cvCopy(img1, img2, NULL);

	printf("Increase Brightness.\n");
	PointProcessing pps(img2, "img_Inc_Bright.bmp", new LinearBrightness(50));
	pps.processing();

	// decrease brightness
	img2 = cvCreateImage(cvGetSize(img1), img1->depth, img1->nChannels);
	cvCopy(img1, img2, NULL);

	printf("Decrease Brightness.\n");
	pps.setParam(img2, "img_Dec_Bright.bmp", new LinearBrightness(-50));
	pps.processing();

	cvDestroyWindow("img1");
	cvReleaseImage(&img1);
	return 0; 
}