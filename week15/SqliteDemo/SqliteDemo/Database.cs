using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqliteDemo
{
    
    class Database
    {
        public SQLiteConnection connection;

        public Database()
        {
            string dbName = @"C:\Users\acer\Desktop\northwindEF.db";
            connection = new SQLiteConnection(@"Data Source=" + dbName);
            if (!File.Exists(dbName))
            {
                Console.WriteLine("Database created");
                SQLiteConnection.CreateFile(dbName);
            }
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}
