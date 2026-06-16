using StudentRecordManagementSystem.Models;

namespace StudentRecordManagementSystem.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);

        Student? GetStudentByRollNo(int rollNo);

        List<Student> GetAllStudents();

        void UpdateMarks(Student student);

        void DeleteStudent(int rollNo);
    }
}
