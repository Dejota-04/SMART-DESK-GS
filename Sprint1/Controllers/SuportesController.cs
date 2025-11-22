using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint1.Data;
using Sprint1.Models;

namespace Sprint1.Controllers
{
    public class SuportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suportes
        public async Task<IActionResult> Index()
        {
            // Carrega quem pediu (Solicitante) e quem atendeu (Atendente)
            var applicationDbContext = _context.Suportes
                .Include(s => s.Atendente)
                .Include(s => s.Solicitante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Suportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var suporte = await _context.Suportes
                .Include(s => s.Atendente)
                .Include(s => s.Solicitante)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (suporte == null) return NotFound();

            return View(suporte);
        }

        // GET: Suportes/Create
        public IActionResult Create()
        {
            // Carrega a lista de usuários para escolher quem está abrindo o chamado
            // "Id" é o valor que salva, "Nome" é o que aparece na tela
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Suportes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,AdminId,Titulo,Descricao,DataReclamacao,DataResolucao,Status")] Suporte suporte)
        {
            // Força status inicial e data atual
            suporte.Status = StatusSuporte.AGUARDANDO;
            suporte.DataReclamacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(suporte);
                await _context.SaveChangesAsync();
                TempData["MensagemSucesso"] = "Chamado aberto com sucesso! 🎫";
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", suporte.UsuarioId);
            return View(suporte);
        }

        // GET: Suportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var suporte = await _context.Suportes.FindAsync(id);
            if (suporte == null) return NotFound();

            ViewData["AdminId"] = new SelectList(_context.Usuarios.Where(u => u.Role == RoleEnum.ADM), "Id", "Nome", suporte.AdminId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", suporte.UsuarioId);
            return View(suporte);
        }

        // POST: Suportes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,AdminId,Titulo,Descricao,DataReclamacao,DataResolucao,Status")] Suporte suporte)
        {
            if (id != suporte.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Se o status for RESOLVIDO e não tiver data, coloca agora
                    if (suporte.Status == StatusSuporte.RESOLVIDO && suporte.DataResolucao == null)
                    {
                        suporte.DataResolucao = DateTime.Now;
                    }

                    _context.Update(suporte);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Chamado atualizado! 📝";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuporteExists(suporte.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Usuarios, "Id", "Nome", suporte.AdminId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", suporte.UsuarioId);
            return View(suporte);
        }

        // GET: Suportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var suporte = await _context.Suportes
                .Include(s => s.Atendente)
                .Include(s => s.Solicitante)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (suporte == null) return NotFound();

            return View(suporte);
        }

        // POST: Suportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suporte = await _context.Suportes.FindAsync(id);
            if (suporte != null) _context.Suportes.Remove(suporte);

            await _context.SaveChangesAsync();
            TempData["MensagemSucesso"] = "Chamado excluído. 🗑️";
            return RedirectToAction(nameof(Index));
        }

        private bool SuporteExists(int id)
        {
            return _context.Suportes.Any(e => e.Id == id);
        }
    }
}