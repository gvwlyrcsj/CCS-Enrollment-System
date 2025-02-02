using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class AddStudents : Form
    {

        public AddStudents()
        {
            InitializeComponent();
        }

        public void linis()
        {
            txtIDNo.Clear();
            txtProgram.Clear();
            txtYear.Items.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            dtpBirthday.Value = DateTime.Now;
            txtAge.Clear();
            txtContactNo.Clear();
            txtEmail.Clear();
            txtStreet.Clear();
            txtBarangay.Clear();
            txtCity.Clear();
            txtProvince.Clear();
        }

        private void CheckIDNo()
        {
            string sql = "SELECT COUNT(*) FROM tblStudentInfo WHERE IDNo = '" + txtIDNo.Text + "'";
            DataBase db = new DataBase();

            int count = Convert.ToInt32(db.ExecScalar(sql));

            if (count > 0)
                lblIndicator.ForeColor = System.Drawing.Color.Red;
            else
                lblIndicator.ForeColor = System.Drawing.Color.Green;
        }

        private void txtIDNo_TextChanged(object sender, EventArgs e)
        {
            CheckIDNo();
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            HomeForm hf = new HomeForm();
            hf.ShowDialog();
        }

        private void btnAllEnrollees_Click(object sender, EventArgs e)
        {
            this.Close();
            AllStudents hf = new AllStudents();
            hf.ShowDialog();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            this.Close();
            EditStudent hf = new EditStudent();
            hf.ShowDialog();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            this.Close();
            Subject hf = new Subject();
            hf.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Close();
            ReportForm hf = new ReportForm();
            hf.ShowDialog();
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtpBirthday.Text, out DateTime birthDate))
            {
                DateTime currentDate = DateTime.Now;
                TimeSpan age = currentDate - birthDate;
                int ageInYears = (int)(age.Days / 365);
                txtAge.Text = ageInYears.ToString();
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tblStudentInfo VALUES ('" + txtIDNo.Text.ToString() + "', '" + txtProgram.Text + "', " +
                     "'" + txtYear.Text + "', '" + txtSection.Text + "', " +
                     "'" + txtFirstName.Text + "', '" + txtMiddleName.Text + "', " +
                     "'" + txtLastName.Text + "', '" + cmbGender.Text + "', " +
                     "'" + dtpBirthday.Value.ToString("yyyy-MM-dd") + "', '" + txtAge.Text.ToString() + "', " +
                     "'" + txtContactNo.Text + "', '" + txtEmail.Text + "', " +
                     "'" + txtStreet.Text + "', '" + txtBarangay.Text + "', '" + txtCity.Text + "', " +
                     "'" + txtProvince.Text + "')";

            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                linis();
                AddSubject ads = new AddSubject();
                ads.Show();
            }         
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {  
            AddSubject ads = new AddSubject();
            ads.Show();
        }

        private void AddStudents_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
        }
    }
}