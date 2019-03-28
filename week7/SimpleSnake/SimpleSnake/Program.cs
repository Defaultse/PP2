using System;
using System.Threading;

namespace SimpleSnake
{
    class Program
    {
        static Snake snake;
        static void Main(string[] args)
        {
            snake = new Snake(10, 10);
            Thread thread = new Thread(Move);
            thread.Start();

            while (true)
            {
                snake.Draw();
                Thread.Sleep(200);
            }
        }

        static void Move()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                snake.Move(keyInfo);
            }
        }
    }
}