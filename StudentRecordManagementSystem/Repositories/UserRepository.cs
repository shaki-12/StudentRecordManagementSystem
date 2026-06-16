using Microsoft.Data.SqlClient;
using StudentRecordManagementSystem.Models;
using System.Data;

namespace StudentRecordManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public User? Login(string username, string password)
        {
            User? user = null;

            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("sp_LoginUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Username = Convert.ToString(reader["Username"]),
                    Password = Convert.ToString(reader["Password"]),
                    Role = Convert.ToString(reader["Role"]),
                    RollNumber = reader["RollNumber"] == DBNull.Value
                        ? null
                        : Convert.ToInt32(reader["RollNumber"])
                };
            }

            return user;
        }
    }
}