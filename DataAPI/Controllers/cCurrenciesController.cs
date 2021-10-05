using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAPI.Models;

namespace DataAPI.Controllers
{
    public class cCurrenciesController : Controller
    {
        private readonly cCurrencyContext _context;

        public cCurrenciesController(cCurrencyContext context)
        {
            _context = context;
        }

        // GET: cCurrencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.cCurrency.ToListAsync());
        }

        // GET: cCurrencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCurrency = await _context.cCurrency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cCurrency == null)
            {
                return NotFound();
            }

            return View(cCurrency);
        }

        // GET: cCurrencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cCurrencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CurrencyCode,ExchangeRate,cDate")] cCurrency cCurrency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCurrency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCurrency);
        }

        // GET: cCurrencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCurrency = await _context.cCurrency.FindAsync(id);
            if (cCurrency == null)
            {
                return NotFound();
            }
            return View(cCurrency);
        }

        // POST: cCurrencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CurrencyCode,ExchangeRate,cDate")] cCurrency cCurrency)
        {
            if (id != cCurrency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCurrency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cCurrencyExists(cCurrency.Id))
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
            return View(cCurrency);
        }

        // GET: cCurrencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCurrency = await _context.cCurrency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cCurrency == null)
            {
                return NotFound();
            }

            return View(cCurrency);
        }

        // POST: cCurrencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCurrency = await _context.cCurrency.FindAsync(id);
            _context.cCurrency.Remove(cCurrency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cCurrencyExists(int id)
        {
            return _context.cCurrency.Any(e => e.Id == id);
        }
    }
}
