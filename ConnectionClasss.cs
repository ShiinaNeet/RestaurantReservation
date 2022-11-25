using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;

namespace RestaurantReservation
{
    class ConnectionClasss
    {
        public static SqlConnection connnect()
        {
           
                
            string connectionString;
            SqlConnection cocnn;
            connectionString = "Data Source=SHIINANEET;Initial Catalog=RestaurantDB;Integrated Security=true";
            cocnn = new SqlConnection(connectionString);
            return cocnn;
        }

    } 

}
