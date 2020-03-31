using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Models
{
    public class SearchFlower
    {
        public string FlowerColorSelected { get; set; }
        public string FlowerSizeSelected { get; set; }
        public string FlowerStartPriceSelected { get; set; }
        public string FlowerEndPriceSelected { get; set; }
        public string FlowerNameSearched { get; set; }
        public IEnumerable<SelectListItem> AllFlowerColors { get; set;}
    }
}