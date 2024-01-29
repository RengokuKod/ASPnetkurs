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
        private readonly IWebHostEnvironment webHostEnvironment;
        public RabotniksController(ASP_net_kursContext context, IWebHostEnvironment web)
        {
            _context = context;
            webHostEnvironment = web;
        }
        public string UploadedFile(Rabotnik rabotnik, IFormFile photo)
        {
            string? relativePath = null;

            if (photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "auto/rabotniknext");
                string fileName = photo.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                relativePath = Path.Combine("auto/rabotniknext", fileName);
                rabotnik.Фото = relativePath;
            }

            return relativePath;
        }
        // GET: Rabotniks
        public async Task<IActionResult> Index()
        {
            _context.GetData2();
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
            Rabotnik rabotnik = new Rabotnik();
            return View(rabotnik);
        }

        // POST: Rabotniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Rabotnik rabotnik)
        {
            if (ModelState.IsValid)
            {
                var photo = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
                string UniqueFileName = UploadedFile(rabotnik, photo);
                rabotnik.Фото = UniqueFileName;
                _context.Attach(rabotnik);
                _context.Entry(rabotnik).State = EntityState.Added;
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
        public async Task<IActionResult> Edit(int id,  Rabotnik rabotnik)
        {
            if (id != rabotnik.id)
            {
            
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var photo = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
                    string UniqueFileName = UploadedFile(rabotnik, photo);
                    rabotnik.Фото = UniqueFileName;
                    _context.Attach(rabotnik);
                    _context.Entry(rabotnik).State = EntityState.Added;
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
