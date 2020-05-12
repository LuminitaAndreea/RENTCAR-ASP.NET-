using Rental.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rental.Models;

namespace Rental.Forms
{
    public partial class RegisterNewCustomer : Form
    {
        readonly Entities.Customer MyCustomer = new Entities.Customer();
        private readonly MyDbContext context1 = new MyDbContext();
        public RegisterNewCustomer()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int customerID =Convert.ToInt32 (textBox2.Text);
            if (context1.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault() == null)
            {
                MyCustomer.CustomerID = customerID;
            }
            else
            {
                MessageBox.Show("This ID already exists!");
                this.Hide();
                RegisterNewCustomer registerNewCustomer = new RegisterNewCustomer();
                registerNewCustomer.ShowDialog();
                this.Close();
            }
            MyCustomer.Name = textBox3.Text;
            MyCustomer.BirthDate = Convert.ToDateTime(textBox4.Text);
            if (textBox5.Text != "")
            {
                MyCustomer.ZIP = Convert.ToInt32(textBox5.Text);
            }
            
            using (var MyDbEntities = new CustomerModel())
            {
                MyDbEntities.Customers.Add(MyCustomer);
                MyDbEntities.SaveChanges();
            }
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
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

        private void label2_Click(object sender, EventArgs e)
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
    }
}
