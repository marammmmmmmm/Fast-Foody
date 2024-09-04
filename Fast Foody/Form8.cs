using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Foody
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection cn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = C:\Users\lenovo\Documents\Database9.mdb");
        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database9DataSet4.Basket' table. You can move, or remove it, as needed.
            this.basketTableAdapter3.Fill(this.database9DataSet4.Basket);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            string req = "Select * from Basket ";

            DataTable Basket = DataAccess.LireDataTable(req);
            dataGridView1.DataSource = Basket;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 Form9 = new Form9();
            Form9.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 Form10 = new Form10();
            Form10.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
        }
    }
}
