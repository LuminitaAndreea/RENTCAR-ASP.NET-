using Rental.Entities;
using Rental.Models;
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

namespace Rental.Forms
{
    public partial class UpdateCarRental : Form
    {
        Entities.Reservation MyReservation = new Entities.Reservation();
        Models.Reservation reservation = new Models.Reservation();
        Models.Car MyCar = new Models.Car();
        Models.Customer MyCustomer = new Models.Customer();
        private readonly MyDbContext context1 = new MyDbContext();
        
        public UpdateCarRental()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string location = textBox6.Text;
            string plate = textBox2.Text;
            MyReservation.ReservationId = Convert.ToInt32(textBox1.Text);

            if (context1.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault() != null)
            {
                MyCar = context1.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault();
                MyReservation.CarID = MyCar.CarID;
                MyReservation.Plate = MyCar.Plate;
                MyReservation.Location = MyCar.Location;
            }
            else
            {
                MessageBox.Show("Invalid car plate or location!");
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
                this.Close();
            }

            int customerID = Convert.ToInt32(textBox3.Text);
            if (context1.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault() != null)
            {
                MyCustomer = context1.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault();
                MyReservation.CustomerID = MyCustomer.CustomerID;
            }
            else
            {
                MessageBox.Show("Please insert a valid Customer Id");
                this.Hide();
                UpdateCarRental updateCarRental = new UpdateCarRental();
                updateCarRental.ShowDialog();
                this.Close();
            }
            
            MyReservation.StartDate= Convert.ToDateTime(textBox4.Text);
            MyReservation.EndDate = Convert.ToDateTime(textBox5.Text);
            
            using (var MyDbEntities = new ReservationModel())
            {
                if ((MyReservation.StartDate <= MyReservation.EndDate) && (MyReservation.StartDate >= DateTime.Now))
                {
                    if ((context1.Reservations.Where(c => !((c.EndDate < MyReservation.StartDate) || (c.StartDate > MyReservation.EndDate))
                         && (c.ReservationId != MyReservation.ReservationId) && (c.Plate == MyReservation.Plate)).Any())==false)
                    {
                            MyDbEntities.Entry(MyReservation).State = System.Data.Entity.EntityState.Modified;
                            MyDbEntities.SaveChanges();
                            this.Hide();
                            Menu menu = new Menu();
                            menu.ShowDialog();
                            this.Close();
                    }
                    else if (context1.Reservations.Where(c => c.Plate == MyReservation.Plate).Count() == 1)
                    {
                        MyDbEntities.Entry(MyReservation).State = System.Data.Entity.EntityState.Modified;
                        MyDbEntities.SaveChanges();
                        this.Hide();
                        Menu menu = new Menu();
                        menu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please insert another dates");
                        this.Hide();
                        UpdateCarRental updateCarRental = new UpdateCarRental();
                        updateCarRental.ShowDialog();
                        this.Close();
                    }

                }
                else
                {

                    MessageBox.Show("Please insert valid dates");
                    this.Hide();
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    this.Close();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
