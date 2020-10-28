using System;
using System.Globalization;
using System.Linq;

namespace AzureVisionApiSimpleOcrSdk.Model
{
    public class Rectangle
    {
        public Rectangle(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public Rectangle()
        {
        }

        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static Rectangle FromString(string boundingBox)
        {
            var values = boundingBox.Split(',').Select(x=> Convert.ToInt32(double.Parse(x, CultureInfo.InvariantCulture))).ToList();
            return new Rectangle(values[0], values[1], values[2], values[3]);
        }
    }
}