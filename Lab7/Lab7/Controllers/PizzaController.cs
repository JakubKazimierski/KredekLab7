using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab7.Models;
using Lab7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    [Route("api/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IPizzaService pizzaService;

        /// <summary>
        /// constructor
        /// </summary>
        public PizzaController(IPizzaService _pizzaService)
        {
            pizzaService = _pizzaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pizzas = pizzaService.Get();

            return Ok(pizzas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pizza pizza)
        {
            var id = pizzaService.Post(pizza);
            return Ok(id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromBody] Pizza pizza, [FromRoute] int id)
        {
            if(id != pizza.Id)
            {
                return Conflict("Nie można edytowac id!");

            }
            else
            {
                var isUpdateSuccessful = pizzaService.Put(pizza, id);
                if(isUpdateSuccessful)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
        }
        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            bool isDeleteSuccessful = pizzaService.Delete(id);
            if(isDeleteSuccessful)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

    }
}