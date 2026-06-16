using StudentRecordManagementSystem.Models;
using StudentRecordManagementSystem.Repositories;

namespace StudentRecordManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User? Login(string username, string password)
        {
            return _repository.Login(username, password);
        }
    }
}