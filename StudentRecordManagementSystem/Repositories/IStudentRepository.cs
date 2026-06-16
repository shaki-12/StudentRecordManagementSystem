using StudentRecordManagementSystem.Models;

namespace StudentRecordManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);

        Student? GetStudentByRollNo(int rollNo);

        List<Student> GetAllStudents();

        void UpdateMarks(Student student);

        void DeleteStudent(int rollNo);
    }
}
