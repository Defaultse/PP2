
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsefulWindowsForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            // MessageBox.Show("constructor");


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //MessageBox.Show("Form paint event");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


            //MessageBox.Show(e.Location+"");                        ///////////// //Print in window chosen point
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {


            button1.Location = e.Location;                         ///////////////button will follow cursor
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.Location + "");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Form load event");                     //////////Massagebox first, load form next
        }
    }
}