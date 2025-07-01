using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Protekaji.Data;
using Protekaji.Models;

namespace Protekaji
{  
    public class ExtintorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExtintorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Extintor
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExtintorModels.ToListAsync());
        }

        // GET: Extintor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extintorModels = await _context.ExtintorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extintorModels == null)
            {
                return NotFound();
            }

            return View(extintorModels);
        }

        // GET: Extintor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Extintor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Tipo,Capacidade,NumeroDeSerie")] ExtintorModels extintorModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extintorModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(extintorModels);
        }

        // GET: Extintor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extintorModels = await _context.ExtintorModels.FindAsync(id);
            if (extintorModels == null)
            {
                return NotFound();
            }
            return View(extintorModels);
        }

        // POST: Extintor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Tipo,Capacidade,NumeroDeSerie")] ExtintorModels extintorModels)
        {
            if (id != extintorModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extintorModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtintorModelsExists(extintorModels.Id))
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
            return View(extintorModels);
        }

        // GET: Extintor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extintorModels = await _context.ExtintorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extintorModels == null)
            {
                return NotFound();
            }

            return View(extintorModels);
        }

        // POST: Extintor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var extintorModels = await _context.ExtintorModels.FindAsync(id);
            if (extintorModels != null)
            {
                _context.ExtintorModels.Remove(extintorModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtintorModelsExists(int id)
        {
            return _context.ExtintorModels.Any(e => e.Id == id);
        }
    }
}
