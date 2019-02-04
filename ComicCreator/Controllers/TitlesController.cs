using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicCreator.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ComicCreator.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ComicCreatorContext _context;

        public TitlesController(ComicCreatorContext context)
        {
            _context = context;
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titles.ToListAsync());
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Title title, IFormFile titleImage)
        {
            if (ModelState.IsValid)
            {
                if(titleImage != null)
                {
                    string mimeType = titleImage.ContentType;
                    long fileLength = titleImage.Length;
                    if(!(mimeType == "" || fileLength == 0))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await titleImage.CopyToAsync(memoryStream);
                            title.TitleImageContent = memoryStream.ToArray();
                        }
                        title.TitleImageMimeType = mimeType;
                        title.TitleImageFileName = titleImage.FileName;
                    }
                }

                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(title);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Title title, IFormFile titleImage)
        {
            if (id != title.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (titleImage != null && titleImage.ToString() != "")
                    {
                        string mimeType = titleImage.ContentType;
                        long fileLength = titleImage.Length;
                        if (!(mimeType == "" || fileLength == 0))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await titleImage.CopyToAsync(memoryStream);
                                title.TitleImageContent = memoryStream.ToArray();
                            }
                            title.TitleImageMimeType = mimeType;
                            title.TitleImageFileName = titleImage.FileName;
                        }
                    }

                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.Id))
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
            return View(title);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var title = await _context.Titles.FindAsync(id);
            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(int id)
        {
            return _context.Titles.Any(e => e.Id == id);
        }
    }
}
