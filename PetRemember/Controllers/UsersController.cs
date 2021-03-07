using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetRemember.Data;
using PetRemember.Models;
using Microsoft.AspNetCore.Http;

namespace PetRemember.Controllers
{
    public class UsersController : Controller
    {
        private readonly PetRememberContext _context;

        public UsersController(PetRememberContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id = null)
        {
            if (id == null)
            {
                id = HttpContext.Session.GetInt32("userId");
                if (id == null)
                {
                    return NotFound();
                }
            }

            var user = await _context.User
            .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var pets = await _context.Pet
                .Where(p => p.UserId == id).ToListAsync();

            return View(new UserWithPetsViewModel { User = user, Pets = pets });
        }

        // GET: Users/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Name,Surname,Mail,Salt,TextPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Salt = Hmac.GenerateSalt();
                user.Password = Hmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(user.TextPassword), user.Salt);
                _context.Add(user);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("userId", user.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            
                var dbuser = await _context.User
                .FirstOrDefaultAsync(u => u.Mail.Equals(user.Mail));
                var hash = Hmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(user.TextPassword), dbuser.Salt);
                if (dbuser != null && dbuser.Password.SequenceEqual(Hmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(user.TextPassword), dbuser.Salt)))
                {

                HttpContext.Session.SetInt32("userId", user.Id);
                return RedirectToAction(nameof(Details), new { id = dbuser.Id });
                }                
            
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Mail,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
