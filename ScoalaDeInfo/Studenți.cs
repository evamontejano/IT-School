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
    public partial class Studenți : Form
    {
        public Studenți()
        {
            InitializeComponent();
            GetCursuri();
            AfiseazaStudentii();
        }

        private void GetCursuri()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CNum from CursTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CNum", typeof(int));
            dt.Load(Rdr);
            CursCb.ValueMember = "CNum";
            CursCb.DataSource = dt;
            Con.Close();

        }
        private void PreluareCNume()
        {
            Con.Open();
            string Query = "Select * from CursTbl where CNum = ' " + CursCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CNameTb.Text = dr["CNume"].ToString();

            }
            Con.Close();
        }
        private void Studenți_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Profesori Obj = new Profesori();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\ȘcoalaDeInfoDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void AfiseazaStudentii()
        {
            Con.Open();
            string Query = "select * from StudentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StudentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void CursCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PreluareCNume();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }
        private void SalveazaBtn_Click(object sender, EventArgs e)
        {

            if (StNumeTb.Text == "" || StAddTb.Text == "" || SexCb.SelectedIndex == -1 || StNumeTb.Text == "" || StTelefonTb.Text == "" || StObsTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into StudentTbl(StName,StDob,StAdresa,StTelefon,StCurs,StCursNume,StSex,StObservatii) values(@SN,@SD,@SA,@ST,@SC,@SCN,@SS,@SO)", Con);
                    cmd.Parameters.AddWithValue("@SN", StNumeTb.Text);
                    cmd.Parameters.AddWithValue("@SD", StDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SA", StAddTb.Text);
                    cmd.Parameters.AddWithValue("@ST", StTelefonTb.Text);
                    cmd.Parameters.AddWithValue("@SC", CursCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SCN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@SS", SexCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SO", StObsTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student adăugat cu succes!");
                    Con.Close();
                    Reset();
                    AfiseazaStudentii();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            StNumeTb.Text = StudentDGV.SelectedRows[0].Cells[1].Value.ToString();
            StDOB.Value = Convert.ToDateTime(StudentDGV.SelectedRows[0].Cells[2].Value.ToString());
            StAddTb.Text = StudentDGV.SelectedRows[0].Cells[3].Value.ToString();
            StTelefonTb.Text = StudentDGV.SelectedRows[0].Cells[4].Value.ToString();
            CursCb.Text = StudentDGV.SelectedRows[0].Cells[5].Value.ToString();
            CNameTb.Text = StudentDGV.SelectedRows[0].Cells[6].Value.ToString();
            SexCb.Text = StudentDGV.SelectedRows[0].Cells[7].Value.ToString();
            StObsTb.Text = StudentDGV.SelectedRows[0].Cells[8].Value.ToString();

            if (StNumeTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(StudentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            //Sterge
            if (Key == 0)
            {
                MessageBox.Show("Selectează Studentul care va fi Șters");
            }
            else
            {


                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from StudentTbl where StNum = @StKey", Con);
                    cmd.Parameters.AddWithValue("@StKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Șters cu succes!");
                    Con.Close();
                    AfiseazaStudentii();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            //Editeaza
            if (StNumeTb.Text == "" || StAddTb.Text == "" || SexCb.SelectedIndex == -1 || StNumeTb.Text == "" || StTelefonTb.Text == "" || StObsTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update StudentTbl set StName = @SN, StDob = @SD,StAdresa = @SA,StTelefon = @ST,StCurs = @SC,StCursNume = @SCN,StSex = @SS,StObservatii = @SO where StNum = @StKey", Con);
                    cmd.Parameters.AddWithValue("@SN", StNumeTb.Text);
                    cmd.Parameters.AddWithValue("@SD", StDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SA", StAddTb.Text);
                    cmd.Parameters.AddWithValue("@ST", StTelefonTb.Text);
                    cmd.Parameters.AddWithValue("@SC", CursCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SCN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@SS", SexCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SO", StObsTb.Text);
                    cmd.Parameters.AddWithValue("@StKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Editarea s-a efectuat cu succes!");
                    Con.Close();
                    Reset();
                    AfiseazaStudentii();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        public void Reset()
        {
            StNumeTb.Text = "";
            StAddTb.Text = "";
            StTelefonTb.Text = "";
            CNameTb.Text = "";
            StObsTb.Text = "";




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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Studenți Obj = new Studenți();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursuri Obj = new Cursuri();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Tablou_de_bord Obj = new Tablou_de_bord();
            Obj.Show();
            this.Hide();
        }
    }
}
