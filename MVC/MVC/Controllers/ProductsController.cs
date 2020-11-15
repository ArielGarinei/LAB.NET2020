using MVC.Entities;
using MVC.Logic;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                //lst = logic.GetAll();
                //List<ProductsView> productsViews = (from products in lst
                //                                    select new ProductsView()
                //                                    {   ProductID = products.ProductID,
                //                                        ProductName = products.ProductName,
                //                                        QuantityPerUnit = products.QuantityPerUnit
                //                                    }).ToList();

                var json = new WebClient().DownloadString("https://localhost:44369/api/Products");
                var productsViews = JsonConvert.DeserializeObject<List<ProductsView>>(json);

                return View(productsViews);
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult NewProduct()
        {
            return View(new ProductsView());
        }

        [HttpPost]
        public ActionResult NewProduct(ProductsView productView)
        {
            try
            {
                if (ModelState.IsValid) //devuelve falso
                {
                    Products product = new Products(){ ProductID = productView.ProductID, ProductName = productView.ProductName, QuantityPerUnit = productView.QuantityPerUnit };
                    logic.InsertOne(product);
                    return Redirect("/Products/ListProducts");
                }
                return View();

            }
            catch (Exception ex)
            {
               
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult EditProduct(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Products myProduct = logic.GetOne(id);
                    ProductsView productsView = new ProductsView() { ProductID = myProduct.ProductID, ProductName = myProduct.ProductName, QuantityPerUnit = myProduct.QuantityPerUnit };
                    return View(productsView);
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
        public ActionResult EditProduct(ProductsView productView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Products product = new Products() { ProductID = productView.ProductID, ProductName = productView.ProductName, QuantityPerUnit = productView.QuantityPerUnit };

                    logic.Update(product);
                    return Redirect("/Products/ListProducts");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                logic.DeleteOne(id);
                return Redirect("/Products/ListProducts");
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }
    }
}