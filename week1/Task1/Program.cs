using System;

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());     //Accepting integer n.

            int[] arr = new int[n];                    //Setting new empty array with n limited size 
            string[] s = Console.ReadLine().Split();  //Setting another array which is gonna accept all numbers in a string by splitting them 

            int cnt = 0;                               // Setting integer which is gonna count prime numbers

            for (int i = 0; i < n; i++)                 //array function(массив)
            {
                arr[i] = int.Parse(s[i]);              //Giving value for our empty array from 11th row
                if (Prime(arr[i])) { cnt++; }
            }
            Console.WriteLine(cnt);                    //Printing out counted prime numbers

            for (int i = 0; i < n; i++)                //Same array, but now we are going to print that prime numbers
            {
                arr[i] = int.Parse(s[i]);
                if (Prime(arr[i])) Console.Write(arr[i] + " ");
            }
            Console.ReadKey();
        }



        static bool Prime(int n)                       //boolean function which check if number prime or not
        {
            if (n == 1) return false;                  //tacking into account unique case with number 1
            for (int i = 2; i * i <= n; i++)           
            {
                if (n % i == 0) return false;
            }
            return true;
        }


    }


}