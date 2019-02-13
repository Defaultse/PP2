using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());   // To limit out array 
            string[,] arr = new string[n,n];         //Declaring 2d array
            /* 11 12 13      [*]   .    .
             * 21 22 23  ->  [*]  [*]   .       working with indexes 
             * 31 32 33      [*]  [*]  [*]                 */

            for (int i = 0; i < n; i++)       
            {
                for (int j = 0; j <= i ; j++)
                
                    arr[i, j] = "[*]";          //Giving values to indexes
            }

            for (int i=0 ; i < n ; i++) {
                for (int j=0 ; j <= i ; j++)
                {
                    Console.Write(arr[i,j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        } 
    }
}
