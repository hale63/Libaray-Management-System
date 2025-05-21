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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class ViewBooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EOD6TNR\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");

        public ViewBooks()
        {
            InitializeComponent();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewBooks", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName",SqlDbType.NVarChar).Value="";
            SqlDataAdapter da =new SqlDataAdapter(cmd);
            DataTable dt =new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

                
                
         }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_update_books", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.NVarChar).Value = txtID.Text;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = txtBookName.Text;
            cmd.Parameters.Add("@AuthorID", SqlDbType.NVarChar).Value = txtAuthor.Text;
            cmd.Parameters.Add("@Publication", SqlDbType.NVarChar).Value = txtPub.Text;
            cmd.Parameters.Add("@PublicationDate", SqlDbType.NVarChar).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@BookPrice", SqlDbType.NVarChar).Value = txtBookPrice.Text;
            cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = txtQuantity.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Updated");
            con.Close();
            txtID.Text = "";
            txtBookName.Text = "";
            txtAuthor.Text = "";
            txtPub.Text = "";
            txtBookPrice.Text = "";
            txtQuantity.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure  to delete?","Delete Docment",MessageBoxButtons.YesNo)==DialogResult.Yes)
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Delete_books", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.NVarChar).Value = txtID.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book deleted");
          con.Close();
           }

 
         txtID.Text = "";

        }    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_filterBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PublicationDate1", SqlDbType.NVarChar).Value = dateTimePicker2.Value;
            cmd.Parameters.Add("@PublicationDate2", SqlDbType.NVarChar).Value = dateTimePicker3.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = txtSearch.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
