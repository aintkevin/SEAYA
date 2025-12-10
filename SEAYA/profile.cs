using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SEAYA
{
    public partial class profile : Form
    {
        private static SEAYAEntities db = new SEAYAEntities();

        private Users userLoggedIn;

        public profile(Users userloggedIn)
        {
            InitializeComponent();
            this.userLoggedIn = userloggedIn;

        }
        private void profile_Load(object sender, EventArgs e)
        {
            LoadUser();
            Show1();
        }
        private void LoadUser()
        {
            lblName.Text = userLoggedIn.Name;
            lblEmail.Text = userLoggedIn.Email;
            lblAge.Text = userLoggedIn.Age.ToString();
        }

        private void Show1()
        {
            lblName.Visible = true;
            lblEmail.Visible = true;
            lblAge.Visible = true;
        
            txtName.Visible = false;
            txtEmail.Visible = false;
            txtAge.Visible = false;
            btnSave.Visible = false;

         
            btnEdit.Visible = true;
        }

        private void Show2()
        {
          
            lblName.Visible = false;
            lblEmail.Visible = false;
            lblAge.Visible = false;

         
            txtName.Visible = true;
            txtEmail.Visible = true;
            txtAge.Visible = true;
            btnSave.Visible = true;

        
            txtName.Text = userLoggedIn.Name;
            txtEmail.Text = userLoggedIn.Email;
            txtAge.Text = userLoggedIn.Age.ToString();

        
            btnSave.Visible = true;
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            Show2();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email must contain '@gmail.com");
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.UserId == userLoggedIn.UserId);

            if (user != null)
            {
                user.Name = txtName.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.Age = (int)txtAge.Value;

                db.SaveChanges();

                MessageBox.Show("Profile updated!");

              
                userLoggedIn = user;

                LoadUser();
                Show1();
            }
        }
     
        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            lblProfile.ForeColor = Color.DeepSkyBlue;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lblProfile.ForeColor = Color.DodgerBlue;   
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin signin = new signin();
            signin.Show();
        }

        private void lbltrips_Click(object sender, EventArgs e)
        {
            this.Hide();
            trip trip = new trip(userLoggedIn);
            trip.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
