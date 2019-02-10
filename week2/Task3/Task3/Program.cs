using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\acer\Desktop\File\");
            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Name);
            }
            Console.WriteLine();
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo dInfo in directories)
            {
                Console.WriteLine(dInfo.Name);
            }
            Console.ReadKey();
        }
       

        static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("  ");
        }
       
    }
}
