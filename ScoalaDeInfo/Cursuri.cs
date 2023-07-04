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
    public partial class Cursuri : Form
    {
        public Cursuri()
        {
            InitializeComponent();
            GetProfesori();
            AfiseazaCursurile();
        }

        private void Cursuri_Load(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }
        private void GetProfesori()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select PNum from ProfesorTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PNum", typeof(int));
            dt.Load(Rdr);
            PCb.ValueMember = "PNum";
            PCb.DataSource = dt;
            Con.Close();

        }
        private void PreluareNume()
        {
            Con.Open();
            string Query = "Select * from ProfesorTbl where PNum = ' " + PCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                PNameTb.Text = dr["PNume"].ToString();
            }
            Con.Close();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\ȘcoalaDeInfoDb.mdf;Integrated Security=True;Connect Timeout=30");


        
        private void AfiseazaCursurile()
        {
            Con.Open();
            string Query = "select * from CursTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
           CursDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SalveazaBtn_Click(object sender, EventArgs e)
        {

            if (CNumeTb.Text == "" || PCb.SelectedIndex == -1 || PNameTb.Text == "" || PretTb.Text == "" || DurataTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CursTbl(CNume,CProfesorId,CProfesorNume,CPret,CDurata) values(@CN,@CPI,@CPN,@CP,@CD)", Con);
                    cmd.Parameters.AddWithValue("@CN", CNumeTb.Text);
                    cmd.Parameters.AddWithValue("@CPI", PCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CPN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", PretTb.Text);
                    cmd.Parameters.AddWithValue("@CD", DurataTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Curs adăugat cu succes!");
                    Con.Close();
                    Reset();
                    AfiseazaCursurile();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void PCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PreluareNume();
        }

        int Key = 0;
        private void CursDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           CNumeTb.Text = CursDGV.SelectedRows[0].Cells[1].Value.ToString();
            PCb.SelectedItem = CursDGV.SelectedRows[0].Cells[2].Value.ToString();
          //  PDOB.Value = Convert.ToDateTime(CursDGV.SelectedRows[0].Cells[3].Value.ToString());
            PNameTb.Text = CursDGV.SelectedRows[0].Cells[3].Value.ToString();
            PretTb.Text = CursDGV.SelectedRows[0].Cells[4].Value.ToString();
            DurataTb.Text = CursDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (CNumeTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CursDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Selectează Cursul care va fi Șters");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from CursTbl where CNum = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Curs Șters cu succes!");
                    Con.Close();
                    AfiseazaCursurile();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            CNumeTb.Text = "";
            PNameTb.Text = "";
            PretTb.Text = "";
            DurataTb.Text = "";
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (CNumeTb.Text == "" || PCb.SelectedIndex == -1 || PNameTb.Text == "" || PretTb.Text == "" || DurataTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update CursTbl set CNume = @CN,CProfesorId = @CPI,CProfesorNume = @CPN,CPret = @CP,CDurata = @CD where CNum= @CKey", Con);
                    cmd.Parameters.AddWithValue("@CN", CNumeTb.Text);
                    cmd.Parameters.AddWithValue("@CPI", PCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CPN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", PretTb.Text);
                    cmd.Parameters.AddWithValue("@CD", DurataTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Curs editat cu succes!");
                    Con.Close();
                    Reset();
                    AfiseazaCursurile();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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

