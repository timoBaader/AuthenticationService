using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole?> GetUserRole(int userId, int roleId);
        Task<IEnumerable<UserRole>> GetUserRoles();
        Task<UserRole> AddUserRole(UserRole userRole);
        Task<UserRole> UpdateUserRole(UserRole userRole);
        Task DeleteUserRole(int userId, int roleId);
    }
}
