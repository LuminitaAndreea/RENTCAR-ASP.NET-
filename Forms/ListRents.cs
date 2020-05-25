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
    public partial class ListRents : Form
    {
        readonly Reservation MyReservation = new Reservation();
        public ListRents()
        {
            InitializeComponent();
        }

        private void ListRents_Load(object sender, EventArgs e)
        {
            PopGridView1();
        }
        private void PopGridView1()
        {
            using (var MyDbEntities = new ReservationModel())
            {
                dataGridView1.DataSource = MyDbEntities.Reservations.ToList<Reservation>();
            }

        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
