using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{ 
    public class Point
    {
       public int x, y;
    
        public Point(int x, int y)
        {
            
            this.x = x;
            this.y = y;
           
            
           // Console.WriteLine(x+" "+y); //Genrerates walls and some modifications with food

            //Console.ReadKey();
        }
    }
}
