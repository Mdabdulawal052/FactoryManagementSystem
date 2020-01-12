using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Quentity { get; set; }

        public int CategoryID { get; set; }
        public bool  Discontinue { get; set; }

        public Category Category { get; set; }
    }
}
