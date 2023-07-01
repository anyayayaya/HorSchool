using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorSchool
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@" Data Source = DESKTOP-01EBAMC\SQLEXPRESS;Initial Catalog = HorSchool;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
