using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firstpro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEW_WEB_FYP.Ifrastructure.IRepositroy;
using NEW_WEB_FYP.Model;



namespace NEW_WEB_FYP.Controllers
{
   
   
    public class CategoryController : Controller
    {
        private IUnitofWork _unitofwork;

        public CategoryController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;

        }

        // GET: Catgrs
        public async Task<IActionResult> Index()
        {
           // CatgrVm Catvm = new CatgrVm();
         var catgrs = await _unitofwork.Category.GetAll();
            return View(catgrs);
        }

        // GET: Catgrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var catgr =  _unitofwork.Category.GetT(x => x.CategoryID == id);
            if (catgr == null)
            {
                return NotFound();
            }
 
            return View(catgr);
        }


        // GET: Catgr/CreateUpdate/5
        [HttpGet]
        public IActionResult CreateUpdate(int id)
        {
            Category catgr = new Category(); 
           if (id == 0)
           {
               return View(catgr);
           }
          else
          {

            var CreateEdit = _unitofwork.Category.GetT(x => x.CategoryID == id);
                if (CreateEdit == null)
                {
                    return NotFound();
                }
                else 
                {
                    return View(CreateEdit);
                }
          }
        }

        // POST: Catgr/CreateUpdate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(Category catgr)
        {
           
            if (ModelState.IsValid)
            {
                if (catgr.CategoryID == 0)
                {
                    _unitofwork.Category.Add(catgr);
                }
                else 
                {
                    _unitofwork.Category.Update(catgr);
                }
                
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            else
                return View(catgr);
        }

        // GET: Catgrs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            var catgrs = _unitofwork.Category.GetT(x => x.CategoryID == id);
            if (catgrs == null)
            {
                return NotFound();
            }

            return View(catgrs);
        }

        // POST: Catgrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return Problem("Entity set 'AppDbContext.Catgrs'  is null.");
            }
            var catgr = _unitofwork.Category.GetT(x => x.CategoryID == id);
            if (catgr != null)
            {
                _unitofwork.Category.Delete(catgr);
            }

             _unitofwork.Save();
            return RedirectToAction("Index");
        }

        //private bool CatgrExists(int id)
        //{
            
        //    return _unitofwork.Catgr.Any(e => e.Equals == id);
        //}
    }
}
