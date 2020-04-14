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

        [HttpPost]
        public ActionResult Index(SearchFlower flowerResultsSearch)
        {
            // User selections
            string uFlowerColorID = flowerResultsSearch.FlowerColorSelected;
            string uFlowerSize = flowerResultsSearch.FlowerSizeSelected;
            string uStartingPrice = flowerResultsSearch.FlowerStartPriceSelected;
            string uEndingPrice = flowerResultsSearch.FlowerEndPriceSelected;
            string uFlowerSearchName = flowerResultsSearch.FlowerNameSearched;
            bool valid = false;

            // Database info
            var allFlowers = db.FLOWERs.ToList();
            var characteristics = db.FLOWERVIEWs.ToList();
            var allColors = db.COLORs.ToList();

            // Data Collection
            List<FLOWER> resultsFlowers = new List<FLOWER>();
            List<FLOWERVIEW> allCharacteristics = new List<FLOWERVIEW>();
            List<COLOR> allColorsList = new List<COLOR>();


            if (uFlowerColorID != null || uFlowerSize != null || uEndingPrice != null || uStartingPrice != null)
            {
                // If ending price is lower than starting price then invalid
                if (uStartingPrice != null &&  uEndingPrice != null && Int32.Parse(uEndingPrice) < Int32.Parse(uStartingPrice))
                {
                    // Don't do anything for now
                }
                else
                {
                    valid = true;
                }
            }
            else if (uFlowerColorID == null && uFlowerSize == null && uEndingPrice == null && uStartingPrice == null && uFlowerSearchName != null)
            {
                valid = true;
            }


            if (valid)
            {
                // Only name
                if (uFlowerSize == null && uFlowerColorID == null && uEndingPrice == null && uStartingPrice == null &&
                    uFlowerSearchName != null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        if (flower.FLOWER_NAME.StartsWith(uFlowerSearchName.ToLower()))
                        {
                            resultsFlowers.Add(flower);
                        }
                    }
                }

                // Only color
                if (uEndingPrice == null & uStartingPrice == null && uFlowerSize == null && uFlowerColorID != null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        if (flower.COLOR_ID.ToString() == uFlowerColorID)
                        {
                            resultsFlowers.Add(flower);
                        }
                    }
                }

                // Only size picked
                if (uFlowerColorID == null && uEndingPrice == null & uStartingPrice == null && uFlowerSize != null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        if (flower.FLOWER_SIZE.ToLower() == uFlowerSize)
                        {
                            resultsFlowers.Add(flower);
                        }
                    }
                }

                // Size and color were only picked
                if (uFlowerColorID != null && uFlowerSize != null && uEndingPrice == null && uStartingPrice == null && uFlowerSearchName == null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        if (flower.FLOWER_SIZE.ToLower() == uFlowerSize)
                        {
                            if (flower.COLOR_ID.ToString() == uFlowerColorID)
                            {
                                resultsFlowers.Add(flower);
                            }
                        }
                    }
                }

                // Starting or Ending price were only picked or both of them were picked
                if (uEndingPrice != null || uStartingPrice != null)
                {
                    resultsFlowers.Clear();

                    // Only ending
                    if (uEndingPrice != null && uStartingPrice == null)
                    {
                        foreach (var flower in allFlowers)
                        {
                            if (flower.FLOWER_PRICE <= Int32.Parse(uEndingPrice))
                            {
                                resultsFlowers.Add(flower);
                            }
                        }

                    }
                    else if (uEndingPrice == null && uStartingPrice != null) // only starting
                    {
                        foreach (var flower in allFlowers)
                        {
                            if (flower.FLOWER_PRICE >= Int32.Parse(uStartingPrice))
                            {
                                resultsFlowers.Add(flower);
                            }
                        }
                    }
                    else
                    {
                        foreach (var flower in allFlowers)
                        {
                            if (flower.FLOWER_PRICE >= Int32.Parse(uStartingPrice) && flower.FLOWER_PRICE <= Int32.Parse(uEndingPrice))
                            {
                                resultsFlowers.Add(flower);
                            }
                        }
                    }

                }

                // All filled (no name)
                if (uStartingPrice != null && uEndingPrice != null && uFlowerColorID != null && uFlowerSize != null && uFlowerSearchName == null)
                {
                    resultsFlowers.Clear();

                    foreach (var flower in allFlowers)
                    {
                        // Color check
                        if (flower.COLOR_ID.ToString() == uFlowerColorID)
                        {
                            // Size check
                            if (flower.FLOWER_SIZE.ToLower() == uFlowerSize)
                            {
                                // Price range check
                                if (flower.FLOWER_PRICE >= Int32.Parse(uStartingPrice) && flower.FLOWER_PRICE <= Int32.Parse(uEndingPrice))
                                {
                                    resultsFlowers.Add(flower);
                                }
                            }
                        }
                    }
                }

                // All filled except Size (with name)
                if (uStartingPrice != null && uEndingPrice != null && uFlowerColorID != null && uFlowerSize != null && uFlowerSearchName != null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        if (flower.FLOWER_NAME.StartsWith(uFlowerSearchName.ToLower()))
                        {
                            // Size check
                            if (flower.FLOWER_SIZE.ToLower() == uFlowerSize)
                            {
                                if (flower.COLOR_ID.ToString() == uFlowerColorID)
                                {
                                    // Price range check
                                    if (flower.FLOWER_PRICE >= Int32.Parse(uStartingPrice) && flower.FLOWER_PRICE <= Int32.Parse(uEndingPrice))
                                    {
                                        resultsFlowers.Add(flower);
                                    }
                                }
                            }
                        }
                    }
                }

                // All filled except for ending price
                if (uStartingPrice != null && uEndingPrice == null && uFlowerColorID != null && uFlowerSize != null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        // Color check
                        if (flower.COLOR_ID.ToString() == uFlowerColorID)
                        {
                            // Size check
                            if (flower.FLOWER_SIZE.ToLower() == uFlowerSize)
                            {
                                // Price range check
                                if (flower.FLOWER_PRICE >= Int32.Parse(uStartingPrice))
                                {
                                    resultsFlowers.Add(flower);
                                }
                            }
                        }
                    }
                }

                // All filled except Size (no name)
                if (uStartingPrice != null && uEndingPrice != null && uFlowerColorID != null && uFlowerSize == null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        // Color check
                        if (flower.COLOR_ID.ToString() == uFlowerColorID)
                        {
                            // Price range check
                            if (flower.FLOWER_PRICE >= Int32.Parse(uStartingPrice) && flower.FLOWER_PRICE <= Int32.Parse(uEndingPrice))
                            {
                                resultsFlowers.Add(flower);
                            }
                        }
                    }
                }

                // All filled except for starting price
                if (uStartingPrice == null && uEndingPrice != null && uFlowerColorID != null && uFlowerSize != null)
                {
                    resultsFlowers.Clear();
                    foreach (var flower in allFlowers)
                    {
                        // Color check
                        if (flower.COLOR_ID.ToString() == uFlowerColorID)
                        {
                            // Size check
                            if (flower.FLOWER_SIZE.ToLower() == uFlowerSize)
                            {
                                // Price range check
                                if (flower.FLOWER_PRICE <= Int32.Parse(uEndingPrice))
                                {
                                    resultsFlowers.Add(flower);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var flower in allFlowers)
                {
                    // If flower color == 1 (Blue)
                    if (flower.COLOR_ID == 1)
                    {
                        // Add the flower to the list
                        resultsFlowers.Add(flower);
                    }
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

            return View(resultsFlowers);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Legal()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(Register model)
        {
            return Json(model);
        }
    }
}