using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace System
{
    public partial class EditStudent : Form
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        public void linis()
        {
            txtIDNo.Clear();
            txtProgram.Clear();
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

        private void txtIDNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Search()
        {
            string searchValue = txtSearch.Text;
            string sql = $"SELECT * FROM tblStudentInfo WHERE IDNo LIKE '{searchValue}%'";

            try
            {
                DataBase db = new DataBase();
                using (SqlDataReader reader = db.DReader(sql))
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            txtIDNo.Text = reader["IDNo"].ToString();
                            txtProgram.Text = reader["Program"].ToString();
                            txtYear.Text = reader["Year"].ToString();
                            txtSection.Text = reader["Section"].ToString();
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtMiddleName.Text = reader["MiddleName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            cmbGender.Text = reader["Gender"].ToString();
                            dtpBirthday.Text = reader["Birthday"].ToString();
                            txtAge.Text = reader["Age"].ToString();
                            txtContactNo.Text = reader["ContactNo"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtStreet.Text = reader["Street"].ToString();
                            txtBarangay.Text = reader["Barangay"].ToString();
                            txtCity.Text = reader["City"].ToString();
                            txtProvince.Text = reader["Province"].ToString();
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: {0}", ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblStudentInfo SET Program = '" + txtProgram.Text + "', Year = '" + txtYear.Text + "', " +
                                                   "Section = '" + txtSection.Text + "', FirstName = '" + txtFirstName.Text + "', " +
                                                   "MiddleName = '" + txtMiddleName.Text + "', LastName = '" + txtLastName.Text + "', " +
                                                   "Gender = '" + cmbGender.Text + "', Birthday = '" + dtpBirthday.Value.ToString("yyyy-MM-dd") + "', " +
                                                   "Age = '" + txtAge.Text + "', ContactNo = '" + txtContactNo.Text + "', " +
                                                   "Email = '" + txtEmail.Text + "', Street = '" + txtStreet.Text + "', " +
                                                   "Barangay = '" + txtBarangay.Text + "', City = '" + txtCity.Text + "', " +
                                                   "Province = '" + txtProvince.Text + "' " +
                                                   "WHERE IDNo = '" + txtIDNo.Text + "'";


            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                linis();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblStudentInfo WHERE IDNo = '" + txtIDNo.Text + "'; " +
                         "DELETE FROM tblAddSubjects WHERE IDNo = '" + txtIDNo.Text + "'";

            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAddtudent_Click(object sender, EventArgs e)
        {
            this.Close();
            AddStudents hf = new AddStudents();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
            if (int.TryParse(txtIDNo.Text, out int enteredIDNo))
            {
                LoadSubs(enteredIDNo);
            }
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
        }

        private void LoadSubs(int selectedIDNo)
        {
            string sql = "SELECT SubjectCode, Subject, Units FROM tblAddSubjects WHERE IDNo = " + selectedIDNo;
            DataBase db = new DataBase();
            DataTable dt = db.selectCmd(sql);
            dGVList.DataSource = dt;
        }
    }
}