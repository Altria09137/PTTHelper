﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace PTTDATALOAD.mvc.Models
{
    public class Search
    {
        public List<PTTDATAtype> GetPTTDATApop(string pop)
        {
            List<PTTDATAtype> cards = new List<PTTDATAtype>();

            string Constr = @"Data Source=WIN-K602VN7RVVF\SQLEXPRESS;Initial Catalog=PTT_Helper;Persist Security Info=True;User ID=sa;Password=Miku01";
            SqlConnection sqlConnection = new SqlConnection(Constr);
            SqlCommand sqlCommand = new SqlCommand("select * from dbo.PTTDATA where pop=@pop");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@pop", pop));
            sqlConnection.Open();


            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PTTDATAtype card = new PTTDATAtype
                    {
                        ID = reader.GetInt64(reader.GetOrdinal("id")),
                        pop = reader.GetString(reader.GetOrdinal("pop")),
                        title = reader.GetString(reader.GetOrdinal("title")),
                        author = reader.GetString(reader.GetOrdinal("author")),
                    };
                    cards.Add(card);
                }
            }
            else
            {
                Console.WriteLine("未找到該筆資料");
            }
            sqlConnection.Close();
            return cards;
        }
    }
}