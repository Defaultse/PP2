﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Food : GameObject
    {
        public Food(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {

        }

        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(1, 25);
            int y = random.Next(1, 25);
            body[0].x = x;//Next points of food

            body[0].y = y;
            
        }
    }
}
