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
    public bool HasEnoughMoney => Money >= TotalBasketPrice;
    
    public void Take(IEnumerable<Product> products)
    {
        foreach (var product in products)
            AddToBasket(product);
    }
    
    public void BuyTakenProducts()
    {
        if (HasEnoughMoney == false)
            throw new InvalidOperationException("You cannot spend more money than you have");
        
        foreach (var product in Products)
            _bag.Add(product);
        
        Money -= _totalBasketPrice;
        
        Products.Clear();
        _totalBasketPrice = 0;
    }
    
    public void FitBasketPriceToMoney()
    {
        while (HasEnoughMoney == false && Products.Count > 0)
        {
            int randomProductIndex = Utils.GetRandomNumber(Products.Count);
            _totalBasketPrice -= Products[randomProductIndex].Price;
            
            Products.RemoveAt(randomProductIndex);
        }
    }
    
    private void AddToBasket(Product product)
    {
        Products.Add(product.MakeCopy());
        _totalBasketPrice += product.Price;
    }
}
