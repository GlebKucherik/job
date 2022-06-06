using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase
{
    internal class DataBase
    {

        SqlConnection SqlConnection = new SqlConnection(@"Data Source=LAPTOP-N5IA66IM; Initial Catalog=Control;Integrated Security=True");

        public void openConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
        public SqlConnection GetSqlConnection()
        { 
        return SqlConnection;
        }

        internal static SqlConnection GetConnection()
        {
            throw new NotSupportedException(); 
        }
    }
}
