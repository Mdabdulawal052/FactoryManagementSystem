using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryManagementSystem.Data;
using FactoryManagementSystem.Models;
using FactoryManagementSystem.Repository;
using FactoryManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace FactoryManagementSystem.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IUserPermissionRepo PermissionRepo;

        public ProductsController(ApplicationDbContext context, IUserPermissionRepo permissionRepo)
        {
            _context = context;
            PermissionRepo = permissionRepo;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            string RoleName = "ProductIndex";
            string name = User.Identity.Name;
            if (name !=MasterConfrg.SuperAdmin)
            {
                if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
                {
                    return RedirectToAction("ErrorModel", "Home");
                }
            }
           
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
                
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            string RoleName = "ProductCreate";
            string name = User.Identity.Name;
            if (name != MasterConfrg.SuperAdmin)
            {
                if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
                {
                    return RedirectToAction("ErrorModel", "Home");
                }
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,Description,PurchasePrice,SellPrice,Quentity,CategoryID,Discontinue")] Product product)
        {
            string RoleName = "ProductCreate";
            string name = User.Identity.Name;
            if (name != MasterConfrg.SuperAdmin)
            {
                if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
                {
                    return RedirectToAction("ErrorModel", "Home");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string RoleName = "ProductEdit";
            string name = User.Identity.Name;
            if (name != MasterConfrg.SuperAdmin)
            {
                if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
                {
                    return RedirectToAction("ErrorModel", "Home");
                }
            }
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Description,PurchasePrice,SellPrice,Quentity,CategoryID,Discontinue")] Product product)
        {
            string RoleName = "ProductEdit";
            string name = User.Identity.Name;
            if (name != MasterConfrg.SuperAdmin)
            {
                if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
                {
                    return RedirectToAction("ErrorModel", "Home");
                }
            }
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string RoleName = "ProductDelete";
            string name = User.Identity.Name;
            if (name != MasterConfrg.SuperAdmin)
            {
                if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
                {
                    return RedirectToAction("ErrorModel", "Home");
                }
            }
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string RoleName = "ProductDelete";
            string name = User.Identity.Name;
            if (PermissionRepo.GetPermission(RoleName, String.IsNullOrEmpty(name) ? "" : name) == false)
            {
                return RedirectToAction("ErrorModel", "Home");
            }
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
