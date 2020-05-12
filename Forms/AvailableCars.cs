using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rental.Entities;
using Rental.Models;

namespace Rental.Forms
{
    public partial class AvailableCars : Form
    {
        readonly Entities.Reservation MyReservation = new Entities.Reservation();
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
            DateTime startdate=Convert.ToDateTime( textBox3.Text);
            DateTime enddate = Convert.ToDateTime(textBox4.Text);
            string plate = textBox1.Text;
            string model = textBox2.Text;
            MyReservation.Location = textBox5.Text; ;

            if (context1.Cars.Where(c => c.Plate == plate && c.Model == model).FirstOrDefault() != null)
            {
                MyCar = context1.Cars.Where(c => c.Plate == plate && c.Model == model).FirstOrDefault();
                MyReservation.CarID = MyCar.CarID;
                MyReservation.Plate = MyCar.Plate;
            }
            else
            {
                MessageBox.Show("Please insert a valid car plate and model");
                this.Hide();
                AvailableCars availableCars = new AvailableCars();
                availableCars.ShowDialog();
                this.Close();
            }

             using (var MyDbEntities = new ReservationModel())
                {
                if (context1.Reservations.Where(c => c.StartDate >= startdate && c.EndDate >= enddate).Any())
                {
                    MyReservation.ReservStatsID = 1;
                   
                }
                else
                {
                    MessageBox.Show("Please insert a valid date time");
                    this.Hide();
                    AvailableCars availableCars = new AvailableCars();
                    availableCars.ShowDialog();
                    this.Close();
                }
                dataGridView1.DataSource = context1.Reservations.Where(c => c.CarID == MyReservation.CarID && c.Location==MyReservation.Location).ToList();
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
    }
}
