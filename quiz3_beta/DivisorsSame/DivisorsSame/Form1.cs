using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivisorsSame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int k = 0;
        int a1 = 0;
        int b1 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string aa = textBox1.Text;
            string bb = textBox1.Text;
            int a = int.Parse(aa);
            int b = int.Parse(bb);
            while (a < k && b < k)
            {
                if (a % k == 0) a1 = k;
                if (b % k == 0) b1 = k;
                k++;
                if (a1 == b1) label1.Text = "Comprime";
                else label1.Text = "Not comprime";
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
