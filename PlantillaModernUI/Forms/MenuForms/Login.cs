using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Login : Form
    {
        BusinessLogic logic = new BusinessLogic();
        public Login()
        {
            InitializeComponent();
        }

        #region EventsBtnClicks
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ibtnLogin_Click(object sender, EventArgs e)
        {
            bool r = logic.Sesion(txtUser.Text, txtPassword.Text);
            if (r)
            {
                Main main = Owner as Main;
                main.btnConfiguracion.Visible = true;
                main.pbHome.Enabled = true;
                this.Close();
            }
            else
            {
                lblMsg.Text = "Invalid Credentials, Try Again!!";
            }
        }

        #endregion

        #region EventsTextBox
        private void txtUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "User")
            {
                txtUser.Text = String.Empty;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == String.Empty)
            {
                txtUser.Text = "User";
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = String.Empty;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == String.Empty)
            {
                txtPassword.Text = "Password";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        #endregion
    }
}
