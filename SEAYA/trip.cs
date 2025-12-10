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
    public partial class trip : Form
    {
        private static SEAYAEntities db = new SEAYAEntities();

        private Users userLoggedIn;

        public trip(Users userLoggedIn)
        {
            InitializeComponent();
           this.userLoggedIn = userLoggedIn;
        }

        private void trip_Load(object sender, EventArgs e)
        {
            LoadTrips();
        }

        private void LoadTrips()
        {
            var trips = db.Trips
                .OrderBy(t => t.TripDate)
                .Select(t => new
                {
                    t.TripId,
                    t.TripName,
                    t.TripDate,
                    t.TripTime,
                    //t.TripPrice
                })
                .ToList();

            dgvTrips.DataSource = trips;
        }

        private void dgvTrips_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

                int tripId = Convert.ToInt32(dgvTrips.Rows[e.RowIndex].Cells["TripId"].Value);

                booking booking = new booking( tripId, userLoggedIn);
                booking.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin signin = new signin();
            signin.Show();
        }

        private void lblProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            profile profile = new profile(userLoggedIn);
            profile.Show();
        }

        private void dgvTrips_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTickets_Click(object sender, EventArgs e)
        {
            this.Hide();
            tickets tickets = new tickets(userLoggedIn);
            tickets.Show();
        }
    }
}
