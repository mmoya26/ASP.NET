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
        public List <String> descriptions;


        public Flower(string name, string color) {
            this.name = name;
            this.color = color;
        }

        public Flower(string name, string color, List<String> descriptions)
        {
            this.name = name;
            this.color = color;
            this.descriptions = descriptions;
        }

        public string converFlowerNameToPath(string flowerName) {

            string newString = flowerName.ToLower();
            newString = newString.Replace(" ", "_");

            return newString;
        }
    }
}