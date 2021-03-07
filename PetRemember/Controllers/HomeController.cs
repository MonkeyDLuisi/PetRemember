using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetRemember.Models;
using PetRemember.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PetRemember.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetRememberContext _context;

        public HomeController(PetRememberContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
                return RedirectToAction(nameof(UsersController.Details), "Users", new { Id = HttpContext.Session.GetInt32("userId") });
            else
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
    }
}
