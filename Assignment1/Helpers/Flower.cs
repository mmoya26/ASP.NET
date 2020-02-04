using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Helpers
{
    public class Flower
    {
        public string name;
        public string color;
        public string[] descriptions;


        public Flower(string name, string color) {
            this.name = name;
            this.color = color;
        }

        public Flower(string name, string color, string[] descriptions)
        {
            this.name = name;
            this.color = color;
            this.descriptions = descriptions;
        }

        public string converFlowerNameToPath(string flowerName) {

            string newString = flowerName;
            newString.ToLower();
            newString.Replace(" ", "_");

            return newString;
        }
    }
}