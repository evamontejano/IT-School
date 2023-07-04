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

namespace ScoalaDeInfo
{
    public partial class Tablou_de_bord : Form
    {
        public Tablou_de_bord()
        {
            InitializeComponent();
            NumarStudenti();
            SumarCantitate();
            NumarMentori();
            NumarCursuri();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\ȘcoalaDeInfoDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void NumarStudenti()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from StudentTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            StudNumLbl.Text = dt.Rows[0][0].ToString() + "   Studenți";
            Con.Close();    
        }
        private void SumarCantitate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(TCantitate) from TaxeTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CantitateLbl.Text = dt.Rows[0][0].ToString() + "   Euro";
            Con.Close();
        }
        private void NumarMentori()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProfesorTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ProfesorLbl.Text = dt.Rows[0][0].ToString() + "   Profesori";
            Con.Close();
        }
        private void NumarCursuri()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CursTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CursLbl.Text = dt.Rows[0][0].ToString() + "   Cursuri";
            Con.Close();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Tablou_de_bord Obj = new Tablou_de_bord();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursuri Obj = new Cursuri();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Tablou_de_bord_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Studenți Obj = new Studenți();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Cursuri Obj = new Cursuri();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Profesori Obj = new Profesori();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Taxe Obj = new Taxe();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Tablou_de_bord Obj = new Tablou_de_bord();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Studenți Obj = new Studenți();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Profesori Obj = new Profesori();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Taxe Obj = new Taxe();
            Obj.Show();
            this.Hide();
        }

        private void ProfesorLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
