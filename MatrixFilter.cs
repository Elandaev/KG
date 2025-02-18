﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap SourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for(int i=-radiusY; i < radiusY; i++)
            {
                for(int j=-radiusX; j <= radiusX; j++)
                {
                    int idX = Clamp(x + j, 0, SourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, SourceImage.Height - 1);
                    Color neighborColor = SourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[j + radiusX, i + radiusY];
                    resultG += neighborColor.G * kernel[j + radiusX, i + radiusY];
                    resultB += neighborColor.B * kernel[j + radiusX, i + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG,0,255),Clamp((int)resultB,0,255));
        }
    }
}
