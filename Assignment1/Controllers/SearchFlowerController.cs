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
    }
}