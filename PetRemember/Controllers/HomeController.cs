using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetRemember.ViewModels;
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
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userId") != null)
                return RedirectToAction(nameof(UsersController.Details), "Users", new { Id = Guid.Parse(HttpContext.Session.GetString("userId")) });
            else
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}