using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.JQGridSample.Models;
using RnD.JQGridSample.ViewModels;

namespace RnD.JQGridSample.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        // for display jqGrid
        public ActionResult GetCategories()
        {
            var categories = _db.Categories.ToList();

            var viewProducts = categories.Select(cat => new CategoryGridModels() { CategoryId = Convert.ToString(cat.CategoryId), Name = cat.Name });

            //No of total records
            int totalRecords = (int)categories.Count;
            //Calculate total no of page  
            int totalPages = 1;   // (int)Math.Ceiling((float)totalRecords / (float)Rows);
            var getdata = new
            {
                total = totalPages,
                page = 1,
                records = totalRecords,
                rows = (
                    from p in viewProducts
                    select new
                    {
                        cell = new string[] { 
							p.CategoryId,
                            p.CategoryId,
							p.Name,
							"<a id='lnkDetailsCategory_" + p.CategoryId + "' class='lnkDetailsCategory button' href='/Category/Details/" + p.CategoryId + "'>Details</a>",
                            "<a id='lnkEditCategory_" + p.CategoryId + "' class='lnkEditCategory button' href='/Category/Edit/" + p.CategoryId + "'>Edit</a>",
							"<a id='lnkDeleteCategory_" + p.CategoryId + "' class='lnkDeleteCategory button' href='/Category/Delete/" + p.CategoryId + "'>Delete</a>" }
                    }).ToArray()
            };
            return Json(getdata);
        }


        //
        // GET: /Category/Details/By ID

        public ActionResult Details(int id)
        {
            Category category = _db.Categories.Find(id);

            //return View(category);
            //return PartialView("_Details", category);
            return View("_Details", category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            //return View();
            //return PartialView("_Create");
            return View("_Create");
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    //return Content(Boolean.TrueString);
                    return RedirectToAction("Index", "Category");
                }

                //return View(category);
                //return PartialView("_Create", category);
                //return Content("Please review your form.");
                return View("_Create", category);
            }
            catch (Exception ex)
            {
                //return Content("Error Occured!");
                //return RedirectToAction("Index", "Category");
                return View("_Create", category);
            }

        }

        //
        // GET: /Category/Edit/By ID

        public ActionResult Edit(int id)
        {
            Category category = _db.Categories.Find(id);

            //return View(category);
            //return PartialView("_Edit", category);
            return View("_Edit", category);
        }

        //
        // POST: /Category/Edit/By ID

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(category).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    //return Content(Boolean.TrueString);
                    return RedirectToAction("Index", "Category");
                }

                //return View(category);
                //return PartialView("_Edit", category);
                //return Content("Please review your form.");
                return View("_Edit", category);
            }
            catch (Exception ex)
            {
                //return Content("Error Occured!");
                //return RedirectToAction("Index", "Category");
                return View("_Edit", category);
            }
        }

        //
        // GET: /Category/Delete/By ID

        public ActionResult Delete(int id)
        {
            Category category = _db.Categories.Find(id);

            //return View(category);
            //return PartialView("_Delete", category);
            return View("_Delete", category);
        }

        //
        // POST: /Category/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _db.Categories.Find(id);
            try
            {
                //Category category = _db.Categories.Find(id);
                if (category != null)
                {
                    _db.Categories.Remove(category);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    //return Content(Boolean.TrueString);
                    return RedirectToAction("Index", "Category");
                }

                //return Content("Please review your form.");
                return View("_Delete", category);
            }
            catch (Exception ex)
            {
                //return Content("Error Occured!");
                return View("_Delete", category);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
