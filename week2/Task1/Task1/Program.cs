using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("palindromornot.txt");
            int n = text.Length;

            int k = 0;
            string[] s = new string[n];

            for (int i = 0; i < n / 2; i++) //abab
            {
                if (s[i] == s[n-1-i])
                {
                    k++;
                }
                              

            }
            if (k == n / 2)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");
            }
            Console.ReadKey();
        }   
    }
}
