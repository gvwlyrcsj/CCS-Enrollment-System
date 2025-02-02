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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ckbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "Select Username from tblLogIn where Username = '" + txtUsername.Text + "' and Password = '" + txtPass.Text + "'";

            string Username = db.ExecScalar(sql);
            if (Username != "")
            {
                HomeForm ef = new HomeForm();
                ef.Show();
            }
            else
            {
                MessageBox.Show("Wrong Credentials");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }

        private void lblCreateOne_Click(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.ShowDialog();
            this.Close();
        }
    }
}
