using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select * from students";
            Database database = new Database();  //connection with database.cs
            dataGridView1.DataSource = database.GetDataTable(sql); //передача запроса, getting table
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUD crud = new CRUD();
            crud.ShowDialog();
        }
    }
}
