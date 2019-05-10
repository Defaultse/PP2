using System;
using System.Threading;

namespace Example2
{
    class Program
    {
        public static Object lockObject = new object();
        static int k = 100;

        static void Main(string[] args)
        {
            F2();
        }

        static void F1()
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(PrintV);
                threads[i].Start();
            }
            Console.ReadKey();
        }
        static void PrintV()
        {
            lock (lockObject)
            {
                Console.WriteLine(k);
                k -= 10;
            }
        }
        static void F2()                // randomly spawn
        {
            Thread thread = new Thread(Func);
            thread.Start();
            for(int i=0; i < 1000; i++)
            {
                Console.Write('#');
            }
            Console.ReadKey();
        }
        static void Func()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write('*');
            }

        }
    }
}