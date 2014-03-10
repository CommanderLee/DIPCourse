#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <fstream>
#include <string>
#include <iostream>
#include <opencv/cv.h>
#include <opencv/highgui.h> 
using namespace std;

int main()
{

	IplImage* img = 0; 
	int height,width,step,channels;
	uchar *data;
	int i,j,k; 

	// load an image  
	img=cvLoadImage("G:\\Course\\Grade_Three_Spring\\DIP\\DIPCourse\\HW1\\pic\\pic1.bmp");
	if(!img){
		printf("Could not load image file.\n");
		exit(0);
	} 

	// get the image data
	height    = img->height;
	width     = img->width;
	//step      = img->widthStep;
	//channels  = img->nChannels;
	//data      = (uchar *)img->imageData;
	printf("Processing a %dx%d image.\n",height,width);

	//build File to save pixel value
	ofstream outFile_B;
	ofstream outFile_G;
	ofstream outFile_R;
	outFile_B.open("out_B.txt");
	outFile_G.open("out_G.txt");
	outFile_R.open("out_R.txt");

	//get the pixel value
	CvScalar s;
	for(i=0;i<height;i++) //i 代表 y 轴
	{
		for(j=0;j<width;j++) //j 代表 x轴
		{
			s=cvGet2D(img,i,j); // get the (j,i) pixel value

			outFile_B<<s.val[0]<<" ";
			outFile_G<<s.val[1]<<" ";
			outFile_R<<s.val[2]<<" "; 
		}
		outFile_B<<endl;
		outFile_G<<endl;
		outFile_R<<endl;
	}
	return 0; 
}