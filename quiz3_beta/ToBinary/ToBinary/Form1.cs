using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToBinary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int a = int.Parse(s);
            string binary = Convert.ToString(a,2);
            string bin = binary;
            label1.Text = bin; 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
