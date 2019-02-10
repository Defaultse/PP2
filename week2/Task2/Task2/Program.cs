using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string data = File.ReadAllText("primeornot.txt");
            StreamWriter answer = new StreamWriter("answer.prime.txt");

            int n = data.Length;

            string[] numbers = data.Split();
            int[] s = new int[n];             

            for (int i = 0; i < n; i++)              
            {
                s[i] = int.Parse(numbers[i]);
                if (Prime(s[i])) { /*answer.Write(s[i]);*/Console.Write(s[i]+" "); } 
            }
            //answer.Close();
            Console.ReadKey();
        }
        

        static bool Prime(int n)                       
        {
            if (n == 1) return false;                 
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }

}

