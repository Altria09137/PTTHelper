using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace PTTDATALOAD.mvc.Models
{
    public class PTTcontext
    {
        SqlConnection conn;
        DataTable dt = new DataTable();
        public List<PTTDATAtype> PTTcontextSearch(int id)
        {
            List<PTTDATAtype> cards = new List<PTTDATAtype>();

            string Constr = @"Data Source=WIN-K602VN7RVVF\SQLEXPRESS;Initial Catalog=PTT_Helper;Persist Security Info=True;User ID=sa;Password=Miku01";
            SqlConnection sqlConnection = new SqlConnection(Constr);
            SqlCommand sqlCommand = new SqlCommand("select * from dbo.PTTDATA where id=@id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            SqlDataAdapter dat = new SqlDataAdapter();
            dat.SelectCommand = sqlCommand;
            dat.Fill(dt);
            dat.Dispose();
            sqlConnection.Open();



            try
            {



                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    PTTDATAtype card = new PTTDATAtype
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),

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
