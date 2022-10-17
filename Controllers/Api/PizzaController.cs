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
    }
}
