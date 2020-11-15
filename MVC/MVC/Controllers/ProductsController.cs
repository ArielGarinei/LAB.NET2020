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

                string url = "https://localhost:44364/api/Products";
                var client = new HttpClient();
                var httpRespoonse = await client.GetAsync(url);
                if (httpRespoonse.IsSuccessStatusCode)
                {
                    var result = await httpRespoonse.Content.ReadAsStringAsync();

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
                return RedirectToAction("Error", "Error");

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
                    string url = "https://localhost:44364/api/Products";
                    var client = new HttpClient();
                    var data = JsonConvert.SerializeObject(product);
                    HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    var httpRespoonse = await client.PostAsync(url, content);
                    if (httpRespoonse.IsSuccessStatusCode)
                    {
                        var result = await httpRespoonse.Content.ReadAsStringAsync();
                    }

                    //Products product = new Products(){ ProductID = productView.ProductID, ProductName = productView.ProductName, QuantityPerUnit = productView.QuantityPerUnit };
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
        public async Task<ActionResult> EditProduct(ProductsView productView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Products product = new Products() { ProductID = productView.ProductID, ProductName = productView.ProductName, QuantityPerUnit = productView.QuantityPerUnit };
                    string url = "https://localhost:44364/api/Products/" + product.ProductID;
                    var client = new HttpClient();
                    var data = JsonConvert.SerializeObject(product);
                    HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    var httpRespoonse = await client.PutAsync(url, content);
                    if (httpRespoonse.IsSuccessStatusCode)
                    {
                        var result = await httpRespoonse.Content.ReadAsStringAsync();
                    }




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
                string url = "https://localhost:44364/api/Products/" + id.ToString();
                var client = new HttpClient();
                var httpRespoonse = await client.DeleteAsync(url);
                if (httpRespoonse.IsSuccessStatusCode)
                {
                    return Redirect("/Products/ListProducts");
                }


                return RedirectToAction("Error", "Error");

                //logic.DeleteOne(id);
            }
            catch (Exception ex)
            {
                TempData["exMessage"] = ex.Message;
                return RedirectToAction("Error", "Error");
            }
        }
    }
}