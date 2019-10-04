using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormPrac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            String login = txtLogin.Text;
            String password = txtPassword.Text;

            if (login == "admin" && password == "admin")
            {
                //MessageBox.Show("Valid User!");

                this.Hide();
                //Overloaded consructor call
                frmHome frm = new frmHome(login);
                frm.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login/Password");
            }
        }
    }
}
