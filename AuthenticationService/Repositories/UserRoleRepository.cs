using AuthenticationService.Data;
using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;
using AuthenticationService.Repositories.Interfaces;

namespace AuthenticationService.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserRole?> GetUserRole(int userId, int roleId)
        {
            return await _context.UserRoles.FindAsync(userId, roleId);
        }

        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            var result = await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserRole> UpdateUserRole(UserRole userRole)
        {
            _context.Entry(userRole).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userRole;
        }

        public async Task DeleteUserRole(int userId, int roleId)
        {
            var userRole = await _context.UserRoles.FindAsync(userId, roleId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
        }
    }
}
