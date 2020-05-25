using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rental.Entities;
using Rental.Models;

namespace Rental.Forms
{
    public partial class AvailableCars : Form
    {
        Models.Reservation MyReservation = new Models.Reservation();
        Models.Car MyCar = new Models.Car();
        private readonly MyDbContext context1 = new MyDbContext();
        public string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Rental\Rental\MyDb.mdf;Integrated Security=True";
        
        public AvailableCars()
        {
            InitializeComponent();
        }

        private void AvailableCars_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetAvailableCarsList();
        }
        private DataTable GetAvailableCarsList()
        {
            
            DataTable dataTable = new DataTable();
            string location = textBox5.Text;
            DateTime startdate = Convert.ToDateTime(textBox3.Text);
            DateTime enddate = Convert.ToDateTime(textBox4.Text);
            using (SqlConnection con=new SqlConnection(conString))
            {
                
                using (SqlCommand cmd=new SqlCommand("SELECT DISTINCT Cars.Plate, Cars.Manufacturer, Cars.Model, Cars.PricePerDay, Cars.Location" +
                    " FROM Cars JOIN Reservations ON (Cars.CarID = Reservations.CarID AND Reservations.Location ='" + location + "' AND " +
                    "('" + startdate + "'> Reservations.EndDate OR '" + enddate + "'< Reservations.StartDate)OR(Cars.CarID!=Reservations.CarID AND " +
                    "Cars.Location='" + location + "')) ", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

