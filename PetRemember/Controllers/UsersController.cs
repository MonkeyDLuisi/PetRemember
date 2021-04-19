using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetRemember.Application;
using PetRemember.Application.Products;
using PetRemember.Domain.Pets;
using PetRemember.Domain.Products;
using PetRemember.Domain.Users;
using PetRemember.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetRemember.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPetService _petService;
        private readonly IProductService _productService;
        public UsersController(IUserService userService, IPetService petService, IProductService productService)
        {
            _userService = userService;
            _petService = petService;
            _productService = productService;
        }
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                Guid auxId;
                if (Guid.TryParse(HttpContext.Session.GetString("userId"), out auxId))
                {
                    id = auxId;
                }
                else
                {
                    return GoHome();
                }
            }

            var user = _userService.Get((Guid)id);
            if (user == null)
            {
                return GoHome();
            }

            var pets = _petService.GetByUser((Guid)id);
            var products = new List<Product>();
            var allProducts = _productService.GetAll();

            foreach (Pet pet in pets)
            {
                products.AddRange(allProducts.Where(p => (p.MaxWeight == 0 || p.MaxWeight > pet.Weight) && (p.MinWeight == 0 || p.MinWeight <= pet.Weight)));
            }

            return View(new UserViewModel() { User = user, Pets = pets, Products = products });
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.Register(userViewModel.User, userViewModel.Password);
                if (userId != null)
                {
                    HttpContext.Session.SetString("userId", userId.ToString());
                    return RedirectToAction(nameof(Details), new { id = userId });
                }
                else
                {
                    return View(userViewModel);
                }
            }
            return View(userViewModel);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel userViewModel)
        {
            var userId = _userService.Login(userViewModel.User.Mail, userViewModel.Password);
            if (userId != null)
            {
                HttpContext.Session.SetString("userId", userId.ToString());
                return RedirectToAction(nameof(Details), new { id = userId });
            }
            else
            {
                return View(userViewModel);
            }
        }
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                Guid auxId;
                if (Guid.TryParse(HttpContext.Session.GetString("userId"), out auxId))
                {
                    id = auxId;
                }
                else
                {
                    return GoHome();
                }
            }

            var user = _userService.Get((Guid)id);
            if (user == null)
            {
                return GoHome();
            }
            return View(new UserViewModel() { User = user });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, UserViewModel userViewModel)
        {
            if (id != userViewModel.User.Id)
            {
                return GoHome();
            }

            if (ModelState.IsValid)
            {
                _userService.Update(userViewModel.User);
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel.User);
        }
        private IActionResult GoHome()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
