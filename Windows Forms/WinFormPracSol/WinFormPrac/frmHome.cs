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
    public partial class frmHome : Form
    {
        String userName;
        public frmHome()
        {
            InitializeComponent();
        }
        // Here overloaded consructor
        public frmHome(String login)
        {
            this.userName = login;
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Welcome " + userName;
        }
    }
}
