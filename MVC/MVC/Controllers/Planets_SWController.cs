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

            var json = new WebClient().DownloadString("https://swapi.dev/api/planets/");
            var Planets = JsonConvert.DeserializeObject<Planets>(json);

            return View(Planets);

        }
    }
}