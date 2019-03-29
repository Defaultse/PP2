using System;
using System.IO;
using System.Threading;
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
            //Sinx + x-line   // Math.Sin(x) x - radians

        
           // Thread thread1 = new Thread(DrawSin);
            Thread thread2 = new Thread(Drawy);
           // thread1.Start();
            thread2.Start();
        }

        static void DrawSin()
        {
           //Method to draw sinx
        }

        static void Drawy()
        {
            for (int i=0; ;i++)
            {
                Console.SetCursorPosition(i+=2, 15 );
                Console.WriteLine('.');
                Thread.Sleep(200);
            }
        }
    }
}
