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
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();         
        }

        public void linis()
        {
            txtSubjectCode.Clear();
            txtUnits.Clear();
            txtSubject.Clear();
        }

        public void labas()
        {
            DataBase db = new DataBase();
            dGVSubject.DataSource = db.selectCmd("SELECT SubjectCode, Subject, Units FROM tblSubjects");
        }

        private void Sub_Load(object sender, EventArgs e)
        {
            labas();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tblSubjects VALUES ('" + txtSubjectCode.Text + "', '" + txtSubject.Text + "', '" + txtUnits.Text + "')";

            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labas();
                linis();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblSubjects SET Subject = '" + txtSubject.Text + "', Units = '" + txtUnits.Text + "' WHERE SubjectCode = '" + txtSubjectCode.Text + "'";

            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labas();
                linis();
            }
        }

        private void dGVSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRows = dGVSubject.Rows[index];
                txtSubjectCode.Text = selectedRows.Cells[0].Value.ToString();
                txtSubject.Text = selectedRows.Cells[1].Value.ToString();
                txtUnits.Text = selectedRows.Cells[2].Value.ToString();
            }
            catch
            {

            }   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblSubjects WHERE SubjectCode = '" + txtSubjectCode.Text + "'";

            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labas();
                linis();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            DataBase db = new DataBase();
            dGVSubject.DataSource = db.selectCmd("SELECT * FROM tblSubjects WHERE SubjectCode LIKE '%" + searchValue + "%' OR Subject LIKE '%" + searchValue + "%' OR Units LIKE '%" + searchValue + "%'");
        }

        private void Home_Click(object sender, EventArgs e)
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

        private void btnAddtudent_Click(object sender, EventArgs e)
        {
            this.Close();
            AddStudents hf = new AddStudents();
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
    }
}