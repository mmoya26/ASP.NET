﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Helpers;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {

        List<Flower> flowerList = new List<Flower>();
        Flower firstFlower = new Flower("Aster Novae Angliae", "pink", new List<String> { "Bright Colors", "Strong Living", "Made for Inside" });
        Flower secondFlower = new Flower("Aster Pantens", "blue", new List<String> { "Bright Colors", "Strong Living", "Made for Inside" });
        Flower thirdFlower = new Flower("Centaurea Cyanus Peg", "blue", new List <String> { "Bright Colors", "Strong Living", "Made for Inside" });

        public ActionResult Index()
        {
            flowerList.Add(firstFlower);
            flowerList.Add(secondFlower);
            flowerList.Add(thirdFlower);

            ViewBag.flowerList = flowerList;
            ViewBag.flowerCount = flowerList.Count();
            

            return View();
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