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
        int year;
        public Student(string aname, string aid, int ayear)
        {
            name = aname;
            id = aid;
            year = ++ayear;
        }
        public void Printing()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // string[] s = Console.ReadLine().Split();
            Student x = new Student("Yernar", "18BD111119", 2018);
            /*string name = s[0];
            string id = s[1];
            int year = int.Parse(s[2]);*/

            /* x.name = "Yernar";
             x.id = "18BD111119";
             x.year = int.Parse('2018');*/

            x.Printing();
            Console.ReadKey();
        }
    }
}

