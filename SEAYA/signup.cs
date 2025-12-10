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
        private static SEAYAEntities db = new SEAYAEntities();
        public signup()
        {
            InitializeComponent(); 
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
                MessageBox.Show("You must be at least 10 years old to register.");
                return;
            }

            if (!txtEmail.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email must contain '@gmail.com");
                return;
            }


            var userExists = db.Users.Any(u => u.Username == username);

            if (userExists)
            {
                MessageBox.Show("Username already Exist.");
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

            MessageBox.Show("Registration successful!");
            this.Hide();
            signin signin = new signin();
            signin.Show();
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
    }
}
