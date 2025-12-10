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
    public partial class tickets : Form
    {
        private static SEAYAEntities db = new SEAYAEntities();

        private Users userLoggedIn;
        public tickets(Users userLoggedIn)
        {
            InitializeComponent();
            this.userLoggedIn = userLoggedIn;
        }

        private void tickets_Load(object sender, EventArgs e)
        {
            LoadTickets();
        }

        private void LoadTickets()
        {
            
            var tickets = db.Bookings
                .Where(b => b.UserId == userLoggedIn.UserId)
                .Select(b => new
                {
                    b.BookingId,
                    b.Trips.TripName,
                    b.Trips.TripDate,
                    b.TicketCount,
                    TicketAmount =  b.Trips.TripPrice * b.TicketCount ,
                    b.Payments.payment_type,
                    b.BookingDate
                })
                .OrderByDescending(b => b.BookingDate) 
                .ToList();

            dgvTickets.DataSource = tickets;
        }


        private void lblProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            profile profile = new profile(userLoggedIn);
            profile.Show();
        }

        private void lbltrips_Click(object sender, EventArgs e)
        {
            this.Hide();
            trip trip = new trip(userLoggedIn);
            trip.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin signin = new signin();
            signin.Show();
        }

        
    }
}
