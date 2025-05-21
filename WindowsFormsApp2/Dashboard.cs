using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBooks f = new AddBooks();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewBooks vb=new ViewBooks();
            vb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddStudent ast =new AddStudent();
            ast.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewStudents vs=new ViewStudents();
            vs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks();
            ib.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Return_Book rb=new Return_Book();
            rb.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IssueBookReport ibr=new IssueBookReport();
            ibr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Return_Book_Reports rbr=new Return_Book_Reports();  
            rbr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Authors author=new Authors();
            author.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            View_Author view_Author=new View_Author();
            view_Author.Show();
        }
    }
}
