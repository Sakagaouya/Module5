﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPPizza2_BO;

namespace TPPizza2.Models
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }

        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        public List<int> selectedIngredients { get; set; } = new List<int>();

        public int selectedPate { get; set; }
    }
}