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
        private Users userLoggedIn;
        public tickets(Users userLoggedIn)
        {
            InitializeComponent();
            this.userLoggedIn = userLoggedIn;
            SetupHoverEffects();
        }

        private void SetupHoverEffects()
        {
            lblProfile.MouseEnter += NavLabel_MouseEnter;
            lblProfile.MouseLeave += NavLabel_MouseLeave;
            
            lblTrips.MouseEnter += NavLabel_MouseEnter;
            lblTrips.MouseLeave += NavLabel_MouseLeave;

            button3.MouseEnter += Button3_MouseEnter;
            button3.MouseLeave += Button3_MouseLeave;
        }

        private void NavLabel_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null && lbl != lblTickets)
            {
                lbl.ForeColor = Color.FromArgb(0, 150, 199);
            }
        }

        private void NavLabel_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null && lbl != lblTickets)
            {
                lbl.ForeColor = Color.FromArgb(100, 100, 100);
            }
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(200, 35, 51);
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(220, 53, 69);
        }

        private void tickets_Load(object sender, EventArgs e)
        {
            LoadTickets();
        }

        private void LoadTickets()
        {
            try
            {
                using (var db = new SEAYAEntities())
                {
                    var tickets = db.Bookings
                        .Where(b => b.UserId == userLoggedIn.UserId)
                        .Select(b => new
                        {
                            BookingID = b.BookingId,
                            Trip = b.Trips.TripName,
                            Date = b.Trips.TripDate,
                            Tickets = b.TicketCount,
                            Amount = b.Trips.TripPrice * b.TicketCount,
                            Payment = b.Payments.payment_type,
                            BookedOn = b.BookingDate
                        })
                        .OrderByDescending(b => b.BookedOn) 
                        .ToList();

                    dgvTickets.DataSource = tickets;
                    
                    FormatDataGridView();
                }
            }
            catch (System.Data.Entity.Core.EntityException ex)
            {
                MessageBox.Show("Database connection error. Please ensure SQL Server is running.\n\nDetails: " + ex.InnerException?.Message, 
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvTickets.Columns.Count > 0)
            {
                dgvTickets.Columns["BookingID"].HeaderText = "Booking ID";
                dgvTickets.Columns["BookingID"].Width = 100;
                
                dgvTickets.Columns["Trip"].HeaderText = "Destination";
                dgvTickets.Columns["Trip"].Width = 200;
                
                dgvTickets.Columns["Date"].HeaderText = "Departure Date";
                dgvTickets.Columns["Date"].DefaultCellStyle.Format = "MMM dd, yyyy";
                dgvTickets.Columns["Date"].Width = 150;
                
                dgvTickets.Columns["Tickets"].HeaderText = "Ticket Count";
                dgvTickets.Columns["Tickets"].Width = 100;
                
                dgvTickets.Columns["Amount"].HeaderText = "Total Amount";
                dgvTickets.Columns["Amount"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvTickets.Columns["Amount"].Width = 120;
                
                dgvTickets.Columns["Payment"].HeaderText = "Payment Method";
                dgvTickets.Columns["Payment"].Width = 140;
                
                dgvTickets.Columns["BookedOn"].HeaderText = "Booking Date";
                dgvTickets.Columns["BookedOn"].DefaultCellStyle.Format = "MMM dd, yyyy";
                dgvTickets.Columns["BookedOn"].Width = 150;

                dgvTickets.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            }
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
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Hide();
                signin signin = new signin();
                signin.Show();
            }
        }

        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTickets_Click(object sender, EventArgs e)
        {

        }
    }
}
