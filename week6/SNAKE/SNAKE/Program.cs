﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
         
            Game game = new Game();
            game.Start();
        }
    }
}
