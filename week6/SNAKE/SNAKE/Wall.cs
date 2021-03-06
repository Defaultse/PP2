﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Wall : GameObject
    {
        enum GameLevel
        {
            FIRST,
            SECOND,
            THIRD
        }

        GameLevel gameLevel = GameLevel.FIRST;

        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            Console.Write(sign);
            body = new List<Point>();
        }
        public void ring()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    if (i == 30 || j == 80 || j == 30 || i == 80) Console.Write('#');
                    else Console.Write(' ');
                }
            }
        }
        public void LoadLevel()
        {
            body = new List<Point>();
            string fileName = "level11.txt";
            if (gameLevel == GameLevel.SECOND)
                fileName = "level22.txt";
            if (gameLevel == GameLevel.THIRD)
                fileName = "level3.txt";

            StreamReader sr = new StreamReader(fileName);
            string[] rows = sr.ReadToEnd().Split('\n');

          
             
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '#')
                        body.Add(new Point(j, i));
           

        }

        public void NextLevel()
        {
            if (gameLevel == GameLevel.FIRST)
                gameLevel = GameLevel.SECOND;
            else if (gameLevel == GameLevel.SECOND)
                gameLevel = GameLevel.THIRD;
            LoadLevel();

        }

        /*public void SaveXml(Snake snake, string filename)
         {

             FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

             XmlSerializer xml = new XmlSerializer(typeof(Snake));

             xml.Serialize(fs, this);

             fs.Close();
         }*/
    }
}
