using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class SearchFlowerController : Controller
    {
        private asp9Entities db = new asp9Entities();

        // GET: SearchFlower
        public ActionResult Index()
        {
            SearchFlower model = new SearchFlower();

            model.AllFlowerColors = db.COLORs.ToList().Select(s => new SelectListItem
                {
                    Text = s.COLOR_NAME,
                    Value = s.COLOR_ID.ToString()
                }
            );

            return PartialView("~/Views/Shared/_SearchFormIndex.cshtml", model);

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

            if (uFlowerColorID != null || uFlowerSize != null || uEndingPrice != null || uStartingPrice != null)
            {
                // If ending price is lower than starting price then invalid
                if (uStartingPrice != null && uEndingPrice != null && Int32.Parse(uEndingPrice) < Int32.Parse(uStartingPrice))
                {
                    ModelState.AddModelError("", "Please Check Price Range Criteria");
                }
            }
            // All selectios == null
            else if (uFlowerColorID == null && uFlowerSize == null && uEndingPrice == null && uStartingPrice == null && uFlowerSearchName == null)
            {
                ModelState.AddModelError("", "Please Check Filter Criteria");
            }


            flowerResultsSearch.AllFlowerColors = db.COLORs.ToList().Select(s => new SelectListItem
                {
                    Text = s.COLOR_NAME,
                    Value = s.COLOR_ID.ToString()
                }
            );

            return PartialView("~/Views/Shared/_SearchFormIndex.cshtml", flowerResultsSearch);
        }
    }
}