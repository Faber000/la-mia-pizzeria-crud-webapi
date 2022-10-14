using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        Pizzeria context;

        public PizzaController()
        {
            context = new Pizzeria();
        }
        public IActionResult Get()
        {
            List<Pizza> pizze = context.Pizze.ToList();

            return Ok(pizze);
        }
    }
}
