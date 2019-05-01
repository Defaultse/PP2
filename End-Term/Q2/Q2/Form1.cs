using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        bool mouseClicked = false;
        Bitmap bitmap;
        Graphics g;
        public int cnt=0;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }
        public int x, y, r = 0;
        Color[] colors = new Color[] { Color.Green, Color.Red };
        Random random = new Random();

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cnt > 2) ;
        }
       
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (!mouseClicked)
            {
                x = e.Location.X;
                y = e.Location.Y;
                r = 1;
                timer1.Start();
                mouseClicked = true;
            }
            else
            {
                mouseClicked = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            int index = random.Next(0, colors.Length);
            Pen pen = new Pen(colors[index], 3);
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            cnt++;
            pictureBox1.Refresh();

        }

    }
}
