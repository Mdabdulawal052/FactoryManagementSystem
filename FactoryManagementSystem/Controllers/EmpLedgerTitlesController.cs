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
    public class EmpLedgerTitlesController : Controller
    {
        public IEmployeeMainRepo MainEmpRepo { get; }

        //private readonly ApplicationDbContext _context;

        public EmpLedgerTitlesController(IEmployeeMainRepo MainEmpRepo)
        {
            //_context = context;
            this.MainEmpRepo = MainEmpRepo;
        }

        // GET: EmpLedgerTitles
        public async Task<IActionResult> Index()
        {
            IEnumerable<EmpLedgerTitle> empLedgerTitles = await MainEmpRepo.GetEmpLedgerTitles();
            return View(empLedgerTitles);
        }

        // GET: EmpLedgerTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empLedgerTitle = await MainEmpRepo.GetEmpLedgerTitleById(id);
            if (empLedgerTitle == null)
            {
                return NotFound();
            }

            return View(empLedgerTitle);
        }

        // GET: EmpLedgerTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpLedgerTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LedgerTitleID,LedgerTitle,CreatedDate")] EmpLedgerTitle empLedgerTitle)
        {
            if (ModelState.IsValid)
            {
                var isAdd = MainEmpRepo.AddEmpLedgerTitle(empLedgerTitle);
                if (await isAdd)
                    ViewBag.Msg = "Employee Ledger Title Added Successfully";
                return RedirectToAction(nameof(Index));

                //_context.Add(empLedgerTitle);
                //await _context.SaveChangesAsync();
            }
            return View(empLedgerTitle);
        }

        // GET: EmpLedgerTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empLedgerTitle = await MainEmpRepo.GetEmpLedgerTitleById(id);
            if (empLedgerTitle == null)
            {
                return NotFound();
            }
            return View(empLedgerTitle);
        }

        // POST: EmpLedgerTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LedgerTitleID,LedgerTitle,CreatedDate")] EmpLedgerTitle empLedgerTitle)
        {
            if (id != empLedgerTitle.LedgerTitleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await MainEmpRepo.UpdateEmpLedgerTitle(empLedgerTitle);
                    ViewBag.Msg = "Employee Ledger Title Updated Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEmpRepo.EmpLedgerTitleExists(empLedgerTitle.LedgerTitleID))
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
            return View(empLedgerTitle);
        }

        // GET: EmpLedgerTitles/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var empLedgerTitle = await _context.EmpLedgerTitles
        //        .FirstOrDefaultAsync(m => m.LedgerTitleID == id);
        //    if (empLedgerTitle == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(empLedgerTitle);
        //}

        //// POST: EmpLedgerTitles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var empLedgerTitle = await _context.EmpLedgerTitles.FindAsync(id);
        //    _context.EmpLedgerTitles.Remove(empLedgerTitle);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmpLedgerTitleExists(int id)
        //{
        //    return _context.EmpLedgerTitles.Any(e => e.LedgerTitleID == id);
        //}
    }
}
