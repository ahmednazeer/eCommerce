using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Commerce_App
{
    public class DBManager
    {
        public static int ExecuteDML(string query)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = connection;
            connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public static DataTable ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = connection;
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            myAdapter.Fill(dataTable);
            return dataTable;
        }
        public static int GetLastIdInserted(string query)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = connection;
            connection.Open();
            int newId = (Int32)sqlCommand.ExecuteScalar();
            connection.Close();
            return newId;
        }


    }
}