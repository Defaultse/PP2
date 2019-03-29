using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Car
    {
        public string name;
        public string mark;
        public int yearOFRelease;
        
        public Car()//For serialization
        {

        }
        public Car(string name, string mark, int yearOFRelease)
        {
            this.name = name;
            this.mark = mark;
            this.yearOFRelease = yearOFRelease;
        }
        public string GetInfo()
        {
            return this.name + " " + this.mark + " " +this.yearOFRelease;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //10 cars
            List<Car> myLIst = new List<Car>();
            myLIst.AddRange(new Car[]
            {
                new Car("Name1","Mark1",2017),
                new Car("Name2","Mark2",2017),
                new Car("Name3","Mark3",2016),
                new Car("Name4","Mark4",2017),
                new Car("Name5","Mark5",2017),
                new Car("Name6","Mark6",2007),
                new Car("Name7","Mark7",2017),
                new Car("Name8","Mark8",2017),
                new Car("Name9","Mark9",2017),
                new Car("Name10","Mark10",2017)
            });
            string filename = "data.txt";
            //SaveXml(filename,);
            Car car = new Car();
            car = LoadXml(filename);
            Console.WriteLine(car.GetInfo());
            Console.ReadKey();



        }
        static void SaveXml(string filename, Car car)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(List<Car>));
            xml.Serialize(fs, car);
            fs.Close();
        }

        static Car LoadXml(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(List<Car>));
            Car car = xml.Deserialize(fs) as Car;
            fs.Close();
            return car;
        }

    }
}
