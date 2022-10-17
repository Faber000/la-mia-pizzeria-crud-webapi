using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            return Ok(pizze.ToList<Pizza>());
        }
    }
}
