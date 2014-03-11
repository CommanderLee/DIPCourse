#include "PointProcessing.h"

PointProcessing::PointProcessing(IplImage *i, string sName, Transformer *t)
{
	img = i;
	height = img->height;
	width = img->width;
	saveName = sName;
	tf = t;
}

void PointProcessing::setParam(IplImage *i, string sName, Transformer *t)
{
	img = i;
	height = img->height;
	width = img->width;
	saveName = sName;
	tf = t;
}

void PointProcessing::processing()
{
	//get the pixel value
	CvScalar s;
	for (int i = 0; i < height; ++i)
	{
		for (int j = 0; j < width; ++j)
		{
			s = cvGet2D(img, i, j);
			tf->transform(s);
			cvSet2D(img, i, j, s);
		}
	}
	cvSaveImage(saveName.c_str(), img, NULL);

	cvShowImage(tf->getName().c_str(), img);
	cvWaitKey(0);

	cvDestroyWindow(tf->getName().c_str());
	cvReleaseImage(&img);
}