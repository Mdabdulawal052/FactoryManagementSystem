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
    public class DesignationsController : Controller
    {
        //private readonly ApplicationDbContext _context;

        public IEmployeeMainRepo MainEmpRepo { get; }

        public DesignationsController(IEmployeeMainRepo mainEmpRepo)
        {
            //_context = context;
            MainEmpRepo = mainEmpRepo;
        }

        // GET: Designations
        public async Task<IActionResult> Index()
        {
            IEnumerable<Designation> designations = await MainEmpRepo.GetDesignations();
            return View(designations);
          
        }

        // GET: Designations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await MainEmpRepo.GetDesignationById(id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // GET: Designations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignationID,DesignationName,DesignationStatus")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                var isAdd = MainEmpRepo.AddDesignation(designation);
                if (await isAdd)
                    ViewBag.Msg = "Designation Added Successfully";
                return RedirectToAction(nameof(Index));
                //_context.Add(designation);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await MainEmpRepo.GetDesignationById(id);
            if (designation == null)
            {
                return NotFound();
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesignationID,DesignationName,DesignationStatus")] Designation designation)
        {
            if (id != designation.DesignationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await MainEmpRepo.UpdateDesignation(designation);
                    ViewBag.Msg = "Designation Updated Successfully";
                    //_context.Update(designation);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEmpRepo.DesignationExists(designation.DesignationID))
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
            return View(designation);
        }

        // GET: Designations/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var designation = await _context.Designations
        //        .FirstOrDefaultAsync(m => m.DesignationID == id);
        //    if (designation == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(designation);
        //}

        //// POST: Designations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var designation = await _context.Designations.FindAsync(id);
        //    _context.Designations.Remove(designation);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DesignationExists(int id)
        //{
        //    return _context.Designations.Any(e => e.DesignationID == id);
        //}
    }
}
