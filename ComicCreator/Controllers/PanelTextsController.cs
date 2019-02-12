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
    public class PanelTextsController : Controller
    {
        private readonly ComicCreatorContext _context;

        public PanelTextsController(ComicCreatorContext context)
        {
            _context = context;
        }

        // GET: PanelTexts
        public async Task<IActionResult> Index()
        {
            var comicCreatorContext = _context.PanelTexts.Include(p => p.Panel);
            return View(await comicCreatorContext.ToListAsync());
        }

        // GET: PanelTexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelText = await _context.PanelTexts
                .Include(p => p.Panel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelText == null)
            {
                return NotFound();
            }

            return View(panelText);
        }

        // GET: PanelTexts/Create
        public IActionResult Create()
        {
            ViewData["PanelId"] = new SelectList(_context.Panels, "Id", "Id");
            return View();
        }

        // POST: PanelTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,TextContent,TailX,TailY,TextClass,PanelId")] PanelText panelText)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panelText);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PanelId"] = new SelectList(_context.Panels, "Id", "Id", panelText.PanelId);
            return View(panelText);
        }

        // GET: PanelTexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelText = await _context.PanelTexts.FindAsync(id);
            if (panelText == null)
            {
                return NotFound();
            }
            ViewData["PanelId"] = new SelectList(_context.Panels, "Id", "Id", panelText.PanelId);
            return View(panelText);
        }

        // POST: PanelTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderNumber,TextContent,TailX,TailY,TextClass,PanelId")] PanelText panelText)
        {
            if (id != panelText.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panelText);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanelTextExists(panelText.Id))
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
            ViewData["PanelId"] = new SelectList(_context.Panels, "Id", "Id", panelText.PanelId);
            return View(panelText);
        }

        // GET: PanelTexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelText = await _context.PanelTexts
                .Include(p => p.Panel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelText == null)
            {
                return NotFound();
            }

            return View(panelText);
        }

        // POST: PanelTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var panelText = await _context.PanelTexts.FindAsync(id);
            _context.PanelTexts.Remove(panelText);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanelTextExists(int id)
        {
            return _context.PanelTexts.Any(e => e.Id == id);
        }
    }
}
