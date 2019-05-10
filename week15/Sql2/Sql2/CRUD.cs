using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql2
{
    public partial class CRUD : Form
    {
        Database database = new Database();
        public CRUD()
        {
            InitializeComponent();
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if(label1.Text == "-")
            {
                string sql = "insert into students(name,surname) values " +
                    "'" + txtName.Text + "'," +
                    "'" + txtSurname.Text + "'," + "')";
                int cnt = database.ExecuteSql(sql);
                MessageBox.Show("added successfully");
            }
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            database = new Database();
        }
    }
}
