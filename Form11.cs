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
    public partial class Form11 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True");
        public Form11()
        {
            InitializeComponent();
        }


        public void disp_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from admin1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Fill All the Fields");
            }
            else
            {

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into admin1 values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                disp_data();

                MessageBox.Show("Record inserted successfilly!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from admin1 where id='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            disp_data();

            MessageBox.Show("Record Deleted successfilly!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 back = new Form2();
            back.Show();
        }

        private void Form11_Load(object sender, EventArgs e)
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
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["mobile"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();

            }
        }
    }
    }

