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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection cn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = C:\Users\lenovo\Documents\Database9.mdb");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Assume that 'cn' is a class-level OleDbConnection object
                cn.Open();

                string Resname = "Maroum Kitchen";
                string foodname = "Californiens Sushi";
                int qte = 1;
                int priceU = 65;

                // Utilisez une requête paramétrée pour éviter les problèmes de sécurité et les erreurs de syntaxe SQL
                string query = "INSERT INTO Basket (Resname, foodname, quantity, priceU) " +
                               "VALUES (@Resname, @foodname, @quantity, @priceU)";

                using (OleDbCommand command = new OleDbCommand(query, cn))
                {
                    // Ajoutez des paramètres avec les noms appropriés
                    command.Parameters.AddWithValue("@Resname", Resname);
                    command.Parameters.AddWithValue("@foodname", foodname);
                    command.Parameters.AddWithValue("@quantity", qte);
                    command.Parameters.AddWithValue("@priceU", priceU);

                    // Exécutez la commande
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Assurez-vous de fermer la connexion dans le bloc finally pour éviter les fuites de ressources
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Assume that 'cn' is a class-level OleDbConnection object
                cn.Open();

                string Resname = "Maroum Kitchen";
                string foodname = "Salmon Sushi";
                int qte = 1;
                int priceU = 70;

                // Utilisez une requête paramétrée pour éviter les problèmes de sécurité et les erreurs de syntaxe SQL
                string query = "INSERT INTO Basket (Resname, foodname, quantity, priceU) " +
                               "VALUES (@Resname, @foodname, @quantity, @priceU)";

                using (OleDbCommand command = new OleDbCommand(query, cn))
                {
                    // Ajoutez des paramètres avec les noms appropriés
                    command.Parameters.AddWithValue("@Resname", Resname);
                    command.Parameters.AddWithValue("@foodname", foodname);
                    command.Parameters.AddWithValue("@quantity", qte);
                    command.Parameters.AddWithValue("@priceU", priceU);

                    // Exécutez la commande
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Assurez-vous de fermer la connexion dans le bloc finally pour éviter les fuites de ressources
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Assume that 'cn' is a class-level OleDbConnection object
                cn.Open();

                string Resname = "Maroum Kitchen";
                string foodname = "Crunchy Sushi";
                int qte = 1;
                int priceU = 70;

                // Utilisez une requête paramétrée pour éviter les problèmes de sécurité et les erreurs de syntaxe SQL
                string query = "INSERT INTO Basket (Resname, foodname, quantity, priceU) " +
                               "VALUES (@Resname, @foodname, @quantity, @priceU)";

                using (OleDbCommand command = new OleDbCommand(query, cn))
                {
                    // Ajoutez des paramètres avec les noms appropriés
                    command.Parameters.AddWithValue("@Resname", Resname);
                    command.Parameters.AddWithValue("@foodname", foodname);
                    command.Parameters.AddWithValue("@quantity", qte);
                    command.Parameters.AddWithValue("@priceU", priceU);

                    // Exécutez la commande
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Assurez-vous de fermer la connexion dans le bloc finally pour éviter les fuites de ressources
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
        }
    }
}
