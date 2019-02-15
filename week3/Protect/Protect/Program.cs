using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protect
{
    class Student
    {
        public string name;
        public string ID;
    
    
        public Student(string name, string ID)
        {
            this.name = name;
            this.ID = ID;
        }
        public static void Print()
        {
            Console.Write(name+" "+ID);
        }
    }
    class Program
    {   
        static void Main(string[] args)
        {
            Student x = new Student("Yernar", "18BD111119");
            Console.WriteLine("Current name " + ");
            x.Print();
            Console.ReadKey();
        }
    }
}
