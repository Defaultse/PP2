using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Game
    {
        List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public int speedofsnake = 200;

      //  XmlSerializer XMLSerialization = new XmlSerializer(typeof(Game));

        public Game()
        {
            g_objects = new List<GameObject>();
            snake = new Snake(20, 10, 'O', ConsoleColor.Red);
            food = new Food(10, 5, 'o', ConsoleColor.Cyan);
            wall = new Wall('#', ConsoleColor.Green);
            wall.LoadLevel();
            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();

            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);

            isAlive = true;
        }

        public void Start()
        {
            
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                //2if (keyInfo.Key == ConsoleKey.Escape) { string filename = "Saved Game";  wall.SaveXml(snake,filename); }
                Thread thread = new Thread(MoveSnake);
                thread.Start();

                while (isAlive && keyInfo.Key != ConsoleKey.Escape)
                { 
                keyInfo = Console.ReadKey();
                    snake.ChangeDirection(keyInfo);
                }
            
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("GAME OVER!!!");
                Console.SetCursorPosition(10, 12);
                Console.WriteLine("Press any button");
                Console.ReadKey();
            
        }

        public void MoveSnake()
        {
            while (isAlive)
            {
                snake.Move();
                if (snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();

                    if (snake.body.Count % 3 == 0)
                    {
                        wall.NextLevel();
                        speedofsnake = speedofsnake - 100;
                    }
                        
                }
                if (snake.IsCollisionWithObject(wall) ) 
                {
                    isAlive = false; 
                }
                Draw();
                Thread.Sleep(speedofsnake);
            }
        }
        public void Draw()
        {     
            Console.Clear(); 
            foreach (GameObject g in g_objects)
                g.Draw();
            Console.SetCursorPosition(30, 1);
            Console.WriteLine(snake.body.Count);
            

        }
        /*public void Save()
        {
            using(FileStream stream = new FileStream( "game.xml", FileMode.Create, FileAccess.Write))
            {
                XMLSerialization.Serialize(stream, this);
            }
        }*/


    }
}
