using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
