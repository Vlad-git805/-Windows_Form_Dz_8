using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<RectangleInfo> rectangles = new List<RectangleInfo>();
        List<EllipseInfo> ellips = new List<EllipseInfo>();
        List<Point> points = new List<Point>();
        List<LineInfo> line = new List<LineInfo>();
        RectangleInfo currentRect;
        EllipseInfo ellipsRect;
        LineInfo lineRect;
        Graphics graphics;
        bool isDrawing = false;
        Brush ellip_cl = Brushes.Black;
        Brush rectangl_cl = Brushes.Black;
        Brush point_cl = Brushes.Black;
        Brush line_cl = Brushes.Black;
        bool dottedLine = false;
        public int Thickness { get; set; }
        public Color cl_line;

        public Form1()
        {
            InitializeComponent();

            graphics = this.CreateGraphics();
        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (toolStripMenuItem2.Checked)
            {
                currentRect = new RectangleInfo(rectangl_cl, e.Location);
            }
            else if (toolStripMenuItem3.Checked)
            {
                ellipsRect = new EllipseInfo(ellip_cl, e.Location);
            }
            else if (toolStripMenuItem21.Checked)
            {
                lineRect = new LineInfo(line_cl, e.Location, dottedLine, Thickness, cl_line);
            }
            isDrawing = true;
        }

        private void Form1_MouseUp_1(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (toolStripMenuItem2.Checked)
            {
                currentRect.SetSize(e.Location);
                currentRect.Print(graphics);
                rectangles.Add(currentRect);
            }
            else if (toolStripMenuItem3.Checked)
            {
                ellipsRect.SetSize(e.Location);
                ellipsRect.Print(graphics);
                ellips.Add(ellipsRect);
            }
            else if (toolStripMenuItem21.Checked)
            {
                lineRect.SetSize(e.Location);
                lineRect.Print(graphics);
                line.Add(lineRect);
            }
        }

        private void PrintRectangles(Graphics graphics)
        {
            foreach (var r in rectangles)
            {
                r.Print(graphics);
            }
        }
        private void Printellips(Graphics graphics)
        {
            foreach (var r in ellips)
            {
                r.Print(graphics);
            }
        }

        private void Printline(Graphics graphics)
        {
            foreach (var r in line)
            {
                r.Print(graphics);
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            PrintRectangles(e.Graphics);
            Printellips(e.Graphics);
            PrintFigures(e.Graphics);
            Printline(e.Graphics);
        }

        private void PrintFigures(Graphics g)
        {
            foreach (Point p in points)
                g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10F, 10F);
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (toolStripMenuItem2.Checked)
                {
                    currentRect.Clear(graphics);
                    currentRect.SetSize(e.Location);
                    currentRect.Print(graphics);
                }
                else if (toolStripMenuItem3.Checked)
                {
                    ellipsRect.Clear(graphics);
                    ellipsRect.SetSize(e.Location);
                    ellipsRect.Print(graphics);
                }
                //else if (toolStripMenuItem21.Checked)
                //{
                //    lineRect.Clear(graphics);
                //    lineRect.SetSize(e.Location);
                //    lineRect.Print(graphics);
                //}
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            dottedLine = true;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            dottedLine = false;
        }

        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (toolStripMenuItem14.Checked)
            {
                Point point = e.Location;
                points.Add(point);
                this.CreateGraphics().FillEllipse(point_cl, point.X - 5, point.Y - 5, 10F, 10F);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem14.Checked = false;
            toolStripMenuItem21.Checked = false;
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem14.Checked = false;
            toolStripMenuItem21.Checked = false;
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem14.Checked = true;
            toolStripMenuItem21.Checked = false;
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            toolStripMenuItem21.Checked = true;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem14.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                ellip_cl = new SolidBrush(color.Color);
                rectangl_cl = new SolidBrush(color.Color);
                point_cl = new SolidBrush(color.Color);
                line_cl = new SolidBrush(color.Color);
                cl_line = color.Color;
            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            Thickness = int.Parse(toolStripComboBox1.Text);
        }
    }








    //List<RectangleInfo> rectangles = new List<RectangleInfo>();
    //List<EllipseInfo> ellipses = new List<EllipseInfo>();
    //List<Point> points = new List<Point>();
    //List<Pen> pens = new List<Pen>();
    //RectangleInfo currentRect;
    //Brush rectangleColor = Brushes.Black;
    //EllipseInfo currentEllips;
    //Brush ellipsColor = Brushes.Black;
    //Brush pointColor = Brushes.Black;
    //Brush penColor = Brushes.Black;

    //Graphics graphics;
    //bool isDrawing = false;

    //public Form1()
    //{
    //    InitializeComponent();

    //    graphics = this.CreateGraphics();
    //}

    //private void Form1_MouseDown_1(object sender, MouseEventArgs e)
    //{
    //    if (radioButton1.Checked)
    //    {
    //        currentRect = new RectangleInfo(rectangleColor, e.Location);
    //    }
    //    else if(radioButton2.Checked)
    //    {
    //        currentEllips = new EllipseInfo(ellipsColor, e.Location);
    //    }
    //    else if (radioButton3.Checked)
    //    {
    //        currentEllips = new EllipseInfo(ellipsColor, e.Location);
    //    }
    //    isDrawing = true;
    //    isDrawing = true;

    //}

    //private void Form1_MouseUp_1(object sender, MouseEventArgs e)
    //{
    //    isDrawing = false;
    //    if (radioButton1.Checked)
    //    {
    //        currentRect.SetSize(e.Location);
    //        currentRect.Print(graphics);
    //        rectangles.Add(currentRect);
    //    }
    //    else if(radioButton2.Checked)
    //    {
    //        currentEllips.SetSize(e.Location);
    //        currentEllips.Print(graphics);
    //        ellipses.Add(currentEllips);
    //    }
    //}

    //private void PrintRectangles(Graphics graphics)
    //{
    //    foreach (var r in rectangles)
    //    {
    //        r.Print(graphics);
    //    }
    //}

    //private void PrintEllipses(Graphics graphics)
    //{
    //    foreach (var r in ellipses)
    //    {
    //        r.Print(graphics);
    //    }
    //}

    //private void PrintFigures(Graphics g)
    //{
    //    foreach (Point p in points)
    //        g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10F, 10F);
    //}

    //private void Form1_Paint_1(object sender, PaintEventArgs e)
    //{
    //    PrintRectangles(e.Graphics);
    //    PrintEllipses(e.Graphics);
    //    PrintFigures(e.Graphics);
    //}

    //private void Form1_MouseMove_1(object sender, MouseEventArgs e)
    //{
    //    if (isDrawing)
    //    {
    //        if (radioButton1.Checked)
    //        {
    //            currentRect.Clear(graphics);
    //            currentRect.SetSize(e.Location);
    //            currentRect.Print(graphics);
    //        }
    //        else if(radioButton2.Checked)
    //        {
    //            currentEllips.Clear(graphics);
    //            currentEllips.SetSize(e.Location);
    //            currentEllips.Print(graphics);
    //        }
    //    }
    //}

    //private void toolStripMenuItem5_Click(object sender, EventArgs e)
    //{
    //}

    //private void toolStripMenuItem6_Click(object sender, EventArgs e)
    //{
    //    rectangleColor = Brushes.Red;
    //}

    //private void toolStripMenuItem7_Click(object sender, EventArgs e)
    //{
    //    rectangleColor = Brushes.Green;
    //}

    //private void toolStripMenuItem8_Click(object sender, EventArgs e)
    //{
    //    rectangleColor = Brushes.Yellow;
    //}

    //private void toolStripMenuItem9_Click(object sender, EventArgs e)
    //{
    //    rectangleColor = Brushes.Purple;
    //}

    //private void toolStripMenuItem10_Click(object sender, EventArgs e)
    //{
    //    ellipsColor = Brushes.Red;
    //}

    //private void toolStripMenuItem11_Click(object sender, EventArgs e)
    //{
    //    ellipsColor = Brushes.Yellow;
    //}

    //private void toolStripMenuItem12_Click(object sender, EventArgs e)
    //{
    //    ellipsColor = Brushes.Green;
    //}

    //private void toolStripMenuItem13_Click(object sender, EventArgs e)
    //{
    //    ellipsColor = Brushes.Purple;
    //}

    //private void Form1_Load(object sender, EventArgs e)
    //{

    //}

    //private void Form1_MouseClick(object sender, MouseEventArgs e)
    //{
    //    if (radioButton4.Checked)
    //    {
    //        Point point = e.Location;
    //        points.Add(point);
    //        this.CreateGraphics().FillEllipse(pointColor, point.X - 5, point.Y - 5, 10F, 10F);
    //    }

    //}

    //private void toolStripMenuItem16_Click(object sender, EventArgs e)
    //{
    //    pointColor = Brushes.Black;
    //}

    //private void toolStripMenuItem17_Click(object sender, EventArgs e)
    //{
    //    pointColor = Brushes.Green;
    //}

    //private void toolStripMenuItem18_Click(object sender, EventArgs e)
    //{
    //    pointColor = Brushes.Yellow;
    //}

    //private void toolStripMenuItem19_Click(object sender, EventArgs e)
    //{
    //    pointColor = Brushes.Red;
    //}

    //private void toolStripMenuItem20_Click(object sender, EventArgs e)
    //{
    //    pointColor = Brushes.Purple;
    //}

    //private void radioButton1_CheckedChanged(object sender, EventArgs e)
    //{

    //}
}
