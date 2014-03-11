#include <iostream>
#include <opencv/cv.h>
#include <opencv/highgui.h> 
#include "PointProcessing.h"
using namespace std;
using namespace cv;

int main() 
{
	IplImage *oldImg = 0, *newImg = 0; 

	// load an image  
	oldImg = cvLoadImage("pic1.bmp");
	if (!oldImg) 
	{
		printf("Could not load image file.\n");
		exit(0);
	} 
	cvShowImage("img1", oldImg);
	cvWaitKey(0);
	
	// increase brightness
	newImg = cvCreateImage(cvGetSize(oldImg), oldImg->depth, oldImg->nChannels);
	cvCopy(oldImg, newImg, NULL);

	printf("Increase Brightness.\n");
	PointProcessing pps(newImg, "img_Inc_Bright.bmp", new LinearBrightness(50));
	pps.processing();

	// decrease brightness
	newImg = cvCreateImage(cvGetSize(oldImg), oldImg->depth, oldImg->nChannels);
	cvCopy(oldImg, newImg, NULL);

	printf("Decrease Brightness.\n");
	pps.setParam(newImg, "img_Dec_Bright.bmp", new LinearBrightness(-50));
	pps.processing();
	
	// Histogram Matching
	IplImage *targetImg = 0;
	targetImg = cvLoadImage("pic2.bmp");
	if (!targetImg)
	{
		printf("Could not load image file.\n");
		exit(0);
	}
	cvShowImage("Target Image", targetImg);
	cvWaitKey(0);

	newImg = cvCreateImage(cvGetSize(oldImg), oldImg->depth, oldImg->nChannels);
	cvCopy(oldImg, newImg, NULL);

	printf("Histogram Matching.\n");
	pps.setParam(newImg, "img_Histogram_Matching.bmp", new HistogramMatching(oldImg, targetImg));
	pps.processing();

	cvDestroyWindow("Target Image");
	cvReleaseImage(&targetImg);
	
	// END
	cvDestroyWindow("img1");
	cvReleaseImage(&oldImg);
	return 0; 
}