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
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EOD6TNR\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_students", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = txtStuName.Text;
            cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value = txtStuNumber.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = txtDepart.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = txtCon.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@Semester", SqlDbType.NVarChar).Value = txtSemester.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student added");
            con.Close();
            txtStuName.Text = "";
            txtStuNumber.Text = "";
            txtDepart.Text = "";
            txtCon.Text = "";
            txtEmail.Text = "";
            txtSemester.Text="";
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
