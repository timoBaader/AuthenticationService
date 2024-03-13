using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
