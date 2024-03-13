using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role?> GetRole(int id);
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> AddRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task DeleteRole(int id);
    }
}
