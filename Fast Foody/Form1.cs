using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fast_Foody
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter your username and password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\lenovo\Documents\Database9.mdb"))
                    {
                        cn.Open();

                        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Client WHERE username = ? AND password = ?", cn))
                        {
                            cmd.Parameters.AddWithValue("username", textBox1.Text);
                            cmd.Parameters.AddWithValue("password", textBox2.Text);

                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    // Authentication successful
                                    this.Hide();
                                    Form3 form3 = new Form3();
                                    form3.ShowDialog();
                                }
                                else
                                {
                                    label7.Text = "False username or password";
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}