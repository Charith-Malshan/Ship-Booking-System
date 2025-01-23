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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True");
        public Form3()

        {  
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 back = new Form2();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select [company name] from shippingcompany2 where [company name] = '" + textBox1.Text + "'", conn);
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
                cmd.CommandText = "insert into shippingcompany2 values ('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox3.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
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
            cmd.CommandText = "select * from shippingcompany2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from shippingcompany2 where id='"+textBox3.Text+"'";
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
            cmd.CommandText = "update shippingcompany2 set  [company address]= '" + textBox2.Text + "', [licence date]= '" + textBox4.Text + "',  [contact no] = '" + textBox6.Text + "' , [company name]='" + textBox1.Text + "' , [validity period] = '" + textBox5.Text + "' Where id = '" + textBox3.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated successfilly!");
            conn.Close();
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            disp_data();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from shippingcompany2 where id= '" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["company name"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["company address"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["licence date"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["validity period"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["contact no"].Value.ToString();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 6)
            {
                MessageBox.Show("The Maximum Length is 6 characters");

            }
        }
    }
}
