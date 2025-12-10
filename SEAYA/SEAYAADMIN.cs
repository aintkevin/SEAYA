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
    public partial class SEAYAADMIN : Form
    {
        private static SEAYAEntities db = new SEAYAEntities();
        public SEAYAADMIN()
        {
            InitializeComponent();
        }
        private void SEAYAADMIN_Load(object sender, EventArgs e)
        {
            LoadTrips();
        }
        private void LoadTrips()
        {
            var trips = db.Trips
                .Select(t => new
                {
                    t.TripId,
                    t.TripName,
                    t.TripDate,
                    t.TripTime,
                    t.TripPrice
                })
                .OrderBy(t => t.TripDate)
                .ToList();
                
            dgvTrips.DataSource = trips;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin signin = new signin();
            signin.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            add add = new add();
            add.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTrips.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trip to delete.");
                return;
            }

            int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["TripId"].Value);

            var trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (trip != null)
            {
                db.Trips.Remove(trip);
                db.SaveChanges();

                MessageBox.Show("Trip deleted successfully!");
                LoadTrips();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrips();
        }
    }
}
