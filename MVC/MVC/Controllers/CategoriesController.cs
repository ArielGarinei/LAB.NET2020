using MVC.Entities;
using MVC.Logic;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        Logic<Categories> logic = new Logic<Categories>();
        public ActionResult ListCategories()
        {
            try
            {
                List<Categories> categories;
                categories = logic.GetAll();
                List<CategoriesView> categoriesViews = (from category in categories
                                                      select new CategoriesView()
                                                    {
                                                        CategoryID = category.CategoryID,
                                                        CategoryName = category.CategoryName,
                                                        Description = category.Description,
                                                    }).ToList();

                return View(categoriesViews);
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(CategoriesView categoriesView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categories categories = new Categories() {CategoryID = categoriesView.CategoryID , CategoryName = categoriesView.CategoryName, Description = categoriesView.Description};
                    logic.InsertOne(categories);
                    return Redirect("/Categories/ListCategories");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult EditCategory(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categories categories = logic.GetOne(id);
                    CategoriesView categoriesView = new CategoriesView() { CategoryID = categories.CategoryID, CategoryName = categories.CategoryName, Description = categories.Description };

                    return View(categoriesView);
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpPost]
        public ActionResult EditCategory(CategoriesView categoriesView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categories categories = new Categories() { CategoryID = categoriesView.CategoryID, CategoryName = categoriesView.CategoryName, Description = categoriesView.Description };

                    logic.Update(categories);
                    return Redirect("/Categories/ListCategories");
                }
                //return View(categories);
                return View();

            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                logic.DeleteOne(id);
                return Redirect("/Categories/ListCategories");
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }

        }
    }
}