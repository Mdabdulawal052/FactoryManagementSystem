using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryManagementSystem.Data;
using FactoryManagementSystem.Data.AdditionUserData;
using FactoryManagementSystem.Repository.IRepository;

namespace FactoryManagementSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly ApplicationDbContext _context;

        public IEmployeeMainRepo MainEmpRepo { get; }

        public DepartmentsController(IEmployeeMainRepo mainEmpRepo)
        {
            //_context = context;
            MainEmpRepo = mainEmpRepo;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            IEnumerable<Department> departments =await MainEmpRepo.GetDepartments();
            return View(departments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =await MainEmpRepo.GetDepartmentById(id);
                //await _context.Departments
                //.FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,DepartmentName,DepartmentStatus")] Department department)
        {
            if (ModelState.IsValid)
            {
                var isAdd =  MainEmpRepo.AddDepartment(department);
                if (await isAdd)
                    ViewBag.Msg = "Department Added Successfully";
                //_context.Add(department);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            /////////////////
            var department = await MainEmpRepo.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,DepartmentName,DepartmentStatus")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   var data = await MainEmpRepo.UpdateDepartment(department);
                    ViewBag.Msg = "Department Updated Successfully";
                    //_context.Update(department);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEmpRepo.DepartmentExists(department.DepartmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var department = await _context.Departments
        //        .FirstOrDefaultAsync(m => m.DepartmentID == id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(department);
        //}

        //// POST: Departments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var department = await _context.Departments.FindAsync(id);
        //    _context.Departments.Remove(department);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DepartmentExists(int id)
        //{
        //    return _context.Departments.Any(e => e.DepartmentID == id);
        //}
    }
}
