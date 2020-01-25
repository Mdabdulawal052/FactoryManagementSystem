using FactoryManagementSystem.Data;
using FactoryManagementSystem.Data.AdditionUserData;
using FactoryManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Repository
{

    //This EmployeeMainRepo is descrive EmpDepartment, EmpDesignation, EmpLedgerTitle
    public class EmployeeMainRepo : IEmployeeMainRepo
    {
        public ApplicationDbContext _context { get; }
        public EmployeeMainRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddDepartment(Department department)
        {
            _context.Add(department);

            var IsSave = SaveChanges();
            return IsSave;

        }

        public async Task<Department> GetDepartmentById(int? id)
        {
            return await _context.Departments
                 .FirstOrDefaultAsync(m => m.DepartmentID == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public Task<bool> UpdateDepartment(Department department)
        {
            _context.Update(department);
            var IsUpdate =SaveChanges();
            return IsUpdate;
        }

        public async Task<bool> SaveChanges()
        {
            var data =  await _context.SaveChangesAsync();
            if (data > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }

        public async Task<IEnumerable<Designation>> GetDesignations()
        {
            return await _context.Designations.ToListAsync();
        }

        public async Task<Designation> GetDesignationById(int? id)
        {
            return await _context.Designations
                .FirstOrDefaultAsync(m => m.DesignationID == id);
        }

        public Task<bool> AddDesignation(Designation designation)
        {
            _context.Add(designation);
            var IsSave = SaveChanges();
            return IsSave;

        }

        public Task<bool> UpdateDesignation(Designation designation)
        {
            _context.Update(designation);
            var IsUpdate = SaveChanges();
            return IsUpdate;
        }

        public bool DesignationExists(int id)
        {
            return  _context.Designations.Any(e => e.DesignationID == id);
        }

        public async Task<IEnumerable<EmpLedgerTitle>> GetEmpLedgerTitles()
        {
            return await _context.EmpLedgerTitles.ToListAsync();
        }

        public async Task<EmpLedgerTitle> GetEmpLedgerTitleById(int? id)
        {
            return await _context.EmpLedgerTitles
                 .FirstOrDefaultAsync(m => m.LedgerTitleID == id);
        }

        public Task<bool> AddEmpLedgerTitle(EmpLedgerTitle empLedgerTitle)
        {
            _context.Add(empLedgerTitle);
            var IsSave = SaveChanges();
            return IsSave;
        }

        public Task<bool> UpdateEmpLedgerTitle(EmpLedgerTitle empLedgerTitle)
        {
            _context.Update(empLedgerTitle);
            var IsUpdate = SaveChanges();
            return IsUpdate;
        }

        public bool EmpLedgerTitleExists(int id)
        {
            return _context.EmpLedgerTitles.Any(e => e.LedgerTitleID == id);
        }
    }
}
