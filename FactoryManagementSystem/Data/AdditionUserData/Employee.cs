using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string MaritalStatus { get; set; }
        public string Mobile { get; set; }
        public int BranchID { get; set; }
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public DateTime JoiningDate { get; set; }
        public string NID { get; set; }
        public decimal Salary { get; set; }
        public byte[] Photo { get; set; }
        public bool Status { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
