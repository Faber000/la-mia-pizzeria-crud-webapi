using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace la_mia_pizzeria_model.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
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

                Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).Include("Category").FirstOrDefault();

                return View("Details", pizza);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            PizzaCategories pizzaCategories = new PizzaCategories();

            pizzaCategories.Categories = new Pizzeria().Categories.ToList();

            return View(pizzaCategories);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (Pizzeria context = new Pizzeria())
            {
                Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                PizzaCategories pizzaCategories = new PizzaCategories();

                pizzaCategories.Pizza = pizza; 

                pizzaCategories.Categories = context.Categories.ToList(); 

                return View(pizzaCategories);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategories formData)
        {
            Pizzeria context = new Pizzeria();

            if (!ModelState.IsValid)
            {
                formData.Categories = context.Categories.ToList();
                return View("Create", formData);
            }

            context.Pizze.Add(formData.Pizza);

            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaCategories formData)
        {
            using (Pizzeria context = new Pizzeria())
            {
                if (!ModelState.IsValid)
                {
                    formData.Categories = context.Categories.ToList();
                    return View("Update", formData);
                }

                formData.Pizza.Id = id;

                context.Pizze.Update(formData.Pizza);

                context.SaveChanges();

                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (Pizzeria context = new Pizzeria())
            {
                Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                context.Pizze.Remove(pizza);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
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