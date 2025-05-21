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
    public partial class IssueBooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EOD6TNR\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getbooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value = textBox7.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtStuName.Text = dr["Student_Name"].ToString();
                    txtStuNo.Text = dr["Student_Number"].ToString();
                    txtDepart.Text = dr["Department"].ToString();
                    txtCon.Text = dr["Contact"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                   
                }
            }
            else
            {
                MessageBox.Show("No records found for the given student number.");
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addIssueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value =txtStuName.Text;
            cmd.Parameters.Add("@Student_Number", SqlDbType.NVarChar).Value = txtStuNo.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = txtDepart.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = txtCon.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = comboBox1.Text;
            cmd.Parameters.Add("@Issue_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToLongDateString();
            cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value ="" ;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Issued book added");
            con.Close();
            txtStuName.Text = "";
            txtStuNo.Text = "";
            txtDepart.Text = "";
            txtCon.Text = "";
            txtEmail.Text = "";
            
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
