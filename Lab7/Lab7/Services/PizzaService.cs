using Lab7.Controllers;
using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Services
{
    public class PizzaService : IPizzaService
    {
        private static List<Pizza> pizzas = new List<Pizza>();

        public List<Pizza> Get()
        {
            return pizzas;
        }

        public int Post(Pizza pizza)
        {
            int id;
            if (pizzas.Count() == 0)
            {
                id = 0;
                pizza.Id = id;
            }
            else
            {
                id = pizzas.Max(x => x.Id);
                pizza.Id = ++id;
            }
            pizzas.Add(pizza);
            return id;
        }

        public bool Put(Pizza pizza, int Id)
        {
            var pizzaToUpdate = pizzas.Where(x => x.Id.Equals(Id)).SingleOrDefault();
            if (pizzaToUpdate == null)
            {
                return false;
            }
            pizzaToUpdate.Name = pizza.Name;
            pizzaToUpdate.Description = pizza.Description;
            pizzaToUpdate.Cost = pizza.Cost;

            return true;
        }

        public bool Delete(int Id)
        {
            var pizzaToDelete = pizzas.Where(x => x.Id.Equals(Id)).SingleOrDefault();
            if (pizzaToDelete == null)
            {
                return false;
            }

            pizzas.Remove(pizzaToDelete);
            return true;
        }


    }
}
