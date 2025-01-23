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

namespace ship_booking_system
{
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
            
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 back = new Form2();
            back.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from shipdetails1 where name='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            disp_data();

            MessageBox.Show("Record Deleted successfilly!");
        }

        

        private void button2_Click(object sender, EventArgs e)
        {


            String connection = @"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update shipdetails1 set  model= '" + textBox3.Text + "', seats= '" + textBox4.Text + "', [destination harbor] = '" + textBox5.Text + "',  address= '" + textBox7.Text + "' ,name='" + textBox2.Text + "' , [deparature harbor] = '" + textBox6.Text + "' Where id = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated successfilly!");
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            disp_data();



        }

        void Destinationharbourname()
        {
            String connection = @"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from harbour2", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox5.Items.Add(dr["name"].ToString());
            }
            conn.Close();
        }

        void Deparatureharbourname()
        {
            String connection = @"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from harbour2", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox6.Items.Add(dr["name"].ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select name from shipdetails1 where name = '" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Name Existing Already");
            }
            else
            {

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into shipdetails1 values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "', '"+ textBox8.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                disp_data();

                MessageBox.Show("Record inserted successfilly!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        public void disp_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from shipdetails1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            disp_data();
            Deparatureharbourname();
            Destinationharbourname();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from shipdetails1 where id= '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["model"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["seats"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["destination harbor"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["deparature harbor"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["departure date"].Value.ToString();

            }
        }
    }
}
