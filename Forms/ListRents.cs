using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rental.Entities;

namespace Rental.Forms
{
    public partial class ListRents : Form
    {
        readonly Reservation MyReservation = new Reservation();
        public ListRents()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 

        }
        private void PopGridView()
        {
            using(var MyDbEntities=new ReservationModel())
            {
                dataGridView1.DataSource = MyDbEntities.Reservations.ToList<Reservation>();
            }

        }

        private void ListRents_Load(object sender, EventArgs e)
        {
            PopGridView();

        }
    }
}
