using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Helpers;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private asp9Entities db = new asp9Entities();

        public ActionResult Index()
        {
            var allFlowers = db.FLOWERs.ToList();
            var characteristics = db.FLOWERVIEWs.ToList();
            var allColors = db.COLORs.ToList();

            List<FLOWER> myFlowers = new List<FLOWER>();
            List<FLOWERVIEW> allCharacteristics = new List<FLOWERVIEW>();
            List<COLOR> allColorsList = new List<COLOR>();

            foreach (var flower in allFlowers)
            {
                // If flower color == 1 (Blue)
                if (flower.COLOR_ID == 1)
                {
                    // Add the flower to the list
                    myFlowers.Add(flower);
                }      
            }

            foreach (var record in characteristics)
            {
                allCharacteristics.Add(record);
            }

            foreach (var color in allColors)
            {
                allColorsList.Add(color);
            }

            ViewBag.flowerCharacteristics = allCharacteristics;
            ViewBag.allColors = allColorsList;

            return View(myFlowers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}