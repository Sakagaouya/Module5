
using TPModule5_2_BO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TPPizza2.Utils;
using TPPizza2.Models;

namespace TP_pizzas.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDbPizza.Instance.Pizzas);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM vm = new PizzaVM();

            vm.Pates = FakeDbPizza.Instance.PatesDisponibles.Select(
                pat => new SelectListItem { Text = pat.Nom, Value = pat.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles.Select(
                i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() })
                .ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM vm)
        {
            try
            {
                Pizza pizza = vm.Pizza;

                pizza.Pate = FakeDbPizza.Instance.PatesDisponibles.FirstOrDefault(pat => pat.Id == vm.selectedPate);

                pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles.Where(
                    i => vm.selectedIngredients.Contains(i.Id))
                    .ToList();

                // on affecte l'Id id Max +1.
                // si la liste est vide, on affecte la valeur 1.
                pizza.Id = FakeDbPizza.Instance.Pizzas.Any() ? FakeDbPizza.Instance.Pizzas.Max(p => p.Id) + 1 : 1;

                FakeDbPizza.Instance.Pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaVM vm = new PizzaVM();

            // On créé directement l'objet attendu par la méthode DropDownListFor du HtmlHelper, qui nous permettra de choisir une pâte
            vm.Pates = FakeDbPizza.Instance.PatesDisponibles.Select(
                pat => new SelectListItem { Text = pat.Nom, Value = pat.Id.ToString() })
                .ToList();

            // On créé directement l'objet attendu par la méthode ListBoxFor du HtmlHelper, qui nous permettra de choisir plusieurs ingrédients
            vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles.Select(
                i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() })
                .ToList();

            // On récupère la pizza portant l'Id désiré dans la liste des pizzas portée par le controller
            vm.Pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);

            // Si la pizza avait déja une pâte, elle sera selectionnée sur la vue

            if (vm.Pizza.Pate != null)
            {
                vm.selectedPate = vm.Pizza.Pate.Id;
            }

            // On présélectionne les ingrédients si la pizza en contient
            if (vm.Pizza.Ingredients.Any())
            {
                vm.selectedIngredients = vm.Pizza.Ingredients.Select(i => i.Id).ToList();
            }


            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaVM vm)
        {
            try
            {
                Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDbPizza.Instance.PatesDisponibles.FirstOrDefault(p => p.Id == vm.selectedPate);
                pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles.Where(p => vm.selectedIngredients.Contains(p.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id));
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
                FakeDbPizza.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
