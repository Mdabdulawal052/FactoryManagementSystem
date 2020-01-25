using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryManagementSystem.Data;
using FactoryManagementSystem.Data.AdditionUserData;

namespace FactoryManagementSystem.Controllers
{
    public class EmployeeLedgersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeLedgersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeLedgers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeLedgers.Include(e => e.EmpLedgerTitle).Include(e => e.Employee).Where(e=>e.Employee.Status == true);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeLedgers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLedger = await _context.EmployeeLedgers
                .Include(e => e.EmpLedgerTitle)
                .Include(e => e.Employee)
                .Where(e => e.Employee.Status == true)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeLedger == null)
            {
                return NotFound();
            }

            return View(employeeLedger);
        }

        // GET: EmployeeLedgers/Create
        public IActionResult Create()
        {
            ViewData["LedgerTitleID"] = new SelectList(_context.EmpLedgerTitles, "LedgerTitleID", "LedgerTitle");
            ViewData["EmployeeID"] = new SelectList(_context.Employees.Where(e => e.Status == true), "Id", "EmployeeName");
            return View();
        }

        // POST: EmployeeLedgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EmployeeID,LedgerTitleID,Date,Debit,Credit,Remarks")] EmployeeLedger employeeLedger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeLedger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LedgerTitleID"] = new SelectList(_context.EmpLedgerTitles, "LedgerTitleID", "LedgerTitle", employeeLedger.LedgerTitleID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees.Where(e => e.Status == true), "Id", "EmployeeName", employeeLedger.EmployeeID);
            return View(employeeLedger);
        }

        // GET: EmployeeLedgers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLedger = await _context.EmployeeLedgers.FindAsync(id);
            if (employeeLedger == null)
            {
                return NotFound();
            }
            ViewData["LedgerTitleID"] = new SelectList(_context.EmpLedgerTitles, "LedgerTitleID", "LedgerTitle", employeeLedger.LedgerTitleID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees.Where(e => e.Status == true), "Id", "EmployeeName", employeeLedger.EmployeeID);
            return View(employeeLedger);
        }

        // POST: EmployeeLedgers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmployeeID,LedgerTitleID,Date,Debit,Credit,Remarks")] EmployeeLedger employeeLedger)
        {
            if (id != employeeLedger.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeLedger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLedgerExists(employeeLedger.ID))
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
            ViewData["LedgerTitleID"] = new SelectList(_context.EmpLedgerTitles, "LedgerTitleID", "LedgerTitle", employeeLedger.LedgerTitleID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees.Where(e => e.Status == true), "Id", "EmployeeName", employeeLedger.EmployeeID);
            return View(employeeLedger);
        }

        // GET: EmployeeLedgers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employeeLedger = await _context.EmployeeLedgers
        //        .Include(e => e.EmpLedgerTitle)
        //        .Include(e => e.Employee)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (employeeLedger == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employeeLedger);
        //}

        //// POST: EmployeeLedgers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employeeLedger = await _context.EmployeeLedgers.FindAsync(id);
        //    _context.EmployeeLedgers.Remove(employeeLedger);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool EmployeeLedgerExists(int id)
        {
            return _context.EmployeeLedgers.Any(e => e.ID == id);
        }
    }
}
