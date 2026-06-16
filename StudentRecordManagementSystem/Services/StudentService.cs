using StudentRecordManagementSystem.Models;
using StudentRecordManagementSystem.Repositories;

namespace StudentRecordManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }

        public Student? GetStudentByRollNo(int rollNo)
        {
            return _repository.GetStudentByRollNo(rollNo);
        }

        public void UpdateMarks(Student student)
        {
            _repository.UpdateMarks(student);
        }

        public void DeleteStudent(int rollNo)
        {
            _repository.DeleteStudent(rollNo);
        }
    }
}