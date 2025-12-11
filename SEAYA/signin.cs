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
        public signin()
        {
            InitializeComponent();
            SetupHoverEffects();
        }

        private void SetupHoverEffects()
        {
            button1.MouseEnter += Button1_MouseEnter;
            button1.MouseLeave += Button1_MouseLeave;
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 150, 199);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                using (var db = new SEAYAEntities())
                {
                    var user = db.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefault();

                    if (user != null)
                    {
                        MessageBox.Show("Login successful! Welcome aboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
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
                        MessageBox.Show("Invalid username or password.\nPlease check your credentials and try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
