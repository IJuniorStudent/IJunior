namespace Practice_45.Market;

public class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
    
    public string Name { get; }
    public int Price { get; }
    
    public Product MakeCopy()
    {
        return new Product(Name, Price);
    }
}
