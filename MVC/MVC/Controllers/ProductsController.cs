using MVC.Entities;
using MVC.Logic;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private Logic<Products> logic = new Logic<Products>();
        public ActionResult ListProducts()
        {
            try
            {
                
                List<Products> lst;
                lst = logic.GetAll();
                List<ProductsView> productsViews = (from products in lst
                                                    select new ProductsView()
                                                    {   ProductID = products.ProductID,
                                                        ProductName = products.ProductName,
                                                        QuantityPerUnit = products.QuantityPerUnit
                                                    }).ToList();

                return View(productsViews);
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");
            }
        }

        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Products products)
        {
            try
            {
                logic.InsertOne(products);
                return Redirect("/Products/ListProducts");
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");

            }
        }

        public ActionResult EditProduct(int id)
        {
            try
            {
                Products myProduct = logic.GetOne(id);
                return View(myProduct);
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");

            }
        }

        [HttpPost]
        public ActionResult EditProduct(Products products)
        {
            try
            {
                    logic.Update(products);
                    return Redirect("/Products/ListProducts");
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");

            }
        }
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                logic.DeleteOne(id);
                return Redirect("/Products/ListProducts");
            }
            catch (Exception)
            {
                return Redirect("/Shared/Error");
            }
        }
    }
}