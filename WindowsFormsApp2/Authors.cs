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
    public partial class Authors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EOD6TNR\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public Authors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Author", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorId", SqlDbType.NVarChar).Value = txtAuthorID.Text;
            cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = txtAuthorName.Text;
            cmd.Parameters.Add("@AuthorAdres", SqlDbType.NVarChar).Value = txtAuthorAdres.Text;
            cmd.Parameters.Add("@AuthorEmail", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@AuthorContact", SqlDbType.NVarChar).Value =txtContact.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Author addded");
            con.Close();
            txtAuthorID.Text = "";
            txtAuthorName.Text = "";
            txtAuthorAdres.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
        }
    }
}
