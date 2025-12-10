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
    public partial class signin : Form
    {
        private static SEAYAEntities db = new SEAYAEntities();
        public signin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = db.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("Login successful!");
   
                if (user.RoleID == 1)
                {
                    SEAYAADMIN admin = new SEAYAADMIN();
                    admin.Show();
                }
                else
                {
                    profile passenger = new profile(user);
                    passenger.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            signup signup = new signup();
            signup.Show();
        }

        private void signin_Load(object sender, EventArgs e)
        {

        }
    }
}
