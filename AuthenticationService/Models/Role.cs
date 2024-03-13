namespace AuthenticationService.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<RolePermission>? RolePermissions { get; set; }
    }
}
