using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
    {
    class Student
    {
        string name;
        string id;
        int year=0;
        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        public void Printing()
        {
            Console.WriteLine(name + " " + id + " ");
        }
        public void Year.print()
        {
            year++;
            Console.WriteLine(year);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Student x = new Student("Yernar", "18BD111119");

            x.Printing();
            x.Year.print();
            Console.ReadKey();
        }
    }
}

