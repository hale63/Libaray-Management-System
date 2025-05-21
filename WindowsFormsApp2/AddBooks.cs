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
    public partial class AddBooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EOD6TNR\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;");
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try { 
            con.Open();
         

             SqlCommand cmd = new SqlCommand("sp_add_books", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName",SqlDbType.NVarChar).Value=txtBookName.Text;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = txtAuthor.Text;
            cmd.Parameters.Add("@Publication", SqlDbType.NVarChar).Value=txtPub.Text;
            cmd.Parameters.Add("@PublicationDate", SqlDbType.NVarChar).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@BookPrice", SqlDbType.NVarChar).Value = txtBookPrice.Text;
            cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = txtQuantity.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book addded");
            }
            catch (SqlException ex)
            {
                // Eğer hata mesajı 50000-51000 arasındaysa (RAISERROR tarafından oluşturulmuşsa)
                if (ex.Class >= 16 && ex.Class <= 17)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show("An error occurred while adding the book.");
                }
            }


            con.Close();
            txtBookName.Text = "";
            txtAuthor.Text = "";
            txtPub.Text = ""; 
           txtBookPrice.Text = "";
            txtQuantity.Text = "";




        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPub_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtBookPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
