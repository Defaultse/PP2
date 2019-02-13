using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static void dublicating(string[] s, int n) // Method dublicate with 2 parameters
        {
            string[] ss = new string[n * 2];               //Making two times bigger array
            for (int i = 0, j = 0; i < n; ++i)
            {
                ss[j++] = s[i];                            // Doubling
                ss[j++] = s[i];
            }
            for (int i = 0; i < 2 * n; ++i)
                Console.Write(ss[i] + " ");
        }
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());         // Reading integer n to limit array
            string[] reading = Console.ReadLine().Split(); // reading second line an array of string by splitting them by space
            dublicating(reading, n);                         // Calling a method
            Console.ReadKey(); 
        }
    }
}