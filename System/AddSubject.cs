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
    public partial class AddSubject : Form
    {

        public AddSubject()
        {
            InitializeComponent();
        }

        public void labas()
        {
            DataBase db = new DataBase();
            dGVList.DataSource = db.selectCmd("SELECT * FROM tblSubjects");
        }

        public void load()
        {
            DataBase db = new DataBase();
            dGVSub.DataSource = db.selectCmd("SELECT SubjectCode, Subject, Units FROM tblAddSubjects WHERE IDNo = '" + txtIDNum.Text + "'");
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            labas();
        }

        private void LoadSubjects(int selectedIDNo)
        {
            string sql = "SELECT SubjectCode, Subject, Units FROM tblAddSubjects WHERE IDNo = " + selectedIDNo;
            DataBase db = new DataBase();
            DataTable dt = db.selectCmd(sql);
            dGVSub.DataSource = dt;
        }

        private void txtIDNum_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtIDNum.Text, out int enteredIDNo))
            {
                LoadSubjects(enteredIDNo);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblAddSubjects WHERE IDNo = '" + txtIDNum.Text + "' AND SubjectCode = '" + txtSubjectCode.Text + "' AND Subject = '" + txtSubject.Text + "' AND Semester = '" + cmbSemester.Text + "' AND SchoolYear = '" + txtSchoolYear.Text + "'";

            DataBase db = new DataBase();
            if (db.cudCMD(sql) > 0)
            {
                MessageBox.Show("Record has been deleted");
            }

            else
            {
                MessageBox.Show("Error");
            }
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtIDNum.Text, out int enteredIDNo))
            {
                LoadSubjects(enteredIDNo);
            }
        }

        private void dGVSub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRows = dGVSub.Rows[index];
                txtSubjectCode.Text = selectedRows.Cells[0].Value.ToString();
                txtSubject.Text = selectedRows.Cells[1].Value.ToString();
                txtUnits.Text = selectedRows.Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void dGVList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRows = dGVList.Rows[index];
                txtSubjectCode.Text = selectedRows.Cells[0].Value.ToString();
                txtSubject.Text = selectedRows.Cells[1].Value.ToString();
                txtUnits.Text = selectedRows.Cells[2].Value.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblAddSubjects VALUES ('" + txtIDNum.Text + "', '" + txtSubjectCode.Text + "', '" + txtSubject.Text + "', '" + txtUnits.Text + "', '" + cmbSemester.Text + "', '" + txtSchoolYear.Text + "')";

                DataBase db = new DataBase();
                if (db.cudCMD(sql) > 0)
                {
                    MessageBox.Show("Successful");

                    DataGridViewRow addRow = new DataGridViewRow();
                    addRow.CreateCells(dGVSub);
                    addRow.Cells[0].Value = txtSubjectCode.Text;
                    addRow.Cells[1].Value = txtSubject.Text;
                    addRow.Cells[2].Value = txtUnits.Text;
                    dGVSub.Rows.Add(addRow);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }

        public override void Refresh()
        {
            try
            {
                DataBase db = new DataBase();
                dGVList.DataSource = null; 
                dGVList.DataSource = db.selectCmd("SELECT SubjectCode, Subject, Units FROM tblAddSubjects WHERE IDNo = '" + txtIDNum.Text + "'");
                dGVList.Refresh(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}