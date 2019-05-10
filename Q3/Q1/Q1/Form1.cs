using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        String operationPerformed = "";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void operator_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            operationPerformed = button.Text;
        }

      

        public static string Sum(string a)
        {
            
            return a;
        

        }
       
        /// ////////////////////////////////
       
        public static string Min(string a)
        {
            
            return a;

        }
      
        /// ////////////////////////////////////////
    
        public static string Low(string a)
        {
            string b = a.ToLower();
            return b;
        }
       
        /// //////////////////////////////////////////
      
        public static string Upp(string a)
        {
            string b = a.ToUpper();
            
            return b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = Sum(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = Min(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = Upp(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = Low(textBox1.Text);
        }

       

           
        }

       
    }



