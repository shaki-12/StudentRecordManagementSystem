using StudentRecordManagementSystem.Models;

namespace StudentRecordManagementSystem.Repositories
{
    public interface IUserRepository
    {
        User? Login(string username, string password);
    }
}
