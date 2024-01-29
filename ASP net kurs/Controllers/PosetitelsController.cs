using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_net_kurs.Data;
using BlazorApp2.Models;

namespace ASP_net_kurs.Controllers
{
    public class PosetitelsController : Controller
    {
        private readonly ASP_net_kursContext _context;

        public PosetitelsController(ASP_net_kursContext context)
        {
            _context = context;
        }

        // GET: Posetitels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posetitel.ToListAsync());
        }

        // GET: Posetitels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posetitel = await _context.Posetitel
                .FirstOrDefaultAsync(m => m.id == id);
            if (posetitel == null)
            {
                return NotFound();
            }

            return View(posetitel);
        }

        // GET: Posetitels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posetitels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Фамилия,Имя,Отчество,Возраст,Размер_багажа,Судимость,Комната,Питомец,Мини_бар,Фото")] Posetitel posetitel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posetitel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posetitel);
        }

        // GET: Posetitels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posetitel = await _context.Posetitel.FindAsync(id);
            if (posetitel == null)
            {
                return NotFound();
            }
            return View(posetitel);
        }

        // POST: Posetitels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Фамилия,Имя,Отчество,Возраст,Размер_багажа,Судимость,Комната,Питомец,Мини_бар,Фото")] Posetitel posetitel)
        {
            if (id != posetitel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posetitel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosetitelExists(posetitel.id))
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
            return View(posetitel);
        }

        // GET: Posetitels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posetitel = await _context.Posetitel
                .FirstOrDefaultAsync(m => m.id == id);
            if (posetitel == null)
            {
                return NotFound();
            }

            return View(posetitel);
        }

        // POST: Posetitels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posetitel = await _context.Posetitel.FindAsync(id);
            if (posetitel != null)
            {
                _context.Posetitel.Remove(posetitel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosetitelExists(int id)
        {
            return _context.Posetitel.Any(e => e.id == id);
        }
    }
}
