using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());    //Giving a number to create a limited array 
            int[] arr = new int[n];                   //Declaring a limited to n array 
            string[] s = Console.ReadLine().Split(); //Another array, accepting data by splitting string

            for (int i = 0; i < n; i++)                //array
            {
                arr[i] = int.Parse(s[i]);             //filling empty array(which was limited by n previously) by transforming string into integer
                Console.Write(arr[i] + " " + arr[i] + " "); //printing out same number twice 
            }
            Console.ReadKey();

        }
    }
}
