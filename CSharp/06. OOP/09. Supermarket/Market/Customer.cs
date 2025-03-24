namespace Practice_45.Market;

using Practice_45;

public class Customer : BaseTrader
{
    private List<Product> _bag;
    private int _totalBasketPrice;
    
    public Customer(int money, IEnumerable<Product> products) : base(money)
    {
        _bag = new List<Product>();
        _totalBasketPrice = 0;
        
        Take(products);
    }
    
    public int TotalBasketPrice => _totalBasketPrice;
    public bool HasEnoughMoney => _money >= TotalBasketPrice;
    
    public void Take(Product product)
    {
        _products.Add(product);
        _totalBasketPrice += product.Price;
    }

    public void Take(IEnumerable<Product> products)
    {
        foreach (var product in products)
            Take(product);
    }
    
    public void BuyTakenProducts()
    {
        if (HasEnoughMoney == false)
            throw new InvalidOperationException("You cannot spend more money than you have");
        
        foreach (var product in _products)
            _bag.Add(product.MakeCopy());
        
        _money -= _totalBasketPrice;
        
        _products.Clear();
        _totalBasketPrice = 0;
    }
    
    public void FitBasketPriceToMoney()
    {
        while (HasEnoughMoney == false && _products.Count > 0)
        {
            int randomProductIndex = Utils.GetRandomNumber(_products.Count);
            _totalBasketPrice -= _products[randomProductIndex].Price;
            
            _products.RemoveAt(randomProductIndex);
        }
    }
}
