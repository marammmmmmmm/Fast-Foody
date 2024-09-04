using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fast_Foody
{
    internal class DataAccess
    {
        static string cnstr = (@"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = C:\Users\lenovo\Documents\Database9.mdb");

        static OleDbConnection cn = new OleDbConnection();
        static void Connect()
        {
            cn.ConnectionString = cnstr;
            cn.Open();
        }
        public static void Disconnect()
        { cn.Close(); }
        public static void MettreAjour(string req)
        {//insert , update ou delete
            Connect();
            OleDbCommand cmd = new OleDbCommand(req, cn);
            
                cmd.ExecuteNonQuery();
                Disconnect();
            
        }

        public static int MettreAjour2(string req)
        {//insert , update ou delete
            Connect();
            OleDbCommand cmd = new OleDbCommand(req, cn);
            int nblignes = cmd.ExecuteNonQuery();
            Disconnect();
            return nblignes;
        }
        public static OleDbDataReader LireDataReader(string req)
        {
            Connect();
            OleDbCommand cmd = new OleDbCommand(req,cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public static DataTable LireDataTable(string req)
        {
            Connect();
            OleDbCommand cmd = new OleDbCommand(req, cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(rd);
            Disconnect();
            return DT;
        }
    }
    static class DataAccess<T> where T : class, new()
    {
        public static List<T> LireList(string req)
        {
            OleDbDataReader RD = DataAccess.LireDataReader(req);

            List<T> ListObject = new List<T>();
            while (RD.Read())
            {
                T objet = new T();

                for (int i = 0; i < RD.VisibleFieldCount; i++)
                {
                    if (objet.GetType().GetField(RD.GetName(i)) != null)
                        objet.GetType().GetField(RD.GetName(i)).SetValue(objet, RD.GetValue(i));
                    if (objet.GetType().GetProperty(RD.GetName(i)) != null)
                        objet.GetType().GetProperty(RD.GetName(i)).SetValue(objet, RD.GetValue(i));
                }
                ListObject.Add(objet);
            }
            DataAccess.Disconnect();

            return ListObject;
        }
    }
}


