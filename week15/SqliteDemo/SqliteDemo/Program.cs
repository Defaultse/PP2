using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;


namespace SqliteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            string query = "insert into students(name, surname) values(@name, @surename)";
            database.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(query, database.connection);
            command.Parameters.AddWithValue("@name", "name3");
            command.Parameters.AddWithValue("@surname", "surname3");
            command.ExecuteNonQuery();
            database.CloseConnection();
            Console.ReadKey();
        }
    }
}
