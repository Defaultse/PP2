using System;
using System.Threading;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            F2();
            Console.ReadKey();
        }

        static void F2()
        {
            Thread thread = new Thread(PrintV);
            thread.Start();
        }

        static void F1()
        {
            Thread[] thread = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                thread[i] = new Thread(PrintV);
               // thread[i].Name = i.ToString();
                thread[i].Start();
            }
        }

        static void PrintV()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i);
                Thread.Sleep(1000);
            }
        }
    }
}