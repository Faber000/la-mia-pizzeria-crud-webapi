using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (Pizzeria context = new Pizzeria())
            {

                List<Pizza> pizze = context.Pizze.ToList();

                return View("Index", pizze);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (Pizzeria context = new Pizzeria())
            {

                Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();

                return View("Details", pizza);
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}