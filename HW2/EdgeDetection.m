function out = EdgeDetection(imgName, saveName, H1, H2, th)
% HW2 of DIP Course. Edge Detection.
% Param: the input file name, save file name, and two gradient operators

imgRGB = imread(imgName);
imgGray = rgb2gray(imgRGB);
[RowH ColumnH] = size(H1);
[Row Column] = size(imgGray);

oldMat = zeros(Row + RowH * 2, Column + ColumnH * 2);
oldMat(RowH + 1:RowH + Row, ColumnH + 1:ColumnH + Column) = imgGray;
newMat = zeros(Row, Column);

multiH1 = rot90(rot90(H1));
multiH2 = rot90(rot90(H2));
dt = floor(RowH / 2);

for r = 1:Row
    for c = 1:Column
        % oldMat(r - dt:r + dt, c - dt:c + dt, color)
        res = abs(sum(sum( multiH1 .* oldMat(r + RowH - dt:r + RowH + dt, c + ColumnH - dt:c + ColumnH + dt) ))) +...
            abs(sum(sum( multiH2 .* oldMat(r + RowH - dt:r + RowH + dt, c + ColumnH - dt:c + ColumnH + dt) )));
        if res / 2 > 255 * th
            newMat(r, c) = 255;
        else
            newMat(r, c) = 0;
        end
    end
end

imwrite(newMat, saveName);
figure;
imshow(newMat);
title(saveName);
out = newMat;
end