using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ship_booking_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 shippingcompany = new Form3();
            shippingcompany.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 Bookship = new Form8();
            Bookship.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 shipdetails = new Form4();
            shipdetails.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 harbourdetails = new Form10();
            harbourdetails.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 admin = new Form11();
            admin.Show();
            this.Hide();
        }
    }
}
