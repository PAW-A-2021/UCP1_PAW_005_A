using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_20190140005_A.Models;

namespace UCP1_PAW_20190140005_A.Controllers
{
    public class CasualsController : Controller
    {
        private readonly ShoeSixContext _context;

        public CasualsController(ShoeSixContext context)
        {
            _context = context;
        }

        // GET: Casuals
        public async Task<IActionResult> Index()
        {
            var shoeSixContext = _context.Casuals.Include(c => c.IdSepatuNavigation);
            return View(await shoeSixContext.ToListAsync());
        }

        // GET: Casuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casual = await _context.Casuals
                .Include(c => c.IdSepatuNavigation)
                .FirstOrDefaultAsync(m => m.IdSepatu == id);
            if (casual == null)
            {
                return NotFound();
            }

            return View(casual);
        }

        // GET: Casuals/Create
        public IActionResult Create()
        {
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu");
            return View();
        }

        // POST: Casuals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSepatu,StockSepatu,NamaSepatu,HargaSepatu,JenisSepatu,UkuranSepatu,BrandSepatu")] Casual casual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu", casual.IdSepatu);
            return View(casual);
        }

        // GET: Casuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casual = await _context.Casuals.FindAsync(id);
            if (casual == null)
            {
                return NotFound();
            }
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu", casual.IdSepatu);
            return View(casual);
        }

        // POST: Casuals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSepatu,StockSepatu,NamaSepatu,HargaSepatu,JenisSepatu,UkuranSepatu,BrandSepatu")] Casual casual)
        {
            if (id != casual.IdSepatu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasualExists(casual.IdSepatu))
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
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu", casual.IdSepatu);
            return View(casual);
        }

        // GET: Casuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casual = await _context.Casuals
                .Include(c => c.IdSepatuNavigation)
                .FirstOrDefaultAsync(m => m.IdSepatu == id);
            if (casual == null)
            {
                return NotFound();
            }

            return View(casual);
        }

        // POST: Casuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casual = await _context.Casuals.FindAsync(id);
            _context.Casuals.Remove(casual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasualExists(int id)
        {
            return _context.Casuals.Any(e => e.IdSepatu == id);
        }
    }
}
