﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;              // Add for DB Connection
using System.Data.SqlClient;    // Add for DB Connection

namespace Culture_ChatBot.Helpers
{
    public class SQLHelper
    {
        private const string strDBServer = "Server=tcp:Culture_ChatBot-db-server-wns.database.windows.net,1433;" +
                                             "Initial Catalog=Culture_ChatBotDB;Persist Security Info=False;" +
                                             "User ID=wnsgur9137;Password=wns600218!;" +
                                             "MultipleActiveResultSets=False;Encrypt=True;" +
                                             "TrustServerCertificate=False;" +
                                             "Connection Timeout=30;";

        public static DataSet RunSQL(string strQuery)
        {
            // DB Connection
            SqlConnection DB_CON = new SqlConnection(strDBServer);
            SqlCommand DB_Query = new SqlCommand(strQuery, DB_CON);
            SqlDataAdapter DB_Adapter = new SqlDataAdapter(DB_Query);

            DataSet DB_DS = new DataSet();
            DB_Adapter.Fill(DB_DS);

            return DB_DS;
        }

        public static void ExecuteNonQuery(string strQuery, SqlParameter[] para)
        {
            SqlConnection DB_CON = new SqlConnection(strDBServer);
            SqlCommand DB_Query = new SqlCommand(strQuery, DB_CON);
            DataSet DB_DS = new DataSet();

            // Parameter
            DB_Query.Parameters.Clear();

            foreach (SqlParameter p in para)
            {
                DB_Query.Parameters.Add(p);
            }

            DB_CON.Open();
            DB_Query.ExecuteNonQuery();
            DB_CON.Close();
        }
    }
}