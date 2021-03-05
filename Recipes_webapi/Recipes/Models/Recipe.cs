using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Serving { get; set; }
        public string Cuisine { get; set; }
        public string Preptime { get; set; }
        public string Tottime { get; set; }
        public string Ingradients { get; set; }
        public string Steps1 { get; set; }
        public string Steps2 { get; set; }
        public string Steps3 { get; set; }
        public string Steps4 { get; set; }
        public string Steps5 { get; set; }
        public string Steps6 { get; set; }
        public string Steps7 { get; set; }
        public string Steps8 { get; set; }
        public string Steps9 { get; set; }
        public string Photo { get; set; }
        public string PostedBy { get; set; }



    }
}