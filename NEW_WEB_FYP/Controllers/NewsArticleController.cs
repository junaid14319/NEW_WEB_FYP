using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using NEW_WEB_FYP.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using NEW_WEB_FYP.Model;

namespace NEW_WEB_FYP.Controllers
{
    public class NewsArticleController : Controller
    {
        private readonly IUnitofWork _unitofwork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public NewsArticleController(IUnitofWork unitofwork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofwork = unitofwork;
            _hostingEnvironment = hostingEnvironment;
        }

        #region ApiCall
        public async Task<IActionResult> GetAllProducts()
        {
            var newsArticles = await _unitofwork.NewsArticle.GetAll();
            return Json(new { data = newsArticles });
        }
        #endregion

        // GET: NewsArticle
        public async Task<IActionResult> Index()
        {
            NewsArticleVm vm = new NewsArticleVm
            {
                NewsArticles = await _unitofwork.NewsArticle.GetAll(includeProperties: "Category")
            };
            return View(vm);
        }

        // GET: NewsArticle/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = _unitofwork.NewsArticle.GetT(x => x.NewsId == id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);
        }

        // GET: NewsArticle/CreateUpdate/5
        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id)
        {
            NewsArticleVm vm = new NewsArticleVm
            {
                newsArticle = new NewsArticle(),
                Categories = (await _unitofwork.Category.GetAll())
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CategoryID.ToString()
                    }).ToList()
            };

            if (id == null)
            {
                return View(vm);
            }
            else
            {
                vm.newsArticle = _unitofwork.NewsArticle.GetT(x => x.NewsId == id);
                if (vm.newsArticle == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        // POST: NewsArticle/CreateUpdate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(NewsArticleVm vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "NewsImage");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    if (!string.IsNullOrEmpty(vm.newsArticle.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, vm.newsArticle.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    vm.newsArticle.ImageUrl = @"\NewsImage\" + fileName;
                }

                if (vm.newsArticle.NewsId == 0)
                {
                    _unitofwork.NewsArticle.Add(vm.newsArticle);
                    TempData["Success"] = "NewsArticle saved successfully.";
                }
                else
                {
                    _unitofwork.NewsArticle.Update(vm.newsArticle);
                    TempData["Success"] = "NewsArticle updated successfully.";
                }

                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                vm.Categories = (await _unitofwork.Category.GetAll())
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CategoryID.ToString()
                    }).ToList();
                return View(vm);
            }
        }

        // GET: NewsArticle/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = _unitofwork.NewsArticle.GetT(x => x.NewsId == id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);
        }

        // POST: NewsArticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var newsArticle = _unitofwork.NewsArticle.GetT(x => x.NewsId == id);
            if (newsArticle != null)
            {
                if (!string.IsNullOrEmpty(newsArticle.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, newsArticle.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitofwork.NewsArticle.Delete(newsArticle);
                _unitofwork.Save();
            }

            return RedirectToAction("Index");
        }
    }
}
