using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SQLite;
using System.Data;

namespace Sql2
{
    class Database
    {
        public SQLiteConnection connection;
        public Database()
        {
            string path = @"C:\Users\acer\Desktop\intranet3.db";
            connection = new SQLiteConnection("Data Source="+ path);
        }

        public void OpenConnection()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public int ExecuteSql(string sql)
        {
            OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            var result = command.ExecuteNonQuery();//Doint smth
            CloseConnection();
            return result;
        }

        public DataSet GetDataSet(string sql)
        {
            OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);  //выборку из таблицу
            DataSet ds = new DataSet();  //хранит совокупность таблиц
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command); //идет в таблицу
            adapter.Fill(ds); //заполняет датасет
            CloseConnection();
            return ds;

        }

        public DataTable GetDataTable(string sql)
        {
            DataSet ds = GetDataSet(sql);
            return ds.Tables[0];
        }
    }
}
