using System;
using System.Collections.Generic;
using System.Text;

using FactoryManagementSystem.Data.AdditionUserData;
using FactoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FactoryManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PermissionMap> PermissionMaps { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmpLedgerTitle> EmpLedgerTitles { get; set; }
        public DbSet<EmployeeLedger> EmployeeLedgers { get; set; }
    }
}
