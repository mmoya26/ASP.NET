using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class SearchByCourseController : Controller
    {
        private asp9Entities db = new asp9Entities();

        // GET: SearchByCourse
        public ActionResult Index()
        {
            SearchByCourse model = new SearchByCourse();

            var crs = db.FLOWERVIEWs.ToList().Select(s => new SelectListItem
            {
                Text = s.FLOWER_NAME,
                Value = s.COLOR_ID.ToString()
            });

            return PartialView("~/Views/Shared/_SearchFlowers.cshtml", new SearchByCourse {AllCourseOptions = crs});
        }
    }
}