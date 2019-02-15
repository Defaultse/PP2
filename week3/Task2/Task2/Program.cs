using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager2
{
    class Layer
    {
        public FileSystemInfo[] Content                   //gives access to files
        {
            get;
            set;
        }

        int selectedItem;                                 //Index of cursor

        public int SelectedItem                           //Determines on which index is still cursor
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value < 0)
                {
                    selectedItem = Content.Length - 1;
                }
                else if (value >= Content.Length)
                {
                    selectedItem = 0;
                }
                else
                {
                    selectedItem = value;
                }
            }
        }

        public void Draw()                            //Method which prints names of irectories
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name);
            }
        }
    }

    enum FarMode                                    //оператор-перечисление /// gives a name to each constant
    {
        FileView,
        DirectoryView
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\acer\Desktop\File");
            Stack<Layer> history = new Stack<Layer>();                       //Creating a Stack/Deque
            FarMode farMode = FarMode.DirectoryView;

            history.Push(                //filling a stack 
                new Layer
                {
                    Content = root.GetFileSystemInfos(),
                   // SelectedItem = 0
                });

            while (true)                                                     //Loop 
            {
                if (farMode == FarMode.DirectoryView) 
                {
                   history.Peek().Draw();                                   //Showing files
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;                           //Goes further to the directory if it is type of directiry
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = d.GetFileSystemInfos(), SelectedItem = 0 });
                        }
                        else
                        {
                            farMode = FarMode.FileView;                                         //IF it a document
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read)) //initializing new class to open txt file
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;

                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView)
                        {
                            history.Pop();  
                        }
                        else if (farMode == FarMode.FileView)
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                        
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;
                }
            }
        }
    }
}
