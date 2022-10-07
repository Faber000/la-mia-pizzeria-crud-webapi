using Microsoft.Extensions.Hosting;

public class PizzaCategories
{
    public Pizza Pizza { get; set; }

    public List<Category> Categories { get; set; }

    public PizzaCategories()
    {
        Pizza = new Pizza();
        Categories = new List<Category>();
    }
}
