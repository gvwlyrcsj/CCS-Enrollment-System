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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "Select Username from tblLogIn where Username = '" + txtUsername.Text + "' and Password = '" + txtCurPass.Text + "'";

            string Username = db.ExecScalar(sql);
            if (Username != "")
            {
                MessageBox.Show("Credentials has been verified!");
                groupBox1.Visible = true;
            }

            else
                 MessageBox.Show("Wrong Credentials.");
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblLogin SET Password ='" + txtNewPass.Text + "' WHERE Username = '" + txtUsername.Text + "'";
            DataBase db = new DataBase();
            if(db.cudCMD(sql) > 0)
            {
                if (txtNewPass.Text == txtConPass.Text)
                {
                    MessageBox.Show("Password has been changed!");
                    LoginForm lF = new LoginForm();
                    lF.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Password does not match.");
            }        
        }

        private void chb1_CheckedChanged(object sender, EventArgs e)
        {
            if (chb1.Checked)
            {
                txtCurPass.PasswordChar = '\0';
            }
            else
            {
                txtCurPass.PasswordChar = '*';
            }
        }

        private void chb2_CheckedChanged(object sender, EventArgs e)
        {
            if (chb2.Checked)
            {
                txtNewPass.PasswordChar = '\0';
                txtConPass.PasswordChar = '\0';
            }
            else
            {
                txtCurPass.PasswordChar = '*';
                txtNewPass.PasswordChar = '*';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}