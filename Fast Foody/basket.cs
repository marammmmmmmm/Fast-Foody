using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Foody
{
    internal class basket
    {
        public int ID;
        public string Resname;
        public string foodname;
        public decimal quantity;
        public decimal priceU;
        OleDbConnection cn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = C:\Users\lenovo\Documents\Database9.mdb");


        public void AjouterDatabase9()
        {
            string req = "insert into Basket values (" + ID + ",'" + Resname + "'," + foodname + ", " + quantity + "," + priceU + "); ";
            DataAccess.MettreAjour(req);
        }
        public void ModifierDatabase9()
        {
            string req = "Update Basket Set Resname='" + Resname + "', foodname='" + foodname +"' , quantity='" + quantity + "', priceU='" + priceU + "' where ID=" + ID;
            DataAccess.MettreAjour(req);
        }
        public void SupprimerDatabase9()
        {
            string req = "Delete from Basket where ID=" + ID;
            DataAccess.MettreAjour(req);
        }


        public static basket RechercherDatabase9(int id)
        {
            string req = $"Select * from Basket where ID={id}";
            OleDbDataReader RD = DataAccess.LireDataReader(req);
            basket b = null;
            if (RD.Read())
            {
                b = new basket();
                b.ID = id;//RD.GetInt32(0);//
                b.Resname = RD.GetString(1);
                b.foodname = RD.GetString(1);
                if (decimal.TryParse(RD.GetValue(2).ToString(), out decimal quantity))
                {
                    b.quantity = quantity;

                }
                else
                {

                    b.quantity = 0;
                }

                if (decimal.TryParse(RD.GetValue(2).ToString(), out decimal priceU))
                {
                    b.priceU = priceU;
                }
                else
                {

                    b.priceU = 0;
                }

               
            }

            DataAccess.Disconnect();
            return b;
        }


    }
}
