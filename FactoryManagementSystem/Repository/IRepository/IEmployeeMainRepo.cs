using FactoryManagementSystem.Data.AdditionUserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Repository.IRepository
{
    public interface IEmployeeMainRepo
    {
        //Department
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int? id);
        Task<bool> AddDepartment(Department department);
        Task<bool> UpdateDepartment(Department department);
        Task<bool> SaveChanges();
        bool DepartmentExists(int id);

        // Designation 
        Task<IEnumerable<Designation>> GetDesignations();
        Task<Designation> GetDesignationById(int? id);
        Task<bool> AddDesignation(Designation designation);
        Task<bool> UpdateDesignation(Designation designation);
        bool DesignationExists(int id);

        // Employee Ledger Title 
        Task<IEnumerable<EmpLedgerTitle>> GetEmpLedgerTitles();
        Task<EmpLedgerTitle> GetEmpLedgerTitleById(int? id);
        Task<bool> AddEmpLedgerTitle(EmpLedgerTitle empLedgerTitle);
        Task<bool> UpdateEmpLedgerTitle(EmpLedgerTitle empLedgerTitle);
        bool EmpLedgerTitleExists(int id);

    }
}
