using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace PTT_Helper
{
    public class MSSQL_ConnectHelper
    {
        SqlConnection coon;
        public void Connect()
        {
            try
            {
                //WIN - K602VN7RVVF\SQLEXPRESS;Initial Catalog = PTT_Helper; Persist Security Info=True;User ID = sa; Password=Miku01
                string Constr = @"Data Source=WIN-K602VN7RVVF\SQLEXPRESS;Initial Catalog=PTT_Helper;Persist Security Info=True;User ID=sa;Password=Miku01";
                coon = new SqlConnection(Constr);                
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                Console.WriteLine($"Connect Error: {e.Message}");
            }
        }
        /*public void Insert_PTT(WebPTT webptt)
        {
            int id = 0;
            try
            {
                Connect();
                coon.Open();
                string cmdtext = @"Select count(ID) from dbo.PTTDATA";
                SqlCommand cmd = new SqlCommand(cmdtext, coon);
                id = (int)cmd.ExecuteScalar()+1;
                //Console.WriteLine(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Query error:{ex.Message}");
            }
            finally
            {
                coon.Close();
            }
            try
            {

                Connect();
                coon.Open();
                string cmdtext = @"Insert into dbo.PTTDATA(ID,pop,title,author,URL,context) Values" +
                 "(@id,@pop,@title,@author,@url,@context)";
                SqlCommand cmd = new SqlCommand(cmdtext, coon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pop", webptt.Popularity_ptt);
                cmd.Parameters.AddWithValue("@title", webptt.title_ptt);
                cmd.Parameters.AddWithValue("@author", webptt.author_ptt);
                cmd.Parameters.AddWithValue("@url", webptt.URL_ptt);
                cmd.Parameters.AddWithValue("@context", webptt.InnerText_ptt);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Inserto into Error:{ex.Message}");

            }
            finally
            {
                coon.Close();
            }

        }*/

        public void getMySQLDATA (WebPTT webptt)
        {

            coon.Open();
            string cmdtext = @"Select * from dbo.PTTDATA";
            SqlCommand cmd = new SqlCommand(cmdtext, coon);
            SqlDataAdapter myDa = new SqlDataAdapter(cmdtext, coon);
           
        }
    }
}


