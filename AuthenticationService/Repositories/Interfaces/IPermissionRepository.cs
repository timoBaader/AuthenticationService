using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetPermission(int id);
        Task<IEnumerable<Permission>> GetPermissions();
        Task<Permission> AddPermission(Permission permission);
        Task<Permission> UpdatePermission(Permission permission);
        Task DeletePermission(int id);
    }
}
