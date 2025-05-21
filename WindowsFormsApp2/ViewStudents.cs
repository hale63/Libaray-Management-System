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

namespace WindowsFormsApp2
{
    public partial class ViewStudents : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EOD6TNR\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public ViewStudents()
        {
            InitializeComponent();
        }

        private void ViewStudents_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value = "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value = textBox2.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_update_student", con);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = txtStuName.Text;
            cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value = txtStuNumber.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = txtDepart.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = txtCon.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@Semester", SqlDbType.NVarChar).Value = txtSemester.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Updated");
            con.Close();
            txtStuName.Text = "";
            txtStuNumber.Text = "";
            txtDepart.Text = "";
            txtCon.Text = "";
            txtEmail.Text = "";
            txtSemester.Text = "";

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure  to delete?", "Delete Docment", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Delete_student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value =txtStuNumber.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student  deleted");
                con.Close();
            }

        }
    }
}
