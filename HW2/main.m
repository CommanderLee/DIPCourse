% The main file of HW2, of DIP Course.

imgRGB = imread(imgName);
imgGray = rgb2gray(imgRGB);
imshow(imgGray);
title('Original Image');
imwrite(imgGray, 'pic1_gray.bmp');

% Prewitt Operator
H1 = [-1 0 1; -1 0 1; -1 0 1];
H2 = [-1 -1 -1; 0 0 0; 1 1 1];
imgName = 'pic1.bmp';
saveName = 'pic1-edge-prewitt.bmp';
EdgeDetection(imgName, saveName, H1, H2, 0.07);

% Sobel Operator
H1 = [-1 0 1; -2 0 2; -1 0 1];
H2 = [-1 -2 -1; 0 0 0; 1 2 1];
imgName = 'pic1.bmp';
saveName = 'pic1-edge-sobel.bmp';
EdgeDetection(imgName, saveName, H1, H2, 0.07);

% Isotropic Sobel Operator
s2 = sqrt(2);
H1 = [-1 0 1; -s2 0 s2; -1 0 1];
H2 = [-1 -s2 -1; 0 0 0; 1 s2 1];
imgName = 'pic1.bmp';
saveName = 'pic1-edge-isotropic-sobel.bmp';
EdgeDetection(imgName, saveName, H1, H2, 0.07);

% Prewitt of MATLAB
imgPre = edge(imgGray, 'prewitt', 0.02);
figure;
imshow(imgPre);
title('Edge Detection by MATLAB: Prewitt');
imwrite(imgPre, 'pic1-edge-matlab-prewitt.bmp');