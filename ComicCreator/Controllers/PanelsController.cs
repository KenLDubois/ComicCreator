using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicCreator.Models;

namespace ComicCreator.Controllers
{
    public class PanelsController : Controller
    {
        private readonly ComicCreatorContext _context;

        public PanelsController(ComicCreatorContext context)
        {
            _context = context;
        }

        // GET: Panels
        public async Task<IActionResult> Index()
        {
            var comicCreatorContext = _context.Panels.Include(p => p.Issue);
            return View(await comicCreatorContext.ToListAsync());
        }

        // GET: Panels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panel = await _context.Panels
                .Include(p => p.Issue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panel == null)
            {
                return NotFound();
            }

            return View(panel);
        }

        // GET: Panels/Create
        public IActionResult Create()
        {
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Id");
            return View();
        }

        // POST: Panels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,IssueId")] Panel panel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Id", panel.IssueId);
            return View(panel);
        }

        // GET: Panels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panel = await _context.Panels.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Id", panel.IssueId);
            return View(panel);
        }

        // POST: Panels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderNumber,IssueId")] Panel panel)
        {
            if (id != panel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanelExists(panel.Id))
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
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Id", panel.IssueId);
            return View(panel);
        }

        // GET: Panels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panel = await _context.Panels
                .Include(p => p.Issue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panel == null)
            {
                return NotFound();
            }

            return View(panel);
        }

        // POST: Panels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var panel = await _context.Panels.FindAsync(id);
            _context.Panels.Remove(panel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanelExists(int id)
        {
            return _context.Panels.Any(e => e.Id == id);
        }
    }
}
