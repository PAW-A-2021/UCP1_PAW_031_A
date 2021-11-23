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
    public class TransactionsController : Controller
    {
        private readonly TraveloviaContext _context;

        public TransactionsController(TraveloviaContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var traveloviaContext = _context.Transactions.Include(t => t.Beach).Include(t => t.User).Include(t => t.Driver);
            return View(await traveloviaContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Beach)
                .Include(t => t.User)
                .Include(t => t.Driver)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["BeachId"] = new SelectList(_context.BeachPlaces, "BeachId", "BeachName");
            ViewData["UserId"] = new SelectList(_context.UserAccesses, "UserId", "Name");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,UserId,BeachId,DriverId,TanggalTransaksi,Price,City,Province,PostalCode")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                TempData["message"] = $"Data berhasil ditambahkan";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeachId"] = new SelectList(_context.BeachPlaces, "BeachId", "BeachName", transaction.BeachId);
            ViewData["UserId"] = new SelectList(_context.UserAccesses, "UserId", "Name", transaction.UserId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverName", transaction.DriverId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["BeachId"] = new SelectList(_context.BeachPlaces, "BeachId", "BeachName", transaction.BeachId);
            ViewData["UserId"] = new SelectList(_context.UserAccesses, "UserId", "Name", transaction.UserId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverName", transaction.DriverId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,UserId,BeachId,DriverId,TanggalTransaksi,Price,City,Province,PostalCode")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["message"] = $"Data berhasil diedit";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeachId"] = new SelectList(_context.BeachPlaces, "BeachId", "BeachName", transaction.BeachId);
            ViewData["UserId"] = new SelectList(_context.UserAccesses, "UserId", "Name", transaction.UserId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverName", transaction.DriverId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Beach)
                .Include(t => t.User)
                .Include(t => t.Driver)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            TempData["message"] = $"Data berhasil dihapus";
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
