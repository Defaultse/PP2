using System;
using System.Data.SQLite;

namespace Sql1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.OpenConnection();
            //insert smth 
            /*  
            Database database = new Database();
            database.OpenConnection();
            string query = "insert into students(name,surname) values (@name,@surname)";
            SQLiteCommand command = new SQLiteCommand(query, database.connection);
            command.Parameters.AddWithValue("@name","Aad");
            command.Parameters.AddWithValue("@surname", "Asdg");
            var result = command.ExecuteNonQuery();                      //cnt of strings with comands
            Console.WriteLine(result);
            database.CloseConnection();
            Console.ReadKey();
            */

            //Read from table
            string query = "select * from students";
            SQLiteCommand command = new SQLiteCommand(query, database.connection);
            SQLiteDataReader result = command.ExecuteReader(); //result from table
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("Name = {0}, Surname={1}, ID={2}", result["name"], result["surname"], result["id"]);
                }
            }
            database.CloseConnection();
            Console.ReadKey();

        }

        /*
          returns the German cities (only distinct values) from both the "Customers" and the "Suppliers" table:
          SELECT City, Country FROM Customers
WHERE Country='Germany'
UNION
SELECT City, Country FROM Suppliers
WHERE Country='Germany'
ORDER BY City;

        //inner joint
        selects all orders with customer information
        SELECT Orders.OrderID, Customers.CustomerName
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

        //Left joint
        select all customers, and any orders they might have:
        SELECT Customers.CustomerName, Orders.OrderID
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
ORDER BY Customers.CustomerName;

        selects all customers, and all orders
SELECT Customers.CustomerName, Orders.OrderID
FROM Customers
FULL OUTER JOIN Orders ON Customers.CustomerID=Orders.CustomerID
ORDER BY Customers.CustomerName;



         */
    }
}