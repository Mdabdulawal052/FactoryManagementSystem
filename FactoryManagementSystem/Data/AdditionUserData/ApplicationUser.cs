using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        
    }
}
