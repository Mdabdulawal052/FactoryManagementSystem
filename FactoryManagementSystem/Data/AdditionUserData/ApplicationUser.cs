using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
        public string Gender { get; set; }

        public byte[] Image { get; set; }
        public bool Status { get; set; }
        public int EmployeeID { get; set; }
        //public int DID { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
