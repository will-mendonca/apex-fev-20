using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreExemplo.Models;

namespace EFCoreExemplo.Controllers
{
    public class InstrutoresController : Controller
    {
        private readonly FichaDbContext _context;

        public InstrutoresController(FichaDbContext context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instrutores.
                Where(x => x.Nome.Contains("A")).
                OrderBy(x => x.Nome).ThenBy(x => x.Id).
                ToListAsync());
        }

        // GET: Instrutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutor == null)
            {
                return NotFound();
            }

            return View(instrutor);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrutor);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutores.FindAsync(id);
            if (instrutor == null)
            {
                return NotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Instrutor instrutor)
        {
            if (id != instrutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutorExists(instrutor.Id))
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
            return View(instrutor);
        }

        // GET: Instrutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutor == null)
            {
                return NotFound();
            }

            return View(instrutor);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrutor = await _context.Instrutores.FindAsync(id);
            _context.Instrutores.Remove(instrutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrutorExists(int id)
        {
            return _context.Instrutores.Any(e => e.Id == id);
        }
    }
}
