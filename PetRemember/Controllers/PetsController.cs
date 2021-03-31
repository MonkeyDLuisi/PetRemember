using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetRemember.Application;
using PetRemember.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRemember.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        public IActionResult Register()
        {
            Guid id;
            if (Guid.TryParse(HttpContext.Session.GetString("userId"), out id))
            {
                return View();
            }
            else
            {
                return GoHome();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Pet pet)
        {
            if (ModelState.IsValid)
            {
                pet.UserId = Guid.Parse(HttpContext.Session.GetString("userId"));
                _petService.Add(pet);
                return RedirectToAction(nameof(UsersController.Details), "Users", new { Id = pet.UserId });
            }
            return GoHome();
        }
        private IActionResult GoHome()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
