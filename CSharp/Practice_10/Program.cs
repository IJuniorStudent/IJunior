namespace Practice_10;

class Program
{
    static void Main(string[] args)
    {
        int maxRandomNumber = 100;
        
        Random random = new Random();
        int number = random.Next(0, maxRandomNumber + 1);
        int sum = 0;
        
        for (int i = 0; i <= number; i++)
        {
            bool isCounterFactorOf3 = i % 3 == 0;
            bool isCounterFactorOf5 = i % 5 == 0;
            
            if (isCounterFactorOf3 || isCounterFactorOf5)
                sum += i;
        }
        
        Console.WriteLine($"Случайное число: {number}");
        Console.WriteLine($"Сумма положительных чисел, кратных 3 или 5: {sum}");
    }
}
