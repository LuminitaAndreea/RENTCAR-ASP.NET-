using Rental.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Menu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Hide();
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D1)
            {
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D3)
            {
                this.Hide();
                ListRents listRents = new ListRents();
                listRents.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D3)
            {
                this.Hide();
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D4)
            {
                this.Hide();
                AvailableCars availableCars = new AvailableCars();
                availableCars.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D5)
            {
                this.Hide();
                RegisterNewCustomer registerNewCustomer = new RegisterNewCustomer();
                registerNewCustomer.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D6)
            {
                this.Hide();
                UpdateCustomer updateCustomer = new UpdateCustomer();
                updateCustomer.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D7)
            {
                this.Hide();
                ListCustomers listCustomers = new ListCustomers();
                listCustomers.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.D8)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please insert a valid number");
                this.Hide();
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }


        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
