using Microsoft.Reporting.WinForms;
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

namespace ship_booking_system
{
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();
        }

        private void print_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E7U6INU\MSSQLSERVER01;Initial Catalog=shipbookingsystem;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("select * from passengership1", conn);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
        }
    }
}
