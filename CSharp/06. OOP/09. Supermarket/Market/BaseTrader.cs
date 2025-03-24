namespace Practice_45.Market;

public class BaseTrader
{
    protected int Money;
    protected List<Product> Products;
    
    public BaseTrader(int money)
    {
        Money = money;
        Products = new List<Product>();
    }
    
    public int Balance => Money;
    public int ProductsCount => Products.Count;
    
    public Product GetProduct(int productIndex)
    {
        return Products[productIndex];
    }
}
