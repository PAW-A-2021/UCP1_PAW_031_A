using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_031.Models;

namespace UCP1_PAW_031.Controllers
{
    public class UserAccessesController : Controller
    {
        private readonly TraveloviaContext _context;

        public UserAccessesController(TraveloviaContext context)
        {
            _context = context;
        }

        // GET: UserAccesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserAccesses.ToListAsync());
        }

        // GET: UserAccesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccess = await _context.UserAccesses
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userAccess == null)
            {
                return NotFound();
            }

            return View(userAccess);
        }

        // GET: UserAccesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAccesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,IdCard,Email,Phone,Address")] UserAccess userAccess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccess);
                await _context.SaveChangesAsync();
                TempData["message"] = $"Data {userAccess.Name} berhasil ditambahkan";
                return RedirectToAction(nameof(Index));
            }
            return View(userAccess);
        }

        // GET: UserAccesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccess = await _context.UserAccesses.FindAsync(id);
            if (userAccess == null)
            {
                return NotFound();
            }
            return View(userAccess);
        }

        // POST: UserAccesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,IdCard,Email,Phone,Address")] UserAccess userAccess)
        {
            if (id != userAccess.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccessExists(userAccess.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["message"] = $"Data {userAccess.Name} berhasil diedit";
                return RedirectToAction(nameof(Index));
            }
            return View(userAccess);
        }

        // GET: UserAccesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccess = await _context.UserAccesses
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userAccess == null)
            {
                return NotFound();
            }

            return View(userAccess);
        }

        // POST: UserAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccess = await _context.UserAccesses.FindAsync(id);
            _context.UserAccesses.Remove(userAccess);
            await _context.SaveChangesAsync();
            TempData["message"] = $"Data {userAccess.Name} berhasil dihapus";
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccessExists(int id)
        {
            return _context.UserAccesses.Any(e => e.UserId == id);
        }
    }
}
