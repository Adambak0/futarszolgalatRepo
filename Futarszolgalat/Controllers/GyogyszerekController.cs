#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Futarszolgalat.Data;
using Futarszolgalat.Models;

namespace Futarszolgalat.Controllers
{
    public class GyogyszerekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GyogyszerekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gyogyszerek
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gyogyszer.ToListAsync());
        }

        // GET: Gyogyszerek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gyogyszer = await _context.Gyogyszer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gyogyszer == null)
            {
                return NotFound();
            }

            return View(gyogyszer);
        }

        // GET: Gyogyszerek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gyogyszerek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nev,Tipus,Hatoanyag,Venykoteles,Raktaron,Gyarto")] Gyogyszer gyogyszer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gyogyszer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gyogyszer);
        }

        // GET: Gyogyszerek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gyogyszer = await _context.Gyogyszer.FindAsync(id);
            if (gyogyszer == null)
            {
                return NotFound();
            }
            return View(gyogyszer);
        }

        // POST: Gyogyszerek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nev,Tipus,Hatoanyag,Venykoteles,Raktaron,Gyarto")] Gyogyszer gyogyszer)
        {
            if (id != gyogyszer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gyogyszer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GyogyszerExists(gyogyszer.Id))
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
            return View(gyogyszer);
        }

        // GET: Gyogyszerek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gyogyszer = await _context.Gyogyszer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gyogyszer == null)
            {
                return NotFound();
            }

            return View(gyogyszer);
        }

        // POST: Gyogyszerek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gyogyszer = await _context.Gyogyszer.FindAsync(id);
            _context.Gyogyszer.Remove(gyogyszer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GyogyszerExists(int id)
        {
            return _context.Gyogyszer.Any(e => e.Id == id);
        }
    }
}
