namespace Practice_42;

class Program
{
    static void Main(string[] args)
    {
        const string CommandBuyProduct = "1";
        const string CommandShowCustomerProducts = "2";
        const string CommandExit = "3";
        
        int customerStartBalance = 1000;
        int sellerStartBalance = 0;
        
        Customer customer = new Customer(customerStartBalance);
        Seller seller = new Seller(sellerStartBalance);
        Mall mall = new Mall(customer, seller);
        
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine($"Баланс магазина: {seller.Balance}");
            Console.WriteLine();
            Console.WriteLine($"{CommandBuyProduct}. Купить продукты");
            Console.WriteLine($"{CommandShowCustomerProducts}. Показать товары в сумке");
            Console.WriteLine($"{CommandExit}. Выход");
            Console.WriteLine();
            
            string userInput = Utils.ReadUserInput("Выберите действие");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandBuyProduct:
                    mall.BuyProduct();
                    break;
                
                case CommandShowCustomerProducts:
                    mall.DisplayCustomerProducts();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
            }
        }
    }
}

class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
    
    public string Name { get; }
    public int Price { get; }
    
    public string Info => $"{Name} - цена: {Price}";
}

class MallPerson
{
    protected List<Product> Products;
    protected int Money;
    
    public MallPerson(int money)
    {
        Products = new List<Product>();
        Money = money;
    }
    
    public int Balance => Money;
    public int ProductsCount => Products.Count;
    
    public virtual void ShowProducts()
    {
        if (Products.Count == 0)
        {
            Console.WriteLine("Предметы в сумке отсутствуют");
            return;
        }
        
        Console.WriteLine("Предметы в сумке:");
        
        foreach (var product in Products)
            Console.WriteLine(product.Name);
    }
}

class Seller : MallPerson
{
    public Seller(int money) : base(money) { }
    
    public void AppendProduct(Product product)
    {
        Products.Add(product);
    }
    
    public Product GetProduct(int productIndex)
    {
        return Products[productIndex];
    }
    
    public Product Sell(int productIndex)
    {
        var product = Products[productIndex];
        Products.RemoveAt(productIndex);
        Money += product.Price;
        
        return product;
    }
    
    public override void ShowProducts()
    {
        if (Products.Count == 0)
        {
            Console.WriteLine("Товары на продажу отсутствуют");
            return;
        }
        
        Console.WriteLine("Товары на продажу:");
        
        for (int i = 0; i < Products.Count; i++)
            Console.WriteLine($"{i + 1}. {Products[i].Info}");
    }
}

class Customer : MallPerson
{
    public Customer(int money) : base(money) { }
    
    public bool CanBuyProduct(Product product)
    {
        return Money >= product.Price;
    }
    
    public void Buy(Product product)
    {
        Products.Add(product);
        Money -= product.Price;
    }
}

class Mall
{
    private Customer _customer;
    private Seller _seller;
    
    public Mall(Customer customer, Seller seller)
    {
        _customer = customer;
        _seller = seller;
        
        FillSellerProducts();
    }
    
    public void DisplaySellerProducts()
    {
        _seller.ShowProducts();
    }
    
    public void DisplayCustomerProducts()
    {
        _customer.ShowProducts();
        
        Utils.WaitAnyKeyPress();
    }
    
    public void BuyProduct()
    {
        if (_seller.ProductsCount == 0)
        {
            Utils.PrintWaitMessage("В магазине отсутствуют товары");
            return;
        }
        
        Console.WriteLine($"Ваш баланс: {_customer.Balance}");
        Console.WriteLine();
        
        DisplaySellerProducts();
        
        if (Utils.TryReadNumberInput("Введите номер товара для покупки", out int productNumber) == false)
            return;
        
        int productIndex = productNumber - 1;
        
        if (productIndex < 0 || productIndex >= _seller.ProductsCount)
        {
            Utils.PrintWaitMessage($"Товара с номером \"{productNumber}\" нет в списке");
            return;
        }
        
        if (_customer.CanBuyProduct(_seller.GetProduct(productIndex)) == false)
        {
            Utils.PrintWaitMessage("На вашем балансе недостаточно средств для покупки");
            return;
        }
        
        _customer.Buy(_seller.Sell(productIndex));
        
        Utils.PrintWaitMessage("Вы успешно купили товар");
    }
    
    private void FillSellerProducts()
    {
        Product[] productsToSell =
        [
            new ("Яблоко", 100),
            new ("Банан", 100),
            new ("Баклажан", 100),
            new ("Ананас", 400),
            new ("Перфоратор", 800)
        ];
        
        foreach (var product in productsToSell)
            _seller.AppendProduct(product);
    }
}

class Utils
{
    public static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    public static bool TryReadNumberInput(string promptMessage, out int number)
    {
        if (int.TryParse(ReadUserInput(promptMessage), out number) == false)
        {
            PrintWaitMessage("Ввведено некорректное число");
            return false;
        }
        
        return true;
    }
    
    public static void PrintWaitMessage(string message)
    {
        Console.WriteLine(message);
        
        WaitAnyKeyPress();
    }
    
    public static void WaitAnyKeyPress()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey(true);
    }
}
