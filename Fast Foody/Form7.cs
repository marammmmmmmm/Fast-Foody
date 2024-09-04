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
    public partial class Form7 : Form
    {

        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\lenovo\Documents\Database9.mdb");

        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                try
                {
                    cn.Open();

                    // Use parameterized query to prevent SQL injection
                    string query = "INSERT INTO Client (firstname, adress, lastname, username, [password], contactnumber, email) " +
                                   "VALUES (@firstname, @adress, @lastname, @username, @password, @contactnumber, @email)";

                    using (OleDbCommand command = new OleDbCommand(query, cn))
                    {
                        // Add parameters with proper naming
                        command.Parameters.AddWithValue("@firstname", textBox1.Text);
                        command.Parameters.AddWithValue("@adress", textBox3.Text);
                        command.Parameters.AddWithValue("@lastname", textBox6.Text);
                        command.Parameters.AddWithValue("@username", textBox8.Text);

                        // Hash and salt the password (replace with your hashing logic)
                        string hashedPassword = HashAndSalt(textBox9.Text);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        // Assuming contactnumber is an integer field in the database
                        if (int.TryParse(textBox7.Text, out int contactnumber))
                        {
                            command.Parameters.AddWithValue("@contactnumber", contactnumber);
                        }
                        else
                        {
                            // Handle the case where contactnumber is not a valid integer
                            throw new ArgumentException("Invalid contact number");
                        }

                        command.Parameters.AddWithValue("@email", textBox2.Text);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed even if an exception occurs
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }
            }
            
            
        // Implement your password hashing logic here
            private string HashAndSalt(string password)
            {
                // Replace this placeholder with your actual password hashing code
                // Example: return BCrypt.Net.BCrypt.HashPassword(password);
                return password;
            }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Form1 = new Login();
            Form1.ShowDialog();
        }
    }
    } 
