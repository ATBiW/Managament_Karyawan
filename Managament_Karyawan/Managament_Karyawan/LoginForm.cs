using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managament_Karyawan
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "atbiw" && tbPassword.Text == "12345")
            {
                EmployeeData EmployeeData = new EmployeeData();
                EmployeeData.Show();
                this.Hide();                
            }
            else if(tbUsername.Text != "atbiw" && tbPassword.Text != "12345")
            {
                tbUsername.Text = "";
                tbPassword.Text = "";
                lblIncorrect.Text = "Your Username and Password dont match";
                tbUsername.Focus();
            }
            else if(tbUsername.Text != "atbiw" && tbPassword.Text == "12345")
            {
                tbUsername.Text = "";
                tbPassword.Text = "";
                lblIncorrect.Text = "Your Username dont match";
                tbUsername.Focus();
            }
            else if(tbUsername.Text == "atbiw" && tbPassword.Text != "12345")
            {
                tbUsername.Text = "";
                tbPassword.Text = "";
                lblIncorrect.Text = "Your Password dont match";
                tbUsername.Focus();
            }
            else
            {
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
                
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Control ctrl;
        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                tbPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tbPassword.Focus();
            }

        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if(e.KeyCode == Keys.Up)
            {
                tbUsername.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
