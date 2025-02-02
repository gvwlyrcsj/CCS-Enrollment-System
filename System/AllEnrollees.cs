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
    public partial class AllStudents : Form
    {
        public AllStudents()
        {
            InitializeComponent();
        }

        public void labas()
        {
            DataBase db = new DataBase();
            dGVAllEnrollees.DataSource = db.selectCmd("SELECT * FROM tblStudentInfo");
        }

        private void AllStudents_Load(object sender, EventArgs e)
        {
            labas();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            DataBase db = new DataBase();
            dGVAllEnrollees.DataSource = db.selectCmd("SELECT * FROM tblStudentInfo WHERE IDNo LIKE '%" + searchValue + "%' OR Program LIKE '%" + searchValue + "%' OR Year LIKE '%" + searchValue + "%' OR Section LIKE '%" + searchValue + "%' OR FirstName LIKE '%" + searchValue + "%' OR MiddleName LIKE '%" + searchValue + "%' OR LastName LIKE '%" + searchValue + "%' OR Gender LIKE '%" + searchValue + "%' OR Birthday LIKE '%" + searchValue + "%' OR Age LIKE '%" + searchValue + "%' OR ContactNo LIKE '%" + searchValue + "%' OR Email LIKE '%" + searchValue + "%' OR Street LIKE '%" + searchValue + "%' OR Barangay LIKE '%" + searchValue + "%' OR City LIKE '%" + searchValue + "%' OR Province LIKE '%" + searchValue + "%'");
        }

        private void btnAddtudent_Click(object sender, EventArgs e)
        {
            this.Close();
            AddStudents hf = new AddStudents();
            hf.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            HomeForm hf = new HomeForm();
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
    }
}
