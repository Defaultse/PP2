using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XmlSerialization
{
    // MUST be public for XML serialization to work
   
        public class Student
    {
        public string name;
        public int year;
        [XmlIgnore]
        public double gpa;

        public Student()
        {

        }
        public Student(string name, int year, double gpa)
        {
            this.name = name;
            this.year = year;
            this.gpa = gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student Yernar = new Student("Yernar", 17 , 4.0);
            string filename = "shitty.txt";
            SaveXml(filename, Yernar);
               
        }
        static void SaveXml(string filename, Student student)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(Student));
            xml.Serialize(fs,student);
            fs.Close();

        }

             
    }

  
}