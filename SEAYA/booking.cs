using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SEAYA
{
    public partial class booking : Form
    {

        private static SEAYAEntities db = new SEAYAEntities(); 
        private Users userLoggedIn;
        private int selectedTripId;
        private Trips selectedTrip;

        public booking(int tripId, Users userLoggedIn)
        {
            InitializeComponent();
            selectedTripId = tripId;
            this.userLoggedIn = userLoggedIn;
        }

        private void booking_Load(object sender, EventArgs e)
        {
            LoadTrip();

        }

        private void LoadTrip()
        {
            selectedTrip = db.Trips.FirstOrDefault(t => t.TripId == selectedTripId);

            if (selectedTrip != null)
            {
                lblDestination.Text = selectedTrip.TripName;
                lblDate.Text = selectedTrip.TripDate.ToString();
                lblPrice.Text = selectedTrip.TripPrice.ToString();
                //cbPayment.Text = selectedTrip.TripPayment.ToString();

            }

            var payments = db.Payments
                .Select(p => p.payment_type)
                .ToList();


            cbPayment.DataSource = payments;
        }

        private void lblDestination_Click(object sender, EventArgs e)
        {

        }

        

        private void btnBuy_Click_1(object sender, EventArgs e)
        {
            var selectedPayment = db.Payments.FirstOrDefault(p => p.payment_type == cbPayment.Text);

            Bookings booking = new Bookings
            {
                UserId = userLoggedIn.UserId,
                TripId = selectedTrip.TripId,          
                payment_id = selectedPayment.payment_id, 
                TicketCount = (int)nupAmount.Value,
                BookingDate = DateTime.Now
            };

            db.Bookings.Add(booking);
            db.SaveChanges();

            MessageBox.Show("Trip booked successfully!");

            this.Hide();
        }
    }
}
