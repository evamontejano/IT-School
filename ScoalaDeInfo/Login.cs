using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoalaDeInfo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            ParolaTb.Text = "";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == "UserName" || ParolaTb.Text == "")
                    {
                MessageBox.Show("Informație lipsă!");
                UNameTb.Text = "";
                ParolaTb.Text = "";

            }
            else if(UNameTb.Text == "Admin" && ParolaTb.Text == "Parola")
            {
                Acasa Obj = new Acasa();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username Și/Sau Parolă greșită");
                UNameTb.Text = "";
                ParolaTb.Text = "";
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void LoginnBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "UserName" || ParolaTb.Text == "")
            {
                MessageBox.Show("Informație lipsă!");
                UNameTb.Text = "";
                ParolaTb.Text = "";

            }
            else if (UNameTb.Text == "Admin" && ParolaTb.Text == "Parola")
            {
                Acasa Obj = new Acasa();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username Și/Sau Parolă greșită");
                UNameTb.Text = "";
                ParolaTb.Text = "";
            }
        }

        private void ResetttBtn_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            ParolaTb.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
