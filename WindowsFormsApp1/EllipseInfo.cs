using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class EllipseInfo
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public Brush Brush { get; set; }

        public EllipseInfo(Brush brush, Point location)
        {
            Brush = brush;
            X = location.X;
            Y = location.Y;
        }
        public void SetSize(Point endCoords)
        {
            Width = Math.Abs(endCoords.X - X);
            Height = Math.Abs(endCoords.Y - Y);

            if (endCoords.X < X) X = endCoords.X;
            if (endCoords.Y < Y) Y = endCoords.Y;
        }
        public void Print(Graphics graphics)
        {
            graphics.FillEllipse(Brush, X, Y, Width, Height);
        }
        public void Clear(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(SystemColors.Control), X, Y, Width, Height);
        }
    }
}
