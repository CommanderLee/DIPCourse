#include <cmath>
#include "Transformer.h"

using namespace std;

// Linear Brightness
LinearBrightness::LinearBrightness(int b)
{
	bright = b;
	if (b > 0)
	{
		for (int i = 0; i <= MAX_COLOR; ++i)
		{
			LUTable[i] = min(MAX_COLOR, i + bright);
		}
	}
	else
	{
		for (int i = 0; i <= MAX_COLOR; ++i)
		{
			LUTable[i] = max(0, i + bright);
		}
	}
}

void LinearBrightness::transform(CvScalar& s)
{
	for (int k = 0; k < 3; ++k)
	{
		s.val[k] = LUTable[int(s.val[k])];
	}
}

string LinearBrightness::getName()
{
	return "Linear Brightness";
}

// Histogram Matching
HistogramMatching::HistogramMatching(IplImage *src, IplImage *tar)
{
	srcImg = src;
	targetImg = tar;

	CvScalar s;

	// Get p.d.f
	double srcPDF[TABLE_SIZE][3], tarPDF[TABLE_SIZE][3];
	for (int i = 0; i < TABLE_SIZE; ++i)
	{
		for (int k = 0; k < 3; ++k)
		{
			srcPDF[i][k] = tarPDF[i][k] = 0.0;
		}
	}
	double srcTemp, tarTemp;
	srcTemp = 1.0 / ((srcImg->height) * (srcImg->width));
	tarTemp = 1.0 / ((targetImg->height) * (targetImg->width));

	for (int i = 0; i < srcImg->height; ++i)
	{
		for (int j = 0; j < srcImg->width; ++j)
		{
			s = cvGet2D(srcImg, i, j);
			for (int k = 0; k < 3; ++k)
			{
				srcPDF[int(s.val[k])][k] += srcTemp;
			}
		}
	}

	for (int i = 0; i < targetImg->height; ++i)
	{
		for (int j = 0; j < targetImg->width; ++j)
		{
			s = cvGet2D(targetImg, i, j);
			for (int k = 0; k < 3; ++k)
			{
				tarPDF[int(s.val[k])][k] += tarTemp;
			}
		}
	}

	// Get C.D.F
	double srcCDF[TABLE_SIZE][3], tarCDF[TABLE_SIZE][3];
	for (int k = 0; k < 3; ++k)
	{
		srcCDF[0][k] = srcPDF[0][k];
		tarCDF[0][k] = tarPDF[0][k];
	}
	for (int i = 1; i <= MAX_COLOR; ++i)
	{
		for (int k = 0; k < 3; ++k)
		{
			srcCDF[i][k] = srcCDF[i - 1][k] + srcPDF[i][k];
			tarCDF[i][k] = tarCDF[i - 1][k] + tarPDF[i][k];
		}
	}

	// Initialize LUT
	int tarPos(0);
	for (int k = 0; k < 3; ++k)
	{
		tarPos = 0;
		for (int i = 0; i <= MAX_COLOR; ++i)
		{
			while (srcCDF[i][k] > tarCDF[tarPos][k] && tarPos < MAX_COLOR)
			{
				++tarPos;
			}
			LUTable[i][k] = tarPos;
		}
	}

}

void HistogramMatching::transform(CvScalar& s)
{
	for (int k = 0; k < 3; ++k)
	{
		s.val[k] = LUTable[int(s.val[k])][k];
	}
}

string HistogramMatching::getName()
{
	return "Histogram Matching";
}

// Fog Dealer
FogDealer::FogDealer()
{
	// Gamma Decrease
	double gamma = 0.7;
	for (int i = 0; i <= MAX_COLOR; ++i)
	{
		LUTable[i] = (int)(255 * (std::pow(i / 255.0, 1 / gamma)));
	}

	// Increase Contrast
	double k = 1.6;
	for (int i = 0; i <= MAX_COLOR; ++i)
	{
		LUTable[i] = max(0, (int)(k * (LUTable[i] - 127) + 127));
		LUTable[i] = min(LUTable[i], MAX_COLOR);
	}
}

void FogDealer::transform(CvScalar& s)
{
	for (int k = 0; k < 3; ++k)
	{
		s.val[k] = LUTable[int(s.val[k])];
	}
}

string FogDealer::getName()
{
	return "De-Fog";
}
