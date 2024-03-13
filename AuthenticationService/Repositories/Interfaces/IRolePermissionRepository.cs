using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IRolePermissionRepository
    {
        Task<RolePermission?> GetRolePermission(int roleId, int permissionId);
        Task<IEnumerable<RolePermission>> GetRolePermissions();
        Task<RolePermission> AddRolePermission(RolePermission rolePermission);
        Task<RolePermission> UpdateRolePermission(RolePermission rolePermission);
        Task DeleteRolePermission(int roleId, int permissionId);
    }
}
