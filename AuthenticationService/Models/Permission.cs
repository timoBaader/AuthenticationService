namespace AuthenticationService.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public required string PermissionName { get; set; }
        public virtual ICollection<RolePermission>? RolePermissions { get; set; }
    }
}
