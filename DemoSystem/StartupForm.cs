using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSystem
{
    public partial class StartupForm : Form
    {

        SqlConnection conn = new SqlConnection(Helper.ConnString("demoConn"));

        int loginPanelWidth;
        bool isLoginPanelVisible;
        bool isLoginBtnClicked;
        public StartupForm()
        {
            InitializeComponent();
            loginPanelWidth = this.Width;
            isLoginPanelVisible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void login_MouseHover(object sender, EventArgs e)
        {
            btnLoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(54)))));
        }

        private void login_MouseLeave(object sender, EventArgs e)
        {
            if (!isLoginBtnClicked)
            {
                btnLoginPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
                btnLoginPanel.ForeColor = System.Drawing.SystemColors.ControlText;
                loginPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            }
        }

        private void login_MouseEnter(object sender, EventArgs e)
        {
            btnLoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(54)))));
            btnLoginPanel.ForeColor = Color.White;
            loginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(54))))); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            timer1.Start();
            isLoginBtnClicked = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isLoginPanelVisible)
            {
                loginPanel.Width = loginPanel.Width - 100;
                if (loginPanel.Width <= 0)
                {
                    timer1.Stop();
                    isLoginPanelVisible = false;
                    this.Refresh();
                }


            }
            else
            {

                loginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(54)))));
                loginPanel.Width = loginPanel.Width + 100;

                if (loginPanel.Width >= loginPanelWidth)
                {
                    timer1.Stop();
                    isLoginPanelVisible = true;
                    this.Refresh();
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            conn.Open();

            int result = (int)cmd.ExecuteScalar();

            if (result == 1) MessageBox.Show("Valid Credentials");
            else MessageBox.Show("Invalid");


            conn.Close(); 
        }
    }
}
