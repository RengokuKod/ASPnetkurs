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
    public class RabotniksController : Controller
    {
        private readonly ASP_net_kursContext _context;

        public RabotniksController(ASP_net_kursContext context)
        {
            _context = context;
        }

        // GET: Rabotniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rabotnik.ToListAsync());
        }

        // GET: Rabotniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabotnik = await _context.Rabotnik
                .FirstOrDefaultAsync(m => m.id == id);
            if (rabotnik == null)
            {
                return NotFound();
            }

            return View(rabotnik);
        }

        // GET: Rabotniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rabotniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Фамилия,Имя,Отчество,Рост,Должность,Стаж,Планета_происхождения,Образование,Возраст,Фото")] Rabotnik rabotnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rabotnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rabotnik);
        }

        // GET: Rabotniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabotnik = await _context.Rabotnik.FindAsync(id);
            if (rabotnik == null)
            {
                return NotFound();
            }
            return View(rabotnik);
        }

        // POST: Rabotniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Фамилия,Имя,Отчество,Рост,Должность,Стаж,Планета_происхождения,Образование,Возраст,Фото")] Rabotnik rabotnik)
        {
            if (id != rabotnik.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rabotnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RabotnikExists(rabotnik.id))
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
            return View(rabotnik);
        }

        // GET: Rabotniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabotnik = await _context.Rabotnik
                .FirstOrDefaultAsync(m => m.id == id);
            if (rabotnik == null)
            {
                return NotFound();
            }

            return View(rabotnik);
        }

        // POST: Rabotniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rabotnik = await _context.Rabotnik.FindAsync(id);
            if (rabotnik != null)
            {
                _context.Rabotnik.Remove(rabotnik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RabotnikExists(int id)
        {
            return _context.Rabotnik.Any(e => e.id == id);
        }
    }
}
