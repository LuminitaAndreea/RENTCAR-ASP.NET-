﻿using Rental.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.Forms
{
    public partial class ListCustomers : Form
    {
        readonly Customer MyCustomer = new Customer();
        public ListCustomers()
        {
            InitializeComponent();
        }

        private void ListRents_Load(object sender, EventArgs e)
        {
            PopGridView();
        }
        private void PopGridView()
        {
            using (var MyDbEntities = new CustomerModel())
            {
                dataGridView1.DataSource = MyDbEntities.Customers.ToList<Customer>();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
    }
}
