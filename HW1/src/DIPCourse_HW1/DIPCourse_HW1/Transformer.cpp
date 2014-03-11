#include <sstream>
#include "Transformer.h"

using namespace std;

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
	return "LinearBrightness";
}