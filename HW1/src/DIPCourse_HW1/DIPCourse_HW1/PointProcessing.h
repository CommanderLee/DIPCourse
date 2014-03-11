#include <iostream>
#include <string>
#include <opencv/cv.h>
#include <opencv/highgui.h> 
#include "Transformer.h"
using namespace std;
using namespace cv;

class PointProcessing
{
	int			height;
	int			width;
	IplImage	*img;
	string		saveName;

	Transformer	*tf;

public:
	PointProcessing(IplImage *i, string sName, Transformer *t);

	void setParam(IplImage *i, string sName, Transformer *t);

	void processing();
};