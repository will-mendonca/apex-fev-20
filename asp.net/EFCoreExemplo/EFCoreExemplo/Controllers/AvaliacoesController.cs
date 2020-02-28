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
    public class AvaliacoesController : Controller
    {
        private readonly FichaDbContext _context;

        public AvaliacoesController(FichaDbContext context)
        {
            _context = context;
        }

        // GET: Avaliacoes
        public async Task<IActionResult> Index()
        {
            var fichaDbContext = _context.Avaliacoes.Include(a => a.Aluno).Include(a => a.Curso).Include(a => a.Instrutor);
            return View(await fichaDbContext.ToListAsync());
        }

        // GET: Avaliacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Aluno)
                .Include(a => a.Curso)
                .Include(a => a.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacoes/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome");
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "Id", "Nome");
            return View();
        }

        // POST: Avaliacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId,CursoId,InstrutorId,Data,AvaliacaoSala,AvaliacaoPontualidade,AvaliacaoConteudo,AvaliacaoInstrutor,Dificuldade,Sugestao")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", avaliacao.AlunoId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", avaliacao.CursoId);
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "Id", "Nome", avaliacao.InstrutorId);
            return View(avaliacao);
        }

        // GET: Avaliacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", avaliacao.AlunoId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", avaliacao.CursoId);
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "Id", "Nome", avaliacao.InstrutorId);
            return View(avaliacao);
        }

        // POST: Avaliacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId,CursoId,InstrutorId,Data,AvaliacaoSala,AvaliacaoPontualidade,AvaliacaoConteudo,AvaliacaoInstrutor,Dificuldade,Sugestao")] Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", avaliacao.AlunoId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", avaliacao.CursoId);
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "Id", "Nome", avaliacao.InstrutorId);
            return View(avaliacao);
        }

        // GET: Avaliacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Aluno)
                .Include(a => a.Curso)
                .Include(a => a.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.Id == id);
        }
    }
}
