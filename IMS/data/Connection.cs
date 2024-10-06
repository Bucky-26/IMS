using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace IMS.data
{
    public static class Connection
    {
        private static string connectionString = "Server=localhost;Database=restopos;User ID=root;SslMode=None;";
        private static MySqlConnection connection;

        public static async Task<MySqlConnection> GetConnectionAsync()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
                try
                {
                    await connection.OpenAsync(); // Open the connection asynchronously
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Database connection error: " + ex.Message);
                    connection = null; 
                }
            }
            return connection;
        }

        // Optional: Close the connection
        public static void  CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection = null; // Reset for next use
            }
        }
    }
}
