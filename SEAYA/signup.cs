using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SEAYA
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent(); 
            SetupHoverEffects();
        }

        private void SetupHoverEffects()
        {
            btnSignup.MouseEnter += BtnSignup_MouseEnter;
            btnSignup.MouseLeave += BtnSignup_MouseLeave;
        }

        private void BtnSignup_MouseEnter(object sender, EventArgs e)
        {
            btnSignup.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BtnSignup_MouseLeave(object sender, EventArgs e)
        {
            btnSignup.BackColor = Color.FromArgb(0, 150, 199);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            int age = (int)txtAge.Value;
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (txtAge.Value < 10)
            {
                MessageBox.Show("You must be at least 10 years old to register.", "Age Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtEmail.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email must contain '@gmail.com'", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new SEAYAEntities())
                {
                    var userExists = db.Users.Any(u => u.Username == username);

                    if (userExists)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newUser = new Users
                    {
                        Name = name,
                        Age = age,
                        Email = email,
                        Username = username,
                        Password = password,
                        RoleID = 2
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("Registration successful! Welcome aboard SEAYA!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    signin signin = new signin();
                    signin.Show();
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
            signin login = new signin();
            login.Show();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
