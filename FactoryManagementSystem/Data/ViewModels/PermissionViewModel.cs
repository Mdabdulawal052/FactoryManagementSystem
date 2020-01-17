using FactoryManagementSystem.Data.AdditionUserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.ViewModels
{
    public class PermissionViewModel
    {
        public int PermissionId { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool IsPermitted { get; set; }
        
    }
}
