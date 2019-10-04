using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using BAL;
using Model;

namespace DBPrac_Msc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StudentDTO dto = new StudentDTO();

            dto.StudentID = Convert.ToInt32(label4.Text);
            dto.Name = txtName.Text.Trim();
            dto.City= txtCity.Text.Trim();
            dto.Age= txtAge.Text.Trim();

            StudentBAL balObj = new StudentBAL();
            int recEff = balObj.SaveStudent(dto);
            if (recEff > 0)
                MessageBox.Show("Record is saved successfully", "Success", MessageBoxButtons.OK);
            else
                MessageBox.Show("Some Problem has occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            StudentBAL balObj = new StudentBAL();
            //DataTable dt = balObj.GetStudents();
            //dataGridView1.DataSource = dt;

            List<StudentDTO> list = balObj.GetStudentsList();
            dataGridView1.DataSource = list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                StudentBAL balObj = new StudentBAL();
                StudentDTO dto = balObj.GetStudentByID(id);
                label4.Text = dto.StudentID.ToString();
                txtName.Text = dto.Name;
                txtCity.Text = dto.City;
                txtAge.Text = dto.Age;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
