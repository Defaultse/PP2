using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperEasyCalculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox1_Result.Text == "0") || (isOperationPerformed)) textBox1_Result.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox1_Result.Text = textBox1_Result.Text + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button13.PerformClick();
                operationPerformed = button.Text;
                label1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox1_Result.Text);
                label1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = "0";
            resultValue = 0;
        }

        int NOD(double a, double b) ////////////////////////////////////ЕУОБ
        {
            while (a > 0 && b > 0)

                if (a > b)
                    a %= b;

                else
                    b %= a;
            int res = Convert.ToInt32(a + b);
            return res;
        }

        int LCM(double a, double b) 
        {
            int num1, num2;                    
            if (a > b)
            {
                num1 = Convert.ToInt32(a); num2 = Convert.ToInt32(b);
            }
            else
            {
                num1 = Convert.ToInt32(b); num2 = Convert.ToInt32(a);
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }

        public int Factorial(int numb)
        {
            int res = 1;
            

            for (int i = numb; i > 1; i--)
                res *= i;
            return res;
        }
        public static int bTOd(int binVal)
        {
            int num = binVal, decVal = 0, baseVal = 1, rem;
         
            while (num > 0)
            {
                rem = num % 10;
                decVal = decVal + rem * baseVal;
                num = num / 10;

                baseVal = baseVal * 2;
            }
            
            return decVal;
        }

        public static string iTOh(int val)
        {
            string answer = Convert.ToString(val, 16);
            return answer;
           
        }

        /*public static int toASCII(int val)
        {
            int value = (int)val;
            return value;
        }*/

      

        public static string ToBin(int numb)
        {
            /*string result = "";
            int num = Convert.ToInt32(numb);
            while (num > 1)
            {
                int remainder = num % 2;
                result = Convert.ToString(remainder) + result;
                num /= 2;
            }
            result = Convert.ToString(num) + result;
       
            return result;*/
            int[] p = new int[8];
            string pa = "";
            for (int ii = 0; ii <= 7; ii = ii + 1)
            {
                p[7 - ii] = numb % 2;
                numb = numb / 2;
            }
            for (int ii = 0; ii <= 7; ii = ii + 1)
            {
                pa += p[ii].ToString();
            }
            return pa;

        }


        private void button13_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {

                case "+":
                    textBox1_Result.Text = (resultValue + Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "-":
                    textBox1_Result.Text = (resultValue - Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "x":
                    textBox1_Result.Text = (resultValue * Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "/":
                    textBox1_Result.Text = (resultValue / Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "#":
                    textBox1_Result.Text = (NOD(resultValue, Double.Parse(textBox1_Result.Text))).ToString();
                    break;
                case "!":
                    textBox1_Result.Text = (Factorial(Convert.ToInt32(resultValue))).ToString();
                    break;
                case "^2":
                    textBox1_Result.Text = (Math.Pow(resultValue, 2)).ToString();
                    break;
                case "^":
                    textBox1_Result.Text = (Math.Pow(resultValue, Double.Parse(textBox1_Result.Text))).ToString();
                    break;
                case "sin":
                    textBox1_Result.Text = (Math.Sin(Math.PI * (Double.Parse(textBox1_Result.Text) / 180))).ToString();
                    break;
                case "decimalTObin":
                    textBox1_Result.Text = ToBin(Convert.ToInt32(resultValue));
                    break;
                case "binTOdecimal":
                    textBox1_Result.Text = bTOd(Convert.ToInt32(resultValue)).ToString();
                    break;
                case "intTOheximal":
                    textBox1_Result.Text = iTOh(Convert.ToInt32(resultValue));
                    break;
                case "LCM":
                    textBox1_Result.Text = (LCM(resultValue, Double.Parse(textBox1_Result.Text))).ToString();
                    break;
                //    case "ASCII":
                //       textBox1_Result.Text = toASCII(Convert.ToInt32(resultValue)).ToString();
                //     break;
                case "hexTobin"://string binaryText = Convert.ToString(Convert.ToInt32(hex, 16),2).PadLeft(8, 0)
                    ///
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox1_Result.Text);
            label1.Text = "";

            /*
             * void prime_num(long num)
        {
            bool isPrime = true;
            for (int i = 0; i <= num; i++)
            {
                for (int j = 2; j <= num; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine ( "Prime:" + i );
                }
                isPrime = true;
            }*/
        }
        }
        
   }



    
}
