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
    public partial class Form10 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True");
        public Form10()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 back = new Form2();
            back.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String connection = @"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update harbour2 set location= '" + textBox3.Text + "', email= '" + textBox4.Text + "', phone = '" + textBox5.Text + "', area = '" + textBox6.Text + "', name='" + textBox2.Text + "' Where id='" + textBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated successfilly!");
            conn.Close();
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            disp_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            SqlDataAdapter da = new SqlDataAdapter("select name from harbour2 where name = '" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count >= 1)
            {
                MessageBox.Show("Name Existing Already");
            }
            else 
            {

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into harbour2 values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                disp_data();

                MessageBox.Show("Record inserted successfilly!");


            }


        }
        public void disp_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from harbour2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from harbour2 where id= '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


    private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from harbour2 where id='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            disp_data();

            MessageBox.Show("Record Deleted successfilly!");
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["location"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["phone"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["area"].Value.ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length>=3)
            {
                MessageBox.Show("The Maximum Length is 3 characters");

            }
        }
    }
}
