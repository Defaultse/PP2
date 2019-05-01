using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        enum PaintTool
        {
            PEN,
            RECTANGLE,
            ELLIPSE,
            STAR,
            ERASER,
            TRIANGLE,
            SELECTIONTOOL,
            FILL
        }

        Bitmap bitmap;
        Graphics gBitmap;
        Point prevPoint, curPoint;
        bool mouseClicked = false;
        Pen pen = new Pen(Color.Black, 3);
        PaintTool tool = PaintTool.PEN;
        Queue<Point> q = new Queue<Point>();
        Color initColor;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        public bool Check(int x, int y)
        {
            if (x < 0 || x >= bitmap.Width)
                return false;
            if (y < 0 || y >= bitmap.Height)
                return false;
            if (bitmap.GetPixel(x, y) != initColor)
                return false;
            return true;
        }

        int[] dx = new int[] { 1, -1, 0, 0 };
        int[] dy = new int[] { 0, 0, 1, -1 };

        public void Fill(int x, int y)
        {
            q = new Queue<Point>();
            q.Enqueue(new Point(x, y));
            bitmap.SetPixel(x, y, pen.Color);

            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    if (Check(p.X + dx[i], p.Y + dy[i]))
                    {
                        bitmap.SetPixel(p.X + dx[i], p.Y + dy[i], pen.Color);
                        // pictureBox1.Refresh();
                        q.Enqueue(new Point(p.X + dx[i], p.Y + dy[i]));
                    }
                }

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
            if (tool == PaintTool.FILL)
            {
                initColor = bitmap.GetPixel(e.Location.X, e.Location.Y);
                Fill(e.Location.X, e.Location.Y);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
            if (tool == PaintTool.RECTANGLE)
            {
                gBitmap.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));
            }
            else if (tool == PaintTool.ELLIPSE)
            {
                gBitmap.DrawEllipse(pen, GetRectangle(prevPoint, curPoint));
            }
            else if (tool == PaintTool.STAR)
            {
                gBitmap.DrawPolygon(pen, GetPolygon(prevPoint, curPoint));

            }
            else if (tool == PaintTool.TRIANGLE)
            {
                gBitmap.DrawPolygon(pen, GetTriangle(prevPoint, curPoint));

            }
            else if (tool == PaintTool.SELECTIONTOOL)
            {
                gBitmap.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));

            }

        }
        Point[] GetTriangle(Point prevPoint, Point curPoint)
        {
            int x1 = Math.Min(prevPoint.X, curPoint.X);
            int y1 = Math.Min(prevPoint.Y, curPoint.Y);
            int x2 = Math.Max(prevPoint.X, curPoint.X);
            int y2 = Math.Max(prevPoint.Y, curPoint.Y);

            return new Point[]
            {
                new Point(x1, y2),
                new Point(x2, y2),
                new Point(x1, (y1 + y2) / 2),            
            };
        }
        Rectangle GetRectangle(Point prevPoint, Point curPoint)
        {
            int minX = Math.Min(prevPoint.X, curPoint.X);
            int minY = Math.Min(prevPoint.Y, curPoint.Y);
            int width = Math.Abs(prevPoint.X - curPoint.X);
            int height = Math.Abs(prevPoint.Y - curPoint.Y);
            return new Rectangle(minX, minY, width, height);
        }

        Point[] GetPolygon(Point prevPoint, Point curPoint)
        {
            int x1 = Math.Min(prevPoint.X, curPoint.X);
            int y1 = Math.Min(prevPoint.Y, curPoint.Y);
            int x2 = Math.Max(prevPoint.X, curPoint.X);
            int y2 = Math.Max(prevPoint.Y, curPoint.Y);

            return new Point[]
            {
                new Point(x1, y2),
                new Point((x1 + x2) / 2, y1),
                new Point(x2, y2),
                new Point(x1, (y1 + y2) / 2),
                new Point(x2, (y1 + y2) / 2)
            };
        }
        

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                curPoint = e.Location;
                if (tool == PaintTool.PEN)
                {
                    gBitmap.DrawLine(pen, prevPoint, curPoint);
                    prevPoint = curPoint;
                }
                pictureBox1.Refresh();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = PaintTool.PEN;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = PaintTool.RECTANGLE;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = PaintTool.ELLIPSE;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = PaintTool.STAR;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (tool == PaintTool.RECTANGLE)
            {
                e.Graphics.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));
            }
            else if (tool == PaintTool.ELLIPSE)
            {
                e.Graphics.DrawEllipse(pen, GetRectangle(prevPoint, curPoint));
            }
            else if (tool == PaintTool.STAR)
            {
                e.Graphics.DrawPolygon(pen, GetPolygon(prevPoint, curPoint));
            }
            else if (tool == PaintTool.TRIANGLE)
            {
                e.Graphics.DrawPolygon(pen, GetTriangle(prevPoint, curPoint));
            }
            else if (tool == PaintTool.SELECTIONTOOL)
            {
                e.Graphics.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap = Bitmap.FromFile(openFileDialog1.FileName) as Bitmap;
                pictureBox1.Image = bitmap;
                gBitmap = Graphics.FromImage(bitmap);
                pictureBox1.Refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tool = PaintTool.FILL;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tool = PaintTool.TRIANGLE;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tool = PaintTool.SELECTIONTOOL;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

    }
}
