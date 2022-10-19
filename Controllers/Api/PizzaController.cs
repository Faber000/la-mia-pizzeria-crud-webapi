using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Policy;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        Pizzeria context;

        public PizzaController()
        {
            context = new Pizzeria();
        }

        [HttpGet]
        public IActionResult Get(string? title)
        {
            IQueryable<Pizza> pizze;

            if (title != null)
            {
                pizze = context.Pizze.Where(pizza => pizza.Nome.ToLower().Contains(title.ToLower()));
                
            }

            else
            {
                pizze = context.Pizze;
            }

            return Ok(pizze);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (Pizzeria context = new Pizzeria())
            {
                Pizza pizzaToRemove = context.Pizze.Where(p => p.Id == id).FirstOrDefault();

                if(pizzaToRemove != null)
                {
                    context.Pizze.Remove(pizzaToRemove);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            using (Pizzeria context = new Pizzeria())
            {
                Pizza pizzaDaModificare = context.Pizze
                .Where(p=> p.Id == id).FirstOrDefault();

                if (pizzaDaModificare != null)
                {
                    pizzaDaModificare.Nome = pizza.Nome;
                    pizzaDaModificare.Descrizione = pizza.Descrizione;
                    pizzaDaModificare.Immagine = pizza.Immagine;
                    pizzaDaModificare.Prezzo = pizza.Prezzo;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
