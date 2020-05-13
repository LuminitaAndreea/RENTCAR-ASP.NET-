using Rental.Entities;
using Rental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{
    public partial class RegisterNewCar : Form
    {
        readonly Entities.Reservation MyReservation = new Entities.Reservation();
        Models.Car MyCar = new Models.Car();
        Models.Customer MyCustomer = new Models.Customer();
        private readonly MyDbContext context1 = new MyDbContext();

        public RegisterNewCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string location= textBox5.Text;
            string plate = textBox1.Text;
            if (context1.Cars.Where(c => c.Plate == plate && c.Location==location).FirstOrDefault()!=null)
            {
                MyCar = context1.Cars.Where(c => c.Plate == plate&&c.Location==location).FirstOrDefault();
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


            int customerID = Convert.ToInt32(textBox2.Text);
            if (context1.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault()!=null)
            {
                MyCustomer = context1.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault();
                MyReservation.CustomerID = MyCustomer.CustomerID;
            }
            else
            {
                MessageBox.Show("Please insert a valid Customer Id");
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
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
            

            using (var MyDbEntities = new ReservationModel())
            {
                if (MyReservation.StartDate <= MyReservation.EndDate)
                {
                    MyDbEntities.Reservations.Add(MyReservation);
                    MyDbEntities.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Please insert valid dates");
                    this.Hide();
                    RegisterNewCar registerNewCar = new RegisterNewCar();
                    registerNewCar.ShowDialog();
                    this.Close();
                }
            }
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
