using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace Sql1
{
    class Database
    {
        public SQLiteConnection connection;
        public Database()
        {
            string path = @"C:\Users\acer\Desktop\intranet3.db";
            connection = new SQLiteConnection("Data Source="+path);
            if (!(File.Exists(path)))
            {
                Console.WriteLine("Database created");
                SQLiteConnection.CreateFile(path);
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
