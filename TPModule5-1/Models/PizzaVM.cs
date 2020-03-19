using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_2_BO;

namespace TP_pizzas.Models
{
    public class PizzaVM
    {
        public Pizza pizza { get; set; }

        public List<Ingredient> ingredients = new List<Ingredient>();

        public List<Pate> pates = new List<Pate>();

        public List<int> selectedIngredients { get; set; } = new List<int>();

        public int selectedPate { get; set; }
    }
}