using StudentRecordManagementSystem.Models;

namespace StudentRecordManagementSystem.Services
{
    public interface IUserService
    {
        User? Login(string username, string password);
    }
}
