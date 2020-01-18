using Lab7.Models;
using System.Collections.Generic;

namespace Lab7.Services
{
    public interface IPizzaService
    {
        List<Pizza> Get();
        int Post(Pizza pizza);
        bool Put(Pizza pizza, int Id);

        bool Delete(int Id);
    }
}