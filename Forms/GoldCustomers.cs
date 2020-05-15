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

namespace Rental.Forms
{
    public partial class GoldCustomers : Form
    {
        public GoldCustomers()
        {
            InitializeComponent();
        }
        private void PopGridView()
        {
            using (var MyDbEntities = new CustomerModel())
            {
                dataGridView1.DataSource = MyDbEntities.Customers.ToList<Customer>();
            }
            
        }
        private void GoldCustomers_Load(object sender, EventArgs e)
        {
            PopGridView();
        }
    }
}
