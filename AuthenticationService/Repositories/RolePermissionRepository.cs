using AuthenticationService.Data;
using AuthenticationService.Models;
using AuthenticationService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Repositories
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public RolePermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RolePermission?> GetRolePermission(int roleId, int permissionId)
        {
            return await _context.RolePermissions.FindAsync(roleId, permissionId);
        }

        public async Task<IEnumerable<RolePermission>> GetRolePermissions()
        {
            return await _context.RolePermissions.ToListAsync();
        }

        public async Task<RolePermission> AddRolePermission(RolePermission rolePermission)
        {
            var result = await _context.RolePermissions.AddAsync(rolePermission);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RolePermission> UpdateRolePermission(RolePermission rolePermission)
        {
            _context.Entry(rolePermission).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return rolePermission;
        }

        public async Task DeleteRolePermission(int roleId, int permissionId)
        {
            var rolePermission = await _context.RolePermissions.FindAsync(roleId, permissionId);
            if (rolePermission != null)
            {
                _context.RolePermissions.Remove(rolePermission);
                await _context.SaveChangesAsync();
            }
        }
    }
}
