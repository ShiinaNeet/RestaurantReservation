using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;
//using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using System.Configuration;
using System.IO;
using System.Windows.Markup;

namespace RestaurantReservation
{
    class ConnectionClasss
    {
        public static SqlConnection connnect()
        {

            

            string ConnectionStringLocalDb =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|RestaurantDB.mdf;Integrated Security=True;";



        string connectionString;
            SqlConnection cocnn;
            
             string connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\dayan\\source\\repos\\New Restaurant Reservation\\RestaurantDB.mdf;Integrated Security=True";


            // string conecnte = ConfigurationManager.ConnectionStrings["conn"].ToString();
            //cocnn = new SqlConnection(connetionString); my desktop 

            //cleint 
            string data = System.AppDomain.CurrentDomain.BaseDirectory;

            // string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\dayan\\source\\repos\\New Restaurant Reservation\\bin\\Debug\\net6.0-windows\\RestaurantDB.mdf\";Integrated Security=True;Connect Timeout=30";
            string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\unola\\source\\repos\\thisnewnewnew\\db\\db\\RestaurantDB.mdf;Integrated Security=True";
            cocnn = new SqlConnection(connect);
            return cocnn;
        }
        

    } 

}
