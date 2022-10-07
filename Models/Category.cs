using Microsoft.Extensions.Hosting;

public class Category
{
    public int Id { get; set; }

    public string Titolo { get; set; }

    public List<Pizza> Pizze { get; set; }

    public Category()
    {
           
    }
}
