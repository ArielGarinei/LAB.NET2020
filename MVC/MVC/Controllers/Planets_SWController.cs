using MVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class Planets_SWController : Controller
    {
        // GET: Planets_SW
        
        public ActionResult ListPlanets_SW()
        {

            string url = "https://swapi.dev/api/planets/?page=1";
            ViewBag.page = 1;
            var json = new WebClient().DownloadString(url);
            var Planets = JsonConvert.DeserializeObject<Planets>(json);

            return View(Planets);

        }
        //public ActionResult ListPlanets_SW(int page)
        //{
        //    ViewBag.page = page;
        //    string url = "https://swapi.dev/api/planets/?page=" + page.ToString();
        //    var json = new WebClient().DownloadString(url);
        //    var Planets = JsonConvert.DeserializeObject<Planets>(json);

        //    return View(Planets);

        //}

    }
}