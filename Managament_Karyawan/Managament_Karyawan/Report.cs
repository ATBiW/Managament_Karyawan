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
using System.Windows.Forms.DataVisualization.Charting;

namespace Managament_Karyawan
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        void FillChart()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\atbiw\OneDrive\Documents\Demo1.mdf;Integrated Security=True;Connect Timeout=30");
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Department, SUM(Salary) AS TotalSalary FROM tbl_Record GROUP BY Department", con);
            da.Fill(dt);
            con.Close();

            chart1.Series.Clear();

            Series salarySeries = new Series("Salary");
            salarySeries.ChartType = SeriesChartType.Column;
            salarySeries.XValueMember = "Department";
            salarySeries.YValueMembers = "TotalSalary";

            chart1.Series.Add(salarySeries);

            chart1.DataSource = dt;
            chart1.Titles.Add("Department Salaries");
        }
        private void DisplayChart_Load(object sender, EventArgs e)
        {
            FillChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
