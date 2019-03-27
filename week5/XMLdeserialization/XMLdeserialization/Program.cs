using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace XMLdeserialization
{
    public class Student
    {
        public string name;
        public int year;
        public double gpa;

        public string GetInfo()
        {
            return "name :" + this.name + ",age :" + this.age;
        }
    }
    
    class Program
    {
        static Student LoadXml(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(Student));
            Student student = xml.Deserialize(fs) as Student;
            fs.Close();
            return student;
        }
       
        static void Main(string[] args)
        {
            string filename = "data.txt";
            Student student = LoadXml(filename);
            Console.WriteLine(student.GetInfo());
            Console.ReadLine();
        }
        
    }
}
