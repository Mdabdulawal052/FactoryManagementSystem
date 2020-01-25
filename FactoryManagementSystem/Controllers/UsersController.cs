using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryManagementSystem.Data;
using FactoryManagementSystem.Data.ViewModels;
using FactoryManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public string SuperAdmin = MasterConfrg.SuperAdmin;
        public string Admin = MasterConfrg.Admin;

        public IUserPermissionRepo Repo { get; }

        public UsersController(ApplicationDbContext context, IUserPermissionRepo repo)
        {
            _context = context;
            Repo = repo;
        }
        public IActionResult Index(string id)
        {
            if(User.Identity.Name != Admin)
            {
                return RedirectToAction("ErrorModel", "Home");
            }
             ViewBag.data = id;
            var users = _context.Users.ToList();
            return View(users);
        }
        
        public IActionResult UpdateUserPass(string id)
        {
            var data = false;
            if (!String.IsNullOrEmpty(id))
            {
                data = Repo.UpdatePassword(id);
                
            }
            //var user = _context.Users.Find(name);
            return (RedirectToAction("Index", new { id = id }));
        }
        public IActionResult Update()
        {
            return View();
        }
        //public async Task<IActionResult> Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var permissionMap = await _context.PermissionMaps
        //        .Include(p => p.UserRole)
        //        .FirstOrDefaultAsync(m => m.PermissionId == id);
        //    if (permissionMap == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(permissionMap);
        //}
    }
}