namespace Practice_45.Market;

public class BaseTrader
{
    protected int _money;
    protected List<Product> _products;
    
    public BaseTrader(int money)
    {
        _money = money;
        _products = new List<Product>();
    }
    
    public int Money => _money;
    public int ProductsCount => _products.Count;
    
    public Product GetProduct(int productIndex)
    {
        return _products[productIndex];
    }
}
