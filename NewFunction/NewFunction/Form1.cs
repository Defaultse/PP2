using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewFunction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap OriginalImage;
        private bool IsSelecting = false;
        private int X0, Y0, X1, Y1;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsSelecting = true;
            X0 = e.X;
            Y0 = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (!IsSelecting) return;
            X1 = e.X;
            Y1 = e.Y;
            Bitmap bm = new Bitmap(OriginalImage);

            // Draw the rectangle.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawRectangle(Pens.Red,
                    Math.Min(X0, X1), Math.Min(Y0, Y1),
                    Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
            }

            // Display the temporary bitmap.
            pictureBox1.Image = bm;
        }
    
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IsSelecting) return;
            IsSelecting = false;
            pictureBox1.Image = OriginalImage;
            int wid = Math.Abs(X0 - X1);
            int hgt = Math.Abs(Y0 - Y1);
            if ((wid < 1) || (hgt < 1)) return;

            Bitmap area = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(area))
            {
                Rectangle source_rectangle =
                    new Rectangle(Math.Min(X0, X1), Math.Min(Y0, Y1),
                        wid, hgt);
                Rectangle dest_rectangle =
                    new Rectangle(0, 0, wid, hgt);
                gr.DrawImage(OriginalImage, dest_rectangle,
                    source_rectangle, GraphicsUnit.Pixel);
            }
            pictureBox2.Image = area;
        }
    }
}
