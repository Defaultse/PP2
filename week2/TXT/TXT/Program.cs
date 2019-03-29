using System;
using System.IO;

namespace Example1
{
    class Program
    {
        public static void F1()                       ///// checking depth of files
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\acer\Desktop\TEsting");
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            foreach (FileSystemInfo f in fs)
            {
                if (f.GetType() == typeof(FileInfo))
                {
                    Console.WriteLine(f.Name);
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(f.FullName);
                    //int size = 0;
                    //foreach(FileSystemInfo t in dir.GetFileSystemInfos())
                    //{
                    //    size++;
                    //}
                    int size = dir.GetFileSystemInfos().Length;
                    Console.WriteLine(f.Name + "(" + size + ")");
                }
            }
            Console.ReadKey();
        }

        public static void F2()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\acer\Desktop\TEsting");
            FileInfo[] files = directory.GetFiles("*.txt");
            Console.WriteLine(files.Length);
            foreach (FileInfo f in files)
            {
                Console.WriteLine(f.Name);
            }
            Console.ReadKey();
        }

        public static bool IsPalin(string s)
        {
            int n = s.Length;
            for (int i = 0; i < n / 2; i++)
                if (s[i] != s[n - i - 1])
                    return false;
            return true;
        }

        public static void F3()           /////// Print palindrom names of files
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\acer\Desktop\TEsting");
            foreach (FileSystemInfo fs in directory.GetFileSystemInfos())
            {
                if (IsPalin(fs.Name))
                {
                    Console.WriteLine(fs.Name);
                }
            }
            Console.ReadKey();
        }

        public static void F4()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\acer\Desktop\TEsting");
            foreach (FileInfo file in directory.GetFiles())
            {
                Console.WriteLine(file.Name + " " + file.Length);
            }
            Console.ReadKey();
        }
        
        static void Main(string[] args)
        {
            F4();
        }
    }
}