using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace PMS
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            // Define the connection string
            connectionString = "Server=localhost;Database=PMS;Integrated Security=True;";
        }

        public void Connect()
        {
            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    // Open the connection
                    connection.Open();
                    Console.WriteLine("Connection to the database was successful!");

                    // Perform database operations here

                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }


}


//using PMS;


//// Create an instance of DatabaseConnection
//DatabaseConnection dbConnection = new DatabaseConnection();

//// Open the connection
//dbConnection.Connect();