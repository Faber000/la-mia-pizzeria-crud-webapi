using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                IQueryable<Pizza> pizzas = context.Pizze;

                return View("Index", pizzas.ToList());
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using(Pizzeria context = new Pizzeria())
            {
                Pizza pizzaFound = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                return View(pizzaFound);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (Pizzeria context = new Pizzeria())
            {
                Pizza pizzaFound = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                return View(pizzaFound);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }
            
            using (Pizzeria context = new Pizzeria())
            {
                Pizza newPizza = new Pizza();
                newPizza.Nome = formData.Nome;
                newPizza.Descrizione = formData.Descrizione;
                newPizza.Immagine = formData.Immagine;
                newPizza.Prezzo = formData.Prezzo;

                context.Pizze.Add(newPizza);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formData);
            }

            Pizzeria context = new Pizzeria();
            
            Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
            pizza.Nome = formData.Nome;
            pizza.Descrizione = formData.Descrizione;
            pizza.Immagine = formData.Immagine;
            pizza.Prezzo = formData.Prezzo;

            context.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Pizzeria context = new Pizzeria();

            Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
            
            context.Pizze.Remove(pizza);

            context.SaveChanges();
            return RedirectToAction("Index");

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