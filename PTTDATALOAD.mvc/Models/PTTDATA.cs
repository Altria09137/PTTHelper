using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace PTTDATALOAD.mvc.Models
{
    public class PTTDATA
    {
        SqlConnection conn;
        DataTable dt = new DataTable();


        //WIN - K602VN7RVVF\SQLEXPRESS;Initial Catalog = PTT_Helper; Persist Security Info=True;User ID = sa; Password=Miku01
        public void Connect()
        {
            try
            {
                //WIN - K602VN7RVVF\SQLEXPRESS;Initial Catalog = PTT_Helper; Persist Security Info=True;User ID = sa; Password=Miku01
                string Constr = @"Data Source=WIN-K602VN7RVVF\SQLEXPRESS;Initial Catalog=PTT_Helper;Persist Security Info=True;User ID=sa;Password=Miku01";
                conn = new SqlConnection(Constr);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                Console.WriteLine($"Connect Error: {e.Message}");
            }
        }
        public void getMySQLDATA()
        {
            Connect();
            string query = "SELECT TOP 300 * FROM dbo.PTTDATA order by  pop DESC";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter dat = new SqlDataAdapter();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            dat.Dispose();
            conn.Close();
        }


        public List<PTTDATAtype> GetPTTDATA()
        {

            List<PTTDATAtype> cards = new List<PTTDATAtype>();

            getMySQLDATA();

            try
            {



                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    PTTDATAtype card = new PTTDATAtype
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        pop = Convert.ToString(dt.Rows[i]["pop"]),
                        title = Convert.ToString(dt.Rows[i]["title"]),
                        author = Convert.ToString(dt.Rows[i]["author"]),
                        URL = Convert.ToString(dt.Rows[i]["URL"]),
                        context = Convert.ToString(dt.Rows[i]["context"]),
                    };
                    cards.Add(card);
                };


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return cards;
        }

    }


    

 
}