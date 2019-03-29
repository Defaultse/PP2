using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml_Serialization_and_Deserialization_V2
{
    class Program
    {
        public static void F1()
        {
            Address address = new Address();
            address.Name = "Askar Akshabayev";
            address.City = "Almaty";
            address.State = "Alatau district";
            address.Zip = "050000";

            OrderItem item1 = new OrderItem("Item1", "Item 1 description", 100, 2);
            OrderItem item2 = new OrderItem("Item2", "Item 2 description", 123, 3);

            PurchaseOrder order = new PurchaseOrder(address, "21.02.2019");
            order.OrderItems.Add(item1);
            order.OrderItems.Add(item2);
           // order.Save(order);
            Console.WriteLine(address);
        }

        public static void F2()
        {
            FileStream fs = new FileStream("order.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(PurchaseOrder));
            PurchaseOrder order = xs.Deserialize(fs) as PurchaseOrder;
            fs.Close();
            Console.WriteLine(order.OrderItems[0].ItemName);
        }
        static void Main(string[] args)
        {
            F2();
            Console.ReadKey();

        }

    }
}
