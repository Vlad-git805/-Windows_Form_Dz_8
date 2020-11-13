using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LineInfo
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public int Thickness { get; set; }
        public Brush Brush { get; set; }
        public bool dottedLine { get; set; }
        public Color cl { get; set; }

        public LineInfo(Brush brush, Point location, bool dottedLine, int thickness, Color cl)
        {
            Brush = brush;
            X = location.X;
            Y = location.Y;
            this.dottedLine = dottedLine;
            Thickness = thickness;
            this.cl = cl;
        }
        public void SetSize(Point endCoords)
        {
            Width = endCoords.X;
            Height = endCoords.Y;

            //if (endCoords.X < X) X = endCoords.X;
            //if (endCoords.Y < Y) Y = endCoords.Y;
        }
        public void Print(Graphics graphics)
        {
            Pen pen = new Pen(cl, Thickness);
            if (dottedLine == false)
                pen = new Pen(cl, Thickness);
            else
            {
                pen = new Pen(cl, Thickness);
                pen.DashStyle = DashStyle.Dash;
            }
            graphics.DrawLine(pen, X, Y, Width, Height);
        }
    }
}
