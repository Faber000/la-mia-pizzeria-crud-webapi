using la_mia_pizzeria_crud_mvc.Models;
using MessagePack;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        [HttpPost]
        public IActionResult Send([FromBody] Message message)
        {

            Pizzeria ctx = new Pizzeria();

            ctx.Messages.Add(message);
            ctx.SaveChanges();

            return Ok();
        }
    }
}
