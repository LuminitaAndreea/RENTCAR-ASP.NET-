﻿using Rental.Entities;
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
    public partial class UpdateCustomer : Form
    {
        readonly Entities.Customer MyCustomer = new Entities.Customer();
        public UpdateCustomer()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            MyCustomer.CustomerID = Convert.ToInt32(textBox2.Text);
            MyCustomer.Name = textBox3.Text;
            DateTime dt;
            string[] formats = { "yyyy-MM-dd" };
            if (!DateTime.TryParseExact(textBox4.Text, formats,
                            System.Globalization.CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
            {
                MyCustomer.BirthDate = Convert.ToDateTime(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Please insert a valid birthday");
                this.Hide();
                RegisterNewCar registerNewCar = new RegisterNewCar();
                registerNewCar.ShowDialog();
                this.Close();
            }
            MyCustomer.Location = textBox5.Text;

            using (var MyDbEntities = new CustomerModel())
            {
                MyDbEntities.Entry(MyCustomer).State = System.Data.Entity.EntityState.Modified;
                MyDbEntities.SaveChanges();
            }
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
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

