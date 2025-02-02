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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "Select Count(IDNo) As total from tblStudentInfo";
            string total = db.ExecScalar(sql);
            if (total != null)
            {
                lblTotal.Text = total.ToString();
            }
            else
            {
                lblTotal.Text = "Error";
            }

            string sql1 = "SELECT COUNT(Gender) AS male FROM tblStudentInfo WHERE Gender = 'Male'";
            string male = db.ExecScalar(sql1);
            if (total != null)
            {
                lblMale.Text = male.ToString();
            }
            else
            {
                lblMale.Text = "Error ";
            }

            string sql2 = "SELECT COUNT(Gender) AS female FROM tblStudentInfo WHERE Gender = 'Female'";
            string female = db.ExecScalar(sql2);
            if (total != null)
            {
                lblFemale.Text = female.ToString();
            }
            else
            {
                lblMale.Text = "Error ";
            }
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
