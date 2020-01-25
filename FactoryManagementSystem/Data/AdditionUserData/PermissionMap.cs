using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class PermissionMap
    {
        [Key]
        public int PermissionId { get; set; }
        public string ApplicationUserId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public bool IsPermitted { get; set; }
        public int BranchId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual UserRole UserRole { get; set; }

    }
}
