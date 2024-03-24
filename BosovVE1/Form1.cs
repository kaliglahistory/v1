using _2;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BosovVE1
{
    public partial class Form1 : Form
    {
        DB dB = new DB();
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID", "id");
            dataGridView1.Columns.Add("Title", "название");
            dataGridView1.Columns.Add("cost", "цена");




        }
        private void readsinglerouse(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDecimal(2));

        }
        private void refereh(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string qeri = $" select *from dbo.Product ";
            SqlCommand command = new SqlCommand(qeri, dB.GetConnection());
            dB.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                readsinglerouse(dgw, reader);


            }
            reader.Close();
        }
        private void pars(DataGridView dgw)
        {
            var nane = textBox1.Text;
            var cost = textBox2.Text;
            dgw.Rows.Clear();
            string qeri2 = $" select *from dbo.Product where '{Name}' = Title or '{cost}' = cost  ";
            SqlCommand command = new SqlCommand(qeri2, dB.GetConnection());
            dB.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                readsinglerouse(dgw, reader);


            }
            reader.Close();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            CreateColumns();
            refereh(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateColumns();
            pars(dataGridView1);
        }
    }
}
