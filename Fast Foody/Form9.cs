using System;
using System.Collections;
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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        OleDbConnection cn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = C:\Users\lenovo\Documents\Database9.mdb");

        private void button1_Click(object sender, EventArgs e)
        {

            string req = "INSERT INTO Basket VALUES (@ID, @Resname, @foodname, @quantity, @priceU)";

            using (OleDbCommand cmd = new OleDbCommand(req, cn))
            {
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Resname", textBox2.Text);
                cmd.Parameters.AddWithValue("@foodname", textBox3.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox4.Text);
                cmd.Parameters.AddWithValue("@priceU", textBox5.Text);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, show an error message, etc.)
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int basketId))
            {
                basket b = basket.RechercherDatabase9(basketId);
                if (b != null)
                {
                    textBox2.Text = b.Resname;
                    textBox3.Text = b.foodname;
                    textBox4.Text = b.quantity.ToString();
                    textBox5.Text = b.priceU.ToString();
                }
                else
                {
                    MessageBox.Show("ID inexistant!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID (integer).");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //rajouter les contrôles
            basket b = basket.RechercherDatabase9(int.Parse(textBox1.Text));
            if (b != null)
            {
                b.SupprimerDatabase9();
            }
            else
            {
                MessageBox.Show("ID inexistant!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int value1) && int.TryParse(textBox5.Text, out int value2))
            {
                int result = value1 * value2;
                textBox6.Text = result.ToString();
            }
            else
            {
                // Handle the case where the input is not a valid integer
                MessageBox.Show("Please enter valid integer values in textBox4 and textBox5.");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
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
