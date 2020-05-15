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
        readonly Entities.Reservation MyReservation = new Entities.Reservation();
        Models.Car MyCar = new Models.Car();
        Models.Customer MyCustomer = new Models.Customer();
        private readonly MyDbContext context1 = new MyDbContext();
        public UpdateCarRental()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string location = textBox5.Text;
            string plate = textBox1.Text;
            if (context1.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault() != null)
            {
                MyCar = context1.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault();
                MyReservation.CarID = MyCar.CarID;
                MyReservation.Plate = MyCar.Plate;
                MyReservation.Location = MyCar.Location;
            }
            else
            {
                MessageBox.Show("Please insert a valid car plate");
                this.Hide();
                UpdateCarRental updateCarRental = new UpdateCarRental();
                updateCarRental.ShowDialog();
                this.Close();
            }


            int customerID = Convert.ToInt32(textBox2.Text);
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
            DateTime dt;
            string[] formats = { "yyyy-MM-dd" };
            if (!DateTime.TryParseExact(textBox3.Text, formats,
                            System.Globalization.CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
            {
                MyReservation.StartDate = Convert.ToDateTime(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Please insert a valid date time");
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
                this.Close();
            }
            if (!DateTime.TryParseExact(textBox4.Text, formats,
                            System.Globalization.CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
            {
                MyReservation.EndDate = Convert.ToDateTime(textBox4.Text);
            }
            else
            {
                MessageBox.Show("Please insert a valid date time");
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
                this.Close();
            }
            if (Convert.ToDateTime(textBox4) < Convert.ToDateTime(textBox3))
            {
                MessageBox.Show("Please insert a valid date time");
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
                this.Close();
            }



            using (var MyDbEntities = new ReservationModel())
            {
                if ((MyReservation.StartDate <= MyReservation.EndDate) && (MyReservation.StartDate >= DateTime.Now))
                {
                    if (context1.Reservations.Where(c => c.EndDate < MyReservation.StartDate && c.StartDate > MyReservation.EndDate && c.CarID == MyReservation.CarID).Any())
                    {
                        MyDbEntities.Entry(MyReservation).State = System.Data.Entity.EntityState.Modified;
                        MyDbEntities.SaveChanges();
                    }
                    else if (context1.Reservations.Where(c => c.CarID == MyReservation.CarID).Any() == false)
                    {
                        MyDbEntities.Entry(MyReservation).State = System.Data.Entity.EntityState.Modified;
                        MyDbEntities.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Please insert valid dates");
                        this.Hide();
                        UpdateCarRental updateCarRental = new UpdateCarRental();
                        updateCarRental.ShowDialog();
                        this.Close();
                    }

                }
                else
                {
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
    }
}
