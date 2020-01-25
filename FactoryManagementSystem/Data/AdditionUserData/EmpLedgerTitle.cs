using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Data.AdditionUserData
{
    public class EmpLedgerTitle
    {
        [Key]
        public int LedgerTitleID { get; set; }
        public string LedgerTitle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
