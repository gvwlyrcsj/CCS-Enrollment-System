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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
