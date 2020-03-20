using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_2_BO;

namespace TPPizza2.Utils
{
    public class FakeDbPizza
    {
        private static FakeDbPizza _instance;
        static readonly object instanceLock = new object();

        private FakeDbPizza()
        {
            // Charger d'abord les ingredients et les pates
            ingredientsDisponibles = this.GetIngredientsDispo();
            patesDisponibles = this.GetPatesDisponibles();
            pizzas = this.GetCarteDesPizzas();

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

        //les attributs sont tous read-only
        private List<Pizza> pizzas;
        private List<Ingredient> ingredientsDisponibles;
        private List<Pate> patesDisponibles;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }

        public List<Ingredient> IngredientsDisponibles
        {
            get { return ingredientsDisponibles; }
        }

        public List<Pate> PatesDisponibles
        {
            get { return patesDisponibles; }
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