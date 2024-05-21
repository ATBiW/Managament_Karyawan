using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Managament_Karyawan
{
    public partial class EmployeeData : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\atbiw\OneDrive\Documents\Demo1.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        private int index;
        public EmployeeData()
        {
            InitializeComponent();
            DisplayData();
        }

        private void dataGridView1_DataBindingComplete(object sender,DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ColumnCount = 10;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        public void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from tbl_Record", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Clear()
        {
            ID = 0;
            tbName.Text = "";
            cbGender.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";
            tbPhoneNumber.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            dtpHireDate.Value = DateTime.Now;
            cbDepartment.Text = "";
            tbSalary.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete tbl_Record where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                Clear();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
            search();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            input();
            search();
        }
        
        private void input()
        {
            if (tbName.Text != "" && cbGender.Text != "" && tbAddress.Text != "" && tbEmail.Text != "" && tbPhoneNumber.Text != "" && cbDepartment.Text != "" && tbSalary.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO tbl_Record (Name, Gender, Address, Email, Phone_Number, Birth_Date, Hire_Date, Department, Salary) VALUES (@name, @gender, @address, @email, @phone_number, @birth_date, @hire_date, @department, @salary)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                cmd.Parameters.AddWithValue("@address", tbAddress.Text);
                cmd.Parameters.AddWithValue("@email", tbEmail.Text);
                cmd.Parameters.AddWithValue("@phone_number", tbPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value);
                cmd.Parameters.AddWithValue("@hire_date", dtpHireDate.Value);
                cmd.Parameters.AddWithValue("@department", cbDepartment.Text);
                cmd.Parameters.AddWithValue("@salary", tbSalary.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void input(int index)
        {
            if (tbName.Text != "" && cbGender.Text != "" && tbAddress.Text != "" && tbEmail.Text != "" && tbPhoneNumber.Text != "" && cbDepartment.Text != "" && tbSalary.Text != "")
            {
                cmd = new SqlCommand("UPDATE tbl_Record SET Name=@name, Gender=@gender, Address=@address, Email=@email, Phone_Number=@phone_number, Birth_Date=@birth_date, Hire_Date=@hire_date, Department=@department, Salary=@salary WHERE ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                cmd.Parameters.AddWithValue("@address", tbAddress.Text);
                cmd.Parameters.AddWithValue("@email", tbEmail.Text);
                cmd.Parameters.AddWithValue("@phone_number", tbPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value);
                cmd.Parameters.AddWithValue("@hire_date", dtpHireDate.Value);
                cmd.Parameters.AddWithValue("@department", cbDepartment.Text);
                cmd.Parameters.AddWithValue("@salary", tbSalary.Text);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }


        Control ctrl;
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                cbGender.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbID_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                tbAddress.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tbName.Focus();
            }
        }

        private void tbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                tbEmail.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbGender.Focus();
            }
        }



        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                tbPhoneNumber.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tbAddress.Focus();
            }
        }

        private void tbPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                dtpBirthDate.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tbEmail.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            input(index);
            search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string searchKeyword = tbSearch.Text.Trim();
            string Filter;

            if (int.TryParse(searchKeyword, out int keywordAsInt))
            {
                Filter = string.Format("Name LIKE '%{0}%' OR ID = {1} OR Department LIKE '%{0}%' OR Gender LIKE '%{0}%'", searchKeyword, keywordAsInt);
            }
            else
            {
                Filter = string.Format("Name LIKE '%{0}%' OR Department LIKE '%{0}%' OR Gender LIKE '%{0}%'", searchKeyword);
            }

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = Filter;
        }



        private void btnSort_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    XcelApp.Columns.AutoFit();
                    XcelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void tbBirthDate_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                cbGender.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tbPhoneNumber.Focus();
            }
        }

        private void tbPhoneNumber_KeyDown_1(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                dtpBirthDate.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tbEmail.Focus();
            }
        }

        private void cbGender_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                dtpHireDate.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dtpBirthDate.Focus();
            }
        }

        private void tbHireDate_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                cbDepartment.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbGender.Focus();
            }
        }

        private void tbSalary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                cbDepartment.Focus();
            }
            
        }

        private void cbDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                tbSalary.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dtpHireDate.Focus();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            tbName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dtpBirthDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            dtpHireDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            cbDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            tbSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }
    }
}
