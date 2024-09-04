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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        OleDbConnection cn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = C:\Users\lenovo\Documents\Database9.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;//DGV_Produits est le dataGridV
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            string req = "Select * from Basket ";
            if (textBox2.Text.Trim() == "" && textBox1.Text.Trim() == "")
            { MessageBox.Show("Il est recommandé de saisir ..."); }
            else if (textBox2.Text.Trim() == "")
            { req = req + "where priceU>=" + textBox1.Text; }
            else if (textBox1.Text.Trim() == "")
            { req = req + "where priceU<=" + textBox2.Text; }
            else
            {
                req = req + "where priceU between " + textBox1.Text
                    + " and " + textBox2.Text;
            }
            DataTable Basket = DataAccess.LireDataTable(req);
            dataGridView1.DataSource = Basket;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form8 Form8 = new Form8();
            Form8.ShowDialog();
        }
    }
}