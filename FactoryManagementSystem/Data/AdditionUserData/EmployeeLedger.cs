using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class EmployeeLedger
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int LedgerTitleID { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Remarks { get; set; }
        public virtual EmpLedgerTitle EmpLedgerTitle { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
