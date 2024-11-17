using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SQLiteConnection sqliteConn;
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            sqliteConn = new SQLiteConnection("Data Source=AppData.db;Version=3;");
            try
            {
                sqliteConn.Open();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения:" + ex.Message);
            }
        }
        private void LoadData()
        {
            string query = "SELECT * FROM components";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (sqliteConn != null)
            {
                sqliteConn.Close();
            }
        }

        private void AdjustColumnWidths()
        {
            dataGridView1.Columns[0].Width = 20; // Ширина первого столбца
            dataGridView1.Columns[1].Width = 20; // Ширина второго столбца
            dataGridView1.Columns[2].Width = 800; // Ширина третьего столбца
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 100;
        }

     

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
