using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string password = textBox2.Text;
            bool is_valid = DAL.Class1.Is_Valid_User(uname, password);
            if (is_valid)
            {
                MessageBox.Show("Valid User");
                this.Hide();
                HomeForm frm = new HomeForm();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Invalid User");
            }
        }
    }
}
