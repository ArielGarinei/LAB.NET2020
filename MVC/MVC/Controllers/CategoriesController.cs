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
            catch (Exception)
            {
                return Redirect("/Shared/Error");
            }
        }

        public ActionResult NewCategory()
        {
            return View();

        }

        [HttpPost]
        public ActionResult NewCategory(Categories category)
        {
            try
            {
                    logic.InsertOne(category);
                    return Redirect("/Categories/ListCategories");
            }
            catch (Exception )
            {
                return Redirect("/Shared/Error");
            }
        }

        public ActionResult EditCategory(int id)
        {
            try
            {
                Categories categories = logic.GetOne(id);
                return View(categories);
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");
            }
        }

        [HttpPost]
        public ActionResult EditCategory(Categories categories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logic.Update(categories);
                    return Redirect("/Categories/ListCategories");
                }
                return View(categories);
            }
            catch (Exception )
            {
                return Redirect("/Shared/Error");
            }
        }
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                logic.DeleteOne(id);
                return Redirect("/Categories/ListCategories");
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");
            }

        }
    }
}