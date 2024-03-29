﻿namespace AuthenticationService.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public required Role Role { get; set; }
        public int PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }
}
