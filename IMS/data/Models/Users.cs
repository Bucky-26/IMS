using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.data.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Consider hashing this
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; }

        // Method to get a list of all users asynchronously
        public static async Task<List<Users>> GetAllUsersAsync()
        {
            var userList = new List<Users>();

            using (var conn = await Connection.GetConnectionAsync())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM users";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userList.Add(new Users
                            {
                                UserId = Convert.ToInt32(reader["user_id"]),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Email = reader["email"].ToString(),
                                Role = reader["role"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                Status = reader["status"].ToString()
                            });
                        }
                    }
                }
            }
            return userList;
        }

        public async Task<bool> AddUserAsync(Users users)
        {
            using (var conn = await Connection.GetConnectionAsync())
            {
                if (conn != null)
                {
                    string query = "INSERT INTO users (username, password, email, role, created_at, status) VALUES (@username, @password, @Email, @Role, @CreatedAt, @status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", Password); // Hash password before storing
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Role", Role);
                    cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                    cmd.Parameters.AddWithValue("@status", Status);

                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
            return false;
        }

        public async Task<bool> UpdateUserAsync()
        {
            using (var conn = await Connection.GetConnectionAsync())
            {
                if (conn != null)
                {
                    string query = "UPDATE users SET username = @username, password = @password, email = @Email, role = @Role, status = @status WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", Password); 
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Role", Role);
                    cmd.Parameters.AddWithValue("@status", Status);

                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync()
        {
            using (var conn = await Connection.GetConnectionAsync())
            {
                if (conn != null)
                {
                    string query = "DELETE FROM users WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
            return false;
        }

        public static async Task<bool> LoginAsync(string username, string password)
        {
            using (var conn = await Connection.GetConnectionAsync())
            {
                if (conn != null)
                {
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password"; 
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); 

                    int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    return count > 0; // Returns true if user exists
                }
            }
            return false; 
        }
    }
}
