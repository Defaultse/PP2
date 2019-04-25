using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car
{
    public partial class Form1 : Form
    {
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        private int x;
        private int y;
        private Direction direction;
        public Form1()
        {
            InitializeComponent();
            x = 50;
            y = 50;
            direction = Direction.Right;

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            e.Graphics.FillRectangle(Brushes.Red, x, y, 40, 10);
            e.Graphics.FillRectangle(Brushes.Red, x-10, y+10, 70, 10);
            e.Graphics.FillEllipse(Brushes.Red, x+35, y+3, 10, 10);
            e.Graphics.FillEllipse(Brushes.Red, x-5, y+3, 10, 10);
            e.Graphics.FillEllipse(Brushes.Black, x-5, y+15, 15, 15);
            e.Graphics.FillEllipse(Brushes.Black, x+40, y+15, 15, 15);

        }

        private void timerMoving_Tick(object sender, EventArgs e)
        {
           
                if (direction == Direction.Right)
                {
                    x += 10;
                }
                else if (direction == Direction.Left)
                {
                    x -= 10;
                }
                else if (direction == Direction.Up)
                {
                    y -= 10;
                }
                else if (direction == Direction.Down)
                {
                    y += 10;
                }
                Invalidate();
            
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                direction = Direction.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                direction = Direction.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                direction = Direction.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                direction = Direction.Down;
            }

        }
    }
}
