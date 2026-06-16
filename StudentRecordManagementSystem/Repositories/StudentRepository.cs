using Microsoft.Data.SqlClient;
using StudentRecordManagementSystem.Models;
using System.Data;

namespace StudentRecordManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void AddStudent(Student student)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("sp_AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Maths", student.Maths);
            cmd.Parameters.AddWithValue("@Physics", student.Physics);
            cmd.Parameters.AddWithValue("@Chemistry", student.Chemistry);
            cmd.Parameters.AddWithValue("@English", student.English);
            cmd.Parameters.AddWithValue("@Programming", student.Programming);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("sp_GetAllStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    RollNumber = Convert.ToInt32(reader["RollNumber"]),
                    Name = Convert.ToString(reader["Name"]),
                    Maths = Convert.ToInt32(reader["Maths"]),
                    Physics = Convert.ToInt32(reader["Physics"]),
                    Chemistry = Convert.ToInt32(reader["Chemistry"]),
                    English = Convert.ToInt32(reader["English"]),
                    Programming = Convert.ToInt32(reader["Programming"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }

            return students;
        }

        public Student? GetStudentByRollNo(int rollNo)
        {
            Student? student = null;

            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("sp_GetStudentByRollNo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RollNumber", rollNo);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                student = new Student
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    RollNumber = Convert.ToInt32(reader["RollNumber"]),
                    Name = Convert.ToString(reader["Name"]),
                    Maths = Convert.ToInt32(reader["Maths"]),
                    Physics = Convert.ToInt32(reader["Physics"]),
                    Chemistry = Convert.ToInt32(reader["Chemistry"]),
                    English = Convert.ToInt32(reader["English"]),
                    Programming = Convert.ToInt32(reader["Programming"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                };
            }

            return student;
        }

        public void UpdateMarks(Student student)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("sp_UpdateStudentMarks", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Maths", student.Maths);
            cmd.Parameters.AddWithValue("@Physics", student.Physics);
            cmd.Parameters.AddWithValue("@Chemistry", student.Chemistry);
            cmd.Parameters.AddWithValue("@English", student.English);
            cmd.Parameters.AddWithValue("@Programming", student.Programming);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteStudent(int rollNo)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("sp_DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RollNumber", rollNo);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}