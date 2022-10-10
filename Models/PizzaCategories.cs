using Microsoft.Extensions.Hosting;

public class PizzaCategories
{
    public Pizza Pizza { get; set; }

    public List<Category> Categories { get; set; }
    public List<int> SelectedIngredients { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public PizzaCategories()
    {
        Pizza = new Pizza();
        Categories = new List<Category>();
        Ingredients = new List<Ingredient>();
        SelectedIngredients = new List<int>();
    }
}
