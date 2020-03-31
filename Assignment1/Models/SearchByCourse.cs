using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Models
{
    public class SearchByCourse
    {
        public string CourseSelected { get; set; }
        public IEnumerable<SelectListItem> AllCourseOptions { get; set; }
    }
}