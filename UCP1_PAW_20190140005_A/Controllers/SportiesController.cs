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
    public class SportiesController : Controller
    {
        private readonly ShoeSixContext _context;

        public SportiesController(ShoeSixContext context)
        {
            _context = context;
        }

        // GET: Sporties
        public async Task<IActionResult> Index()
        {
            var shoeSixContext = _context.Sporties.Include(s => s.IdSepatu1).Include(s => s.IdSepatuNavigation);
            return View(await shoeSixContext.ToListAsync());
        }

        // GET: Sporties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sporty = await _context.Sporties
                .Include(s => s.IdSepatu1)
                .Include(s => s.IdSepatuNavigation)
                .FirstOrDefaultAsync(m => m.IdSepatu == id);
            if (sporty == null)
            {
                return NotFound();
            }

            return View(sporty);
        }

        // GET: Sporties/Create
        public IActionResult Create()
        {
            ViewData["IdSepatu"] = new SelectList(_context.Customers, "IdSepatu", "IdSepatu");
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu");
            return View();
        }

        // POST: Sporties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSepatu,StockSepatu,NamaSepatu,HargaSepatu,JenisSepatu,UkuranSepatu,BrandSepatu")] Sporty sporty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sporty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSepatu"] = new SelectList(_context.Customers, "IdSepatu", "IdSepatu", sporty.IdSepatu);
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu", sporty.IdSepatu);
            return View(sporty);
        }

        // GET: Sporties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sporty = await _context.Sporties.FindAsync(id);
            if (sporty == null)
            {
                return NotFound();
            }
            ViewData["IdSepatu"] = new SelectList(_context.Customers, "IdSepatu", "IdSepatu", sporty.IdSepatu);
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu", sporty.IdSepatu);
            return View(sporty);
        }

        // POST: Sporties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSepatu,StockSepatu,NamaSepatu,HargaSepatu,JenisSepatu,UkuranSepatu,BrandSepatu")] Sporty sporty)
        {
            if (id != sporty.IdSepatu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sporty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportyExists(sporty.IdSepatu))
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
            ViewData["IdSepatu"] = new SelectList(_context.Customers, "IdSepatu", "IdSepatu", sporty.IdSepatu);
            ViewData["IdSepatu"] = new SelectList(_context.Admins, "IdSepatu", "IdSepatu", sporty.IdSepatu);
            return View(sporty);
        }

        // GET: Sporties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sporty = await _context.Sporties
                .Include(s => s.IdSepatu1)
                .Include(s => s.IdSepatuNavigation)
                .FirstOrDefaultAsync(m => m.IdSepatu == id);
            if (sporty == null)
            {
                return NotFound();
            }

            return View(sporty);
        }

        // POST: Sporties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sporty = await _context.Sporties.FindAsync(id);
            _context.Sporties.Remove(sporty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportyExists(int id)
        {
            return _context.Sporties.Any(e => e.IdSepatu == id);
        }
    }
}
