using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_1.Models;
using TPModule5_2_BO;

namespace TPModule5_1.Utils
{
    public class FakeDbPizza
    {
        private static FakeDbPizza _instance;
        static readonly object instanceLock = new object();

        private FakeDbPizza()
        {
            pizzas = this.GetCarteDesPizzas();
            IngredientsDisponibles = this.GetIngredientsDispo();
            PatesDisponibles = this.GetPatesDisponibles();

        }

        public static FakeDbPizza Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDbPizza();
                    }
                }
                return _instance;
            }
        }

        private List<Pizza> pizzas;
        private List<Ingredient> IngredientsDisponibles;
        private List<Pate> PatesDisponibles;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }
        
        private List<Pizza> GetCarteDesPizzas()
        {
            
            return new List<Pizza>
            {
                new Pizza{
                    Id=1,
                    Nom = "Norvegienne",
                    Pate= PatesDisponibles.FirstOrDefault(p => p.Id == 1),
                    Ingredients= new List<Ingredient>{
                        IngredientsDisponibles.FirstOrDefault(i=> i.Id== 1),
                        IngredientsDisponibles.FirstOrDefault(i => i.Id == 6),
                        IngredientsDisponibles.FirstOrDefault(i => i.Id == 7)
                    }
                },
                 new Pizza{
                    Id=2,
                    Nom = "Margherita",
                    Pate= PatesDisponibles.FirstOrDefault(p => p.Id == 2),
                    Ingredients= new List<Ingredient>{
                        IngredientsDisponibles.FirstOrDefault(i=> i.Id== 1),
                        IngredientsDisponibles.FirstOrDefault(i => i.Id == 3)
                    }
                }
            };
        }

        private List<Ingredient> GetIngredientsDispo()
        {
            return new List<Ingredient>
        {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
        };
        }

        private List<Pate> GetPatesDisponibles()
        {
            return new List<Pate>
        {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
        };
        }
    }


}