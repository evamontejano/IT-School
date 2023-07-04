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


namespace ScoalaDeInfo
{
    public partial class Profesori : Form
    {
        public Profesori()
        {
            InitializeComponent();
            AfiseazaProfesorii();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\ȘcoalaDeInfoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursuri Obj = new Cursuri();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
        }
        private void AfiseazaProfesorii()
        {
            Con.Open();
            string Query = "select * from ProfesorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds =  new DataSet();    
            sda.Fill(ds);
            guna2DataGriProfesoriDGVdView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(PNumeTb.Text =="" || PCalifCb.SelectedIndex == -1 || PSexCb.SelectedIndex == -1 || PAddTb.Text == "" || PTelefonTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProfesorTbl(PNume,PCalificare,PDOB,PSex,PAdd,PTelefon) values(@PN,@PC,@PD,@PS,@PA,@PT)", Con);
                    cmd.Parameters.AddWithValue("@PN", PNumeTb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCalifCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@PS", PSexCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", PAddTb.Text);
                    cmd.Parameters.AddWithValue("@PT", PTelefonTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Profesor adăugat cu succes!");
                    Con.Close();
                    AfiseazaProfesorii();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Profesori_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        int Key = 0;
        private void guna2DataGriProfesoriDGVdView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNumeTb.Text = guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[1].Value.ToString();
          PCalifCb.SelectedItem = guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[2].Value.ToString();
            PDOB.Value = Convert.ToDateTime(guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[3].Value.ToString());
            PSexCb.Text = guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[4].Value.ToString();
            PAddTb.Text = guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[5].Value.ToString();
           PTelefonTb.Text = guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[6].Value.ToString();

            if(PNumeTb.Text == "")
            {
                Key = 0;
            }else
            {
                Key = Convert.ToInt32(guna2DataGriProfesoriDGVdView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditeazaBtn_Click(object sender, EventArgs e)
        {
            if (PNumeTb.Text == "" || PCalifCb.SelectedIndex == -1 || PSexCb.SelectedIndex == -1 || PAddTb.Text == "" || PTelefonTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ProfesorTbl set PNume= @PN, PCalificare = @PC,PDOB = @PD,PSex = @PS,PAdd = @PA, PTelefon = @PT where PNum = @PKey", Con);
                    cmd.Parameters.AddWithValue("@PN", PNumeTb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCalifCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@PS", PSexCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", PAddTb.Text);
                    cmd.Parameters.AddWithValue("@PT", PTelefonTb.Text);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Editarea s-a efectuat cu succes!");
                    Con.Close();
                    AfiseazaProfesorii();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void StergeBtn_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Selectează Profesorul care va fi Șters");
            } else
            {

            }try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("Delete from ProfesorTbl where PNum = @PKey", Con);
                cmd.Parameters.AddWithValue("@PKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Profesor Șters cu succes!");
                Con.Close();
                AfiseazaProfesorii();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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

        private void label1_Click(object sender, EventArgs e)
        {
            Acasa Obj = new Acasa();
            Obj.Show();
            this.Hide();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Tablou_de_bord Obj = new Tablou_de_bord();
            Obj.Show();
            this.Hide();
        }
    }
}
