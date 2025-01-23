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
    public partial class Form8 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True");
        
        public Form8()
        {
            InitializeComponent();
            error.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 back = new Form2();
            back.Show();
        }

        public void disp_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from passengership1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        void FillShip()
        {
            String connection = @"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from shipdetails1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Items.Add(dr["name"].ToString());
            }
            conn.Close();
        }

        void FillShippingcompany()
        {
            String connection = @"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from shippingcompany2", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Items.Add(dr["company name"].ToString());
            }
            conn.Close();
        }

        void Fillharbourname()
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
                textBox3.Items.Add(dr["name"].ToString());
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* SqlDataAdapter da = new SqlDataAdapter("select id from passengership1 where id = '" + textBox11.Text + "'", conn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             if (dt.Rows.Count >= 1)
             {
                 MessageBox.Show("ID Existing Already");
             }
             else
             {

                 conn.Open();
                 SqlCommand cmd = conn.CreateCommand();
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = "insert into passengership1 values ('" + textBox11.Text + "','" + textBox13.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
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
                 textBox9.Text = "";
                 textBox10.Text = "";
                 textBox11.Text = "";
                 textBox13.Text = "";

                 disp_data();

                 MessageBox.Show("Record inserted successfilly!");

     */

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("Enter Valid Values");
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select id from passengership1 where id = '" + textBox11.Text + "'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("ID Existing Already");
                }
                else
                {
                    String duplicateqry = "SELECT [ship name], [seat number] FROM passengership1 WHERE [ship name]='" + textBox1.Text + "' AND [seat number]='" + textBox9.Text + "'";
                    SqlCommand duplicateCommand = new SqlCommand(duplicateqry, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(duplicateCommand);
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);

                    if (datatable.Rows.Count > 0)
                    {
                        //MessageBox.Show("Seat is Already booked");
                        error.Show();
                    }
                    else
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into passengership1 values ('" + textBox11.Text + "','" + textBox13.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
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
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox13.Text = "";

                        disp_data();

                        MessageBox.Show("Record inserted successfilly!");
                    }
                   
                }

                }
                
        }


        

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update passengership1 set [shipping company]= '" + textBox2.Text + "', [harbour name]= '" + textBox3.Text + "', [class type]= '" + textBox4.Text + "', fees= '" + textBox5.Text + "', [deparature date]= '" + textBox6.Text + "', [arrival time]= '" + textBox8.Text + "', [seat number]= '" + textBox9.Text + "', [arrival destination]= '" + textBox10.Text + "' , [ship name]= '" + textBox1.Text + "' , [arrival date]= '" + textBox7.Text + "' , [customer name]= '" + textBox13.Text + "' Where id= '" + textBox11.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            disp_data();

            MessageBox.Show("Record Updated successfilly!");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from passengership1 where id='" + textBox11.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            disp_data();

            MessageBox.Show("Record Deleted successfilly!");
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            disp_data();
            FillShip();
            FillShippingcompany();
            Fillharbourname();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells["customer name"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ship name"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["shipping company"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["harbour name"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["class type"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["fees"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["deparature date"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["arrival date"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["arrival time"].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["seat number"].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["arrival destination"].Value.ToString();
                

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            print printdetails = new print();
            printdetails.Show();


        }

       

        private void Form8_Enter(object sender, EventArgs e)
        {
            
                
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "Enter ID";
                textBox12.ForeColor = Color.Silver;

            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Text == "Enter ID")
            {
                textBox12.Text = "";
                textBox12.ForeColor = Color.Black;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from passengership1 where id= '" + textBox12.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void error_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void error_DoubleClick(object sender, EventArgs e)
        {
            error.Hide();
        }
    }
}
