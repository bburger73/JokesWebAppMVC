using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebAppMVC.Data;
using JokesWebAppMVC.Models;

namespace JokesWebAppMVC.Controllers
{
    public class ComediansController : Controller
    {
        private readonly JokesWebAppMVCContext _context;

        public ComediansController(JokesWebAppMVCContext context)
        {
            _context = context;
        }

        // GET: Comedians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comedian.ToListAsync());
        }

        // GET: Comedians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comedian == null)
            {
                return NotFound();
            }

            var comedian = await _context.Comedian
                .FirstOrDefaultAsync(m => m.id == id);
            if (comedian == null)
            {
                return NotFound();
            }

            return View(comedian);
        }

        // GET: Comedians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comedians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,type,image,url")] Comedian comedian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comedian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comedian);
        }

        // GET: Comedians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comedian == null)
            {
                return NotFound();
            }

            var comedian = await _context.Comedian.FindAsync(id);
            if (comedian == null)
            {
                return NotFound();
            }
            return View(comedian);
        }

        // POST: Comedians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,type,image,url")] Comedian comedian)
        {
            if (id != comedian.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comedian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComedianExists(comedian.id))
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
            return View(comedian);
        }

        // GET: Comedians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comedian == null)
            {
                return NotFound();
            }

            var comedian = await _context.Comedian
                .FirstOrDefaultAsync(m => m.id == id);
            if (comedian == null)
            {
                return NotFound();
            }

            return View(comedian);
        }

        // POST: Comedians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comedian == null)
            {
                return Problem("Entity set 'JokesWebAppMVCContext.Comedian'  is null.");
            }
            var comedian = await _context.Comedian.FindAsync(id);
            if (comedian != null)
            {
                _context.Comedian.Remove(comedian);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComedianExists(int id)
        {
            return _context.Comedian.Any(e => e.id == id);
        }
    }
}
