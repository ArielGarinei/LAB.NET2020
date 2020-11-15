using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Planets
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public IList<Planet> results { get; set; }
    }

}