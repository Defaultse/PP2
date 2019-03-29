using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        class myThread
        {
           

            public myThread(string name, int num) 
            {
                Thread thread = new Thread(func);
                thread.Name = name;                        //Naming thread
                thread.Start(num);
            }

            void func(object num)
            {
                for (int i = 0; i < (int)num; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " выводит " + i);
                    Thread.Sleep(0);
                }
                Console.WriteLine(Thread.CurrentThread.Name + " завершился");
            }
        }

        static void Main(string[] args)
        {
            myThread t1 = new myThread("Thread 1", 6);
            myThread t2 = new myThread("Thread 2", 3);
            myThread t3 = new myThread("Thread 3", 2);
            Console.Read();
        }
    }
}