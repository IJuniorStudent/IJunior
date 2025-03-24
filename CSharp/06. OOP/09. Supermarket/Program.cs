namespace Practice_45;

using Market;

class Program
{
    static void Main(string[] args)
    {
        Mall mall = InitMall();
        
        while (mall.HasCustomers)
        {
            Console.WriteLine($"Баланс магазина: {mall.Money}. Покупатели: {mall.CustomersCount}");
            
            if (mall.TryServeNextCustomer(out int customerSpentMoney))
                Console.WriteLine($"Покупатель совершил покупку и потратил денег: {customerSpentMoney}");
            else
                Console.WriteLine($"У покупателя оказалось недостаточно денег");
            
            Console.WriteLine();
        }
        
        Console.WriteLine($"Общий баланс магазина после обслуживания всех клиентов: {mall.Money}");
    }
    
    static Mall InitMall()
    {
        var mall = new Mall(0);
        
        Product apple = new Product("Яблоко", 100);
        Product banana = new Product("Банан", 200);
        Product orange = new Product("Апельсин", 400);
        Product pineapple = new Product("Ананас", 800);
        
        mall.AddProducts([apple, banana, orange, pineapple]);
        
        mall.AddCustomer(new Customer(0, [apple, banana]));
        mall.AddCustomer(new Customer(1000, [apple, banana, orange]));
        mall.AddCustomer(new Customer(1000, [orange, pineapple]));
        mall.AddCustomer(new Customer(1000, [banana, pineapple]));
        
        return mall;
    }
}
