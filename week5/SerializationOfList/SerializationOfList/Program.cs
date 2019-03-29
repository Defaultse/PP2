using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationOfList
{
    public class Person
    {
        public string LastName;
        public string FirstName;
        public int ID;

        public Person()
        {

        }
        public Person(string LastName, string FirstName, int ID)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.ID = ID;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> myList = new List<Person>();

            myList.AddRange(new Person[]{
                new Person("DowneyJR","Robert",1119),
                new Person("Smith","Will",1212)
            });
            string filename = "data.txt";
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
            xml.Serialize(fs, myList);
            fs.Close();
        }
    }
}
