using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public AvailableCars()
        {
            InitializeComponent();
        }
        
        private void AvailableCars_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startdate = Convert.ToDateTime(textBox3.Text);
            DateTime enddate = Convert.ToDateTime(textBox4.Text);
            string location = textBox5.Text;
            if ((startdate < enddate) ||(startdate<DateTime.Now))
            {
                using (var MyDbEntities = new CarModel())
                {
                    if (context1.Reservations.Where(c => c.Location == location).Any())
                    {
                        MyReservation= context1.Reservations.Where(c => (c.EndDate >= startdate || c.StartDate <= enddate) 
                        && c.Location == location).First();
                        dataGridView1.DataSource = context1.Reservations.Where(c => c.Location == location && c.CarID!=MyReservation.CarID).ToList();
                    }
                   
                        else
                        {
                            MessageBox.Show("No car disponible for the date");
                            this.Hide();
                            AvailableCars availableCars = new AvailableCars();
                            availableCars.ShowDialog();
                            this.Close();
                        }

                }
            }
            else
            {
                MessageBox.Show("Invalid date times");
                this.Hide();
                AvailableCars availableCars = new AvailableCars();
                availableCars.ShowDialog();
                this.Close();
            }
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
    }
}
