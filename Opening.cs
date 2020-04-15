﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    class Opening : MathMorphologyFilter
    {
        public Opening()
        {
            kernel = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            radius = kernel.GetLength(0) / 2;
        }

        public Opening(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filters filter = new Erosion();

            sourceImage = filter.processImage(sourceImage, worker);

            return base.processImage(sourceImage, worker);
        }
    }
}
