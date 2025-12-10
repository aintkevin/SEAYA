using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEAYA
{
    public partial class add : Form
    {
        private static SEAYAEntities db = new SEAYAEntities();
        public add()
        {
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTripName.Text) ||
                string.IsNullOrWhiteSpace(txtTripTime.Text) || 
                string.IsNullOrWhiteSpace(txtTripPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(txtTripPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price. Enter a number.");
                return;
            }

            Trips newTrip = new Trips
            {
                TripName = txtTripName.Text,
                TripDate = dtpTripDate.Value.Date,
                TripTime = txtTripTime.Text,
                TripPrice = int.Parse(txtTripPrice.Text)
            }; 

            db.Trips.Add(newTrip);
            db.SaveChanges();

            MessageBox.Show("Trip added successfully!");


            this.Close();
        }

        
    }
    
}
