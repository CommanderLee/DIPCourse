#include <iostream>
#include <string>
#include <opencv/cv.h>
#include <opencv/highgui.h> 
using namespace std;
using namespace cv;

const int TABLE_SIZE = 300;
const int MAX_COLOR = 255;

class Transformer
{
public:
	virtual void transform(CvScalar& s) = 0;
	virtual string getName() = 0;
};

class LinearBrightness : public Transformer
{
	int LUTable[TABLE_SIZE];
	int bright;

public:
	LinearBrightness(int b);

	void transform(CvScalar& s);
	string getName();
};

class HistogramMatching : public Transformer
{
	int			LUTable[TABLE_SIZE][3];
	IplImage	*srcImg;
	IplImage	*targetImg;

public:
	HistogramMatching(IplImage *src, IplImage *tar);

	void transform(CvScalar& s);
	string getName();
};

class FogDealer : public Transformer
{
	int LUTable[TABLE_SIZE];
public:
	FogDealer();

	void transform(CvScalar& s);
	string getName();
};