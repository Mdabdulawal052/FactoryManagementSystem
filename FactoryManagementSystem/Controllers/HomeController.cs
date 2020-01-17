using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FactoryManagementSystem.Models;
using FactoryManagementSystem.Repository.IRepository;

namespace FactoryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IUserPermissionRepo UserPermRepo { get; }

        public HomeController(IUserPermissionRepo  userPermRepo)
        {
            UserPermRepo = userPermRepo;
        }
        public IActionResult Index()
        {
            // This is Use For when User are not Entry in ParmissionMap Table

            //var id = "427c1a83-de32-4196-8bde-cedb10604ca6";
            //UserPermRepo.CreateUserParmission(id);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult ErrorModel()
        {
            return View();
        }
    }
}
