using MVC.Entities;
using MVC.Logic;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private Logic<Products> logic = new Logic<Products>();
        public async Task<ActionResult>ListProducts()
        {
            try
            {
                //List<Products> lst;
                //lst = logic.GetAll();
                string result = await logic.GetAllApiProductsAsync();
                var products = JsonConvert.DeserializeObject<List<Products>>(result);
                List<ProductsView> productsViews = (from product in products
                                                    select new ProductsView()
                                                    {
                                                     ProductID = product.ProductID,
                                                     ProductName = product.ProductName,
                                                     QuantityPerUnit = product.QuantityPerUnit
                                                    }).ToList();
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
        public async Task<ActionResult> NewProduct(ProductsView productView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Products product = new Products() { ProductID = productView.ProductID, ProductName = productView.ProductName, QuantityPerUnit = productView.QuantityPerUnit };
                    await logic.PostApiProductsAsync(product);
                    //logic.InsertOne(product);
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

        public async Task<ActionResult> EditProduct(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await logic.GetApiProductsAsync(id);
                    var myProduct = JsonConvert.DeserializeObject<Products>(result);

                    //Products myProduct = logic.GetOne(id);
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
        public async Task<ActionResult> EditProduct(ProductsView productView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Products product = new Products() { ProductID = productView.ProductID, ProductName = productView.ProductName, QuantityPerUnit = productView.QuantityPerUnit };
                    await logic.PutApiProductsAsync(product, product.ProductID);
                    //logic.Update(product);
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
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await logic.DeleteApiProductsAsync(id);
                //logic.DeleteOne(id);
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