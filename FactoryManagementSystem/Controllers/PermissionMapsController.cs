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
    public class PermissionMapsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PermissionMapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PermissionMaps
        public async Task<IActionResult> Index()
        {
            var data =_context.Users.Where(x => x.Id == "c912ce10-a3bd-41be-84e1-fcc2e01c97d6");
            var applicationDbContext = _context.PermissionMaps.Include(p => p.User).Include(p => p.UserRole);
            return View(await applicationDbContext.ToListAsync());
        }
        [HttpGet]
        public async Task<ActionResult> AccessFor(string UserId,string Id)
        {
            ModelState.Clear();
            UserId = Id;
            var userList = _context.Users;
            if (UserId == null)
            {
                ViewBag.IsNullUserId = UserId;
                ViewBag.UserList = new SelectList(userList, "Id", "UserName");
                UserId = userList.FirstOrDefault().Id;
              
                //return BadRequest();
            }
            else
            {
                ViewBag.UserList = new SelectList(userList, "Id", "UserName",UserId);
                // var roleNames = _context.UserRoles.ToListAsync();
               
            }
            var user_access_permission = _context.PermissionMaps.Where(u => u.ApplicationUserId == UserId).Include(u => u.UserRole).Include(u => u.User);
            return View(await user_access_permission.ToListAsync());


        }
        // POST: user_access_permission/AccessFor/5  .Include(u => u.RoleId).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccessFor(string uap)
        {
            var Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PermissionMap>>(uap);

            foreach (var data in Data)
            {
                PermissionMap current_uap = _context.PermissionMaps.Find(data.PermissionId);
                current_uap.IsPermitted = bool.Parse(data.IsPermitted.ToString());
            }

            _context.SaveChanges();

            //return Json(a);
            return RedirectToAction("Index");
        }


        // GET: PermissionMaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionMap = await _context.PermissionMaps
                .Include(p => p.UserRole)
                .FirstOrDefaultAsync(m => m.PermissionId == id);
            if (permissionMap == null)
            {
                return NotFound();
            }

            return View(permissionMap);
        }

        // GET: PermissionMaps/Create
        //public IActionResult Create()
        //{
        //    ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId");
        //    return View();
        //}

        //// POST: PermissionMaps/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PermissionId,UserId,RoleId,IsPermitted")] PermissionMap permissionMap)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(permissionMap);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", permissionMap.RoleId);
        //    return View(permissionMap);
        //}

        // GET: PermissionMaps/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var permissionMap = await _context.PermissionMaps.FindAsync(id);
        //    if (permissionMap == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", permissionMap.RoleId);
        //    return View(permissionMap);
        //}

        // POST: PermissionMaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PermissionId,UserId,RoleId,IsPermitted")] PermissionMap permissionMap)
        //{
        //    if (id != permissionMap.PermissionId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(permissionMap);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PermissionMapExists(permissionMap.PermissionId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", permissionMap.RoleId);
        //    return View(permissionMap);
        //}

        //// GET: PermissionMaps/Delete/5
        //public async Task<IActionResult> Delete(int? id)
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

        //// POST: PermissionMaps/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var permissionMap = await _context.PermissionMaps.FindAsync(id);
        //    _context.PermissionMaps.Remove(permissionMap);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PermissionMapExists(int id)
        {
            return _context.PermissionMaps.Any(e => e.PermissionId == id);
        }
    }
}
