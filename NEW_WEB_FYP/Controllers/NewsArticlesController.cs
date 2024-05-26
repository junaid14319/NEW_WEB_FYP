using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.EntityFrameworkCore;
using NEW_WEB_FYP.Data;
using NEW_WEB_FYP.Model;

namespace NEW_WEB_FYP.Controllers
{
    public class NewsArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _hostingEnvironment;
        public IEnumerable<SelectListItem> Categories { get; private set; }

        public NewsArticlesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, IEnumerable<SelectListItem> categories)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            Categories = categories;
        }
        // GET: NewsArticles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NewsArticles.Include(n => n.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NewsArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = await _context.NewsArticles
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);
        }

        // GET: NewsArticles/Create
        public IActionResult Create()
        {
            var categories = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryID.ToString()
            }).ToList();

            ViewData["Categories"] = new SelectList(categories, "Value", "Text");

            return View();
        }

        // POST: NewsArticles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Title,Content,ImageUrl,Author,CreatedDate,UpdatedDate,CategoryID")] NewsArticle newsArticle, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;

                if (file != null)
                {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "ImageUrl");
                    fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);
                    if (newsArticle.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, newsArticle.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    newsArticle.ImageUrl = @"\ImageUrl\" + fileName;
                }

                // Add the newsArticle to the context and save changes
                _context.Add(newsArticle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If model state is not valid, repopulate Categories dropdown
            var categories = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryID.ToString()
            }).ToList();

            ViewData["Categories"] = new SelectList(categories, "Value", "Text", newsArticle.CategoryID);

            return View(newsArticle);
        }


        // GET: NewsArticles/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", newsArticle.CategoryID);
            return View(newsArticle);
        }

        // POST: NewsArticles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Title,Content,ImageUrl,Author,CreatedDate,UpdatedDate,CategoryID")] NewsArticle newsArticle)
        {
            if (id != newsArticle.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsArticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsArticleExists(newsArticle.NewsId))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", newsArticle.CategoryID);
            return View(newsArticle);
        }

        // GET: NewsArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = await _context.NewsArticles
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);
        }

        // POST: NewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle != null)
            {
                _context.NewsArticles.Remove(newsArticle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsArticleExists(int id)
        {
            return _context.NewsArticles.Any(e => e.NewsId == id);
        }
    }
}
