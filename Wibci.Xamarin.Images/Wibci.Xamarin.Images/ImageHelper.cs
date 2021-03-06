﻿using System;

namespace Wibci.Xamarin.Images
{
    public struct Dimension
    {
        public uint Height { get; set; }
        public uint Width { get; set; }
    }

    public static class ImageHelper
    {
        public static Dimension Resize(this Dimension originalDimension, Dimension newDimensions, bool upscale = false)
        {
            Dimension retResult = originalDimension;

            if (upscale || (originalDimension.Height > newDimensions.Height || originalDimension.Width > newDimensions.Width))
            {
                double widthRatio = (double)newDimensions.Width / originalDimension.Width;
                double heightRatio = (double)newDimensions.Height / originalDimension.Height;

                double scaleRatio = Math.Min(widthRatio, heightRatio);

                if (newDimensions.Height == 0)
                    scaleRatio = heightRatio;

                if (newDimensions.Width == 0)
                    scaleRatio = widthRatio;

                retResult.Height = (uint)Math.Floor(originalDimension.Height * scaleRatio);
                retResult.Width = (uint)Math.Floor(originalDimension.Width * scaleRatio);
            }

            return retResult;
        }

        public static double SizeInKB(this byte[] image)
        {
            double retSize = 0;

            if (image != null)
            {
                retSize = image.Length / 1024;
            }

            return retSize;
        }
    }
}