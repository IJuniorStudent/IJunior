namespace Practice_45.Market;

public class Mall : BaseTrader
{
    private Queue<Customer> _customers;
    
    public Mall(int money) : base(money)
    {
        _customers = new Queue<Customer>();
    }
    
    public int CustomersCount => _customers.Count;
    public bool HasCustomers => CustomersCount > 0;
    
    public void AddCustomer(Customer customer)
    {
        _customers.Enqueue(customer);
    }
    
    public void AddProducts(IEnumerable<Product> products)
    {
        _products.AddRange(products);
    }
    
    public bool TryServeNextCustomer(out int customerSpentMoney)
    {
        Customer customer = _customers.Dequeue();
        customerSpentMoney = 0;
        
        if (customer.HasEnoughMoney == false)
            customer.FitBasketPriceToMoney();
        
        int customerBasketPrice = customer.TotalBasketPrice;
        
        if (customerBasketPrice == 0)
            return false;
        
        _money += customerBasketPrice;
        customer.BuyTakenProducts();
        customerSpentMoney = customerBasketPrice;
        
        return true;
    }
}