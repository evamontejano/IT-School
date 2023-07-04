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
    public partial class Taxe : Form
    {
        public Taxe()
        {
            InitializeComponent();
            AfiseazaTaxele();
            GetStudenti();
            GetCursuri();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\ȘcoalaDeInfoDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursuri Obj = new Cursuri();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Studenți Obj = new Studenți();
            Obj.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        } 

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void GetStudenti()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select StNum from StudentTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StNum", typeof(int));
            dt.Load(Rdr);
            StIdCb.ValueMember = "StNum";
            StIdCb.DataSource = dt;
            Con.Close();

        }
        private void PreluareStNume()
        {
            Con.Open();
            string Query = "Select * from StudentTbl where StNum = ' " + StIdCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                StNumeTb.Text = dr["StName"].ToString();
            }
            Con.Close();
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
            string Query = "Select * from CursTbl where CNum = '" + CursCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CursTb.Text = dr["CNume"].ToString();
            }
            Con.Close();
        }


        private void AfiseazaTaxele()
        {
            Con.Open();
            string Query = "select * from TaxeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TaxeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            TotalTb.Text = "";
            StNumeTb.Text = "";
            CursTb.Text = "";
        }
        private void PlatesteBtn_Click(object sender, EventArgs e)
        {

            if (CursTb.Text == "" || StNumeTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Informații lipsă!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from TaxeTbl where TStud = '" + StIdCb.SelectedValue.ToString() + "' and TCursId = '" + CursCb.SelectedValue.ToString() + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Plată deja efectuată");
                        Reset();    
                    }
                    else
                    {

                        
                        SqlCommand cmd = new SqlCommand("insert into TaxeTbl(TStud,TStudNume,TCursId,TCursNume,TData,TCantitate) values(@TS,@TSN,@TCI,@TCN,@TD,@TC)", Con);
                        cmd.Parameters.AddWithValue("@TS", StIdCb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TSN", StNumeTb.Text);
                        cmd.Parameters.AddWithValue("@TCI", CursCb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TCN", CursTb.Text);
                        cmd.Parameters.AddWithValue("@TD", PlataDate.Value.Date);
                        cmd.Parameters.AddWithValue("@TC", TotalTb.Text);


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Plată efectuată cu succes!");
                        Con.Close();
                        AfiseazaTaxele();
                        Reset();
                    }
                   
                  
                }
               
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
    }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
            //reseteaza
        {
            Reset();
        }

        private void StIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PreluareStNume();

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

        private void CursCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CautareTb_TextChanged(object sender, EventArgs e)
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

        private void Taxe_Load(object sender, EventArgs e)
        {

        }
    }
}
