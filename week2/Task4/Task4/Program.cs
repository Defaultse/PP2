using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
              string fileName = "TESTING.txt";                            
              string sourcePath = @"C:\Users\acer\Desktop\File\Lol1\CS";
              string targetPath = @"C:\Users\acer\Desktop\File\Lol2";

              string sourceFile = Path.Combine(sourcePath, fileName);    //Method to make computer understand which of them needs to be copied to another directory
              string destFile = Path.Combine(targetPath, fileName);
             
              File.Copy(sourceFile, destFile, true);                       //Method which copies file from one path to another
              File.Delete(@"C:\Users\acer\Desktop\File\Lol1\CS\TESTING.txt"); //which deletes first path
              

            



           /* string sourcePath = @"C:\Users\acer\Desktop\File\Lol1\CS\TESTING.txt";
            string targetPath = @"C:\Users\acer\Desktop\File\Lol2";

            DirectoryInfo directoryInfo = new DirectoryInfo(targetPath);
            FileInfo file = new FileInfo(sourcePath);
            if (file.Exists && directoryInfo.Exists)
            {
                sourcePath.CopyTo(targetPath);
                sourcePath.Delete();
            }
            else Console.WriteLine("Error");
            Console.ReadKey();*/


            /*string FilePath1 = @"C:\Users\acer\Desktop\File\Lol1\CS\TESTING.txt";
            string FilePath2 = @"C:\Users\acer\Desktop\File\Lol2";
            StreamWriter sw = new StreamWriter(FilePath1);
            sw.Close();
            File.Copy(FilePath1, FilePath2);
            File.Delete(FilePath1)*/
        }
    }



}
    

