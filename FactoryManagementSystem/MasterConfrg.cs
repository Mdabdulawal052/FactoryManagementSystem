using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem
{
    public class MasterConfrg
    {
        public static string SuperAdmin = "MdIAdmin";
        public static string Admin = "Foysal"; // { get; set; }

        //Send Mail For Forgot Password
        public static string FromMail = "md.abdul.awal96816@gmail.com";  //{ get; set; }
        public static string MailPassword = "foysal123"; // { get; set; }
        public static int EmpIdForUser = 1; // { get; set; }
        public static DateTime EmpDOB = Convert.ToDateTime("1995-01-01"); // { get; set; }



    }
}
