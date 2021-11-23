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
    public class BeachPlacesController : Controller
    {
        private readonly TraveloviaContext _context;

        public BeachPlacesController(TraveloviaContext context)
        {
            _context = context;
        }

        // GET: BeachPlaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeachPlaces.ToListAsync());
        }

        // GET: BeachPlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beachPlace = await _context.BeachPlaces
                .FirstOrDefaultAsync(m => m.BeachId == id);
            if (beachPlace == null)
            {
                return NotFound();
            }

            return View(beachPlace);
        }

        // GET: BeachPlaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeachPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeachId,BeachName,Description,Price,Location")] BeachPlace beachPlace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beachPlace);
                await _context.SaveChangesAsync();
                TempData["message"] = $"Data {beachPlace.BeachName} berhasil ditambahkan";
                return RedirectToAction(nameof(Index));
            }
            return View(beachPlace);
        }

        // GET: BeachPlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beachPlace = await _context.BeachPlaces.FindAsync(id);
            if (beachPlace == null)
            {
                return NotFound();
            }
            return View(beachPlace);
        }

        // POST: BeachPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeachId,BeachName,Description,Price,Location")] BeachPlace beachPlace)
        {
            if (id != beachPlace.BeachId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beachPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeachPlaceExists(beachPlace.BeachId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["message"] = $"Data {beachPlace.BeachName} berhasil diedit";
                return RedirectToAction(nameof(Index));
            }
            return View(beachPlace);
        }

        // GET: BeachPlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beachPlace = await _context.BeachPlaces
                .FirstOrDefaultAsync(m => m.BeachId == id);
            if (beachPlace == null)
            {
                return NotFound();
            }

            return View(beachPlace);
        }

        // POST: BeachPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beachPlace = await _context.BeachPlaces.FindAsync(id);
            _context.BeachPlaces.Remove(beachPlace);
            await _context.SaveChangesAsync();
            TempData["message"] = $"Data {beachPlace.BeachName} berhasil dihapus";
            return RedirectToAction(nameof(Index));
        }

        private bool BeachPlaceExists(int id)
        {
            return _context.BeachPlaces.Any(e => e.BeachId == id);
        }
    }
}
