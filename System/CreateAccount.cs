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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "INSERT INTO tblLogin VALUES('" + txtUsername.Text + "', '" + txtPass.Text + "')";

            if(db.cudCMD(sql) > 0)
            {
                if (txtUsername.Text != "")
                {
                    MessageBox.Show("Account has been created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm ef = new LoginForm();
                    ef.Show();
                }
                else
                {
                    MessageBox.Show("Missing inputs");
                }
            }           
        }
    }
}
