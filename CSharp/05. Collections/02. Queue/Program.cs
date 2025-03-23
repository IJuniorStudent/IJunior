namespace Practice_33;

class Program
{
    static void Main(string[] args)
    {
        int customersCount = 10;
        int customerBasketPriceMin = 500;
        int customerBasketPriceMax = 900;
        
        int storeMoneySum = 0;
        Queue<int> customerBasketPrices = new Queue<int>();
        Random random = new Random();
        
        for (int i = 0; i < customersCount; i++)
            customerBasketPrices.Enqueue(random.Next(customerBasketPriceMin, customerBasketPriceMax + 1));
        
        while (customerBasketPrices.Count > 0)
        {   
            Console.WriteLine($"Сумма денег в кассе магазина: {storeMoneySum}");
            Console.WriteLine($"Количество клиентов к обслуживанию: {customerBasketPrices.Count}");
            Console.Write("Суммы корзин покупателей: ");
            
            foreach (var basketSum in customerBasketPrices)
                Console.Write($"{basketSum} ");
            
            Console.WriteLine();
            Console.WriteLine($"Для обслуживания клиента на сумму {customerBasketPrices.Peek()} нажмите любую клавишу");
            Console.ReadKey();
            
            storeMoneySum += customerBasketPrices.Dequeue();
            
            Console.Clear();
        }
        
        Console.WriteLine($"Все клиенты обслужены! Выручка магазина: {storeMoneySum}");
    }
}
