using MVC.Models;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(UserView userview)
        {
            if (ModelState.IsValid)
            {
                Session["UserName"] = userview.name;
                Session["UserEmail"] = userview.email;
                return RedirectToAction("Index", "Home");
            
            }
             return View();
            
           
        }
    }
}