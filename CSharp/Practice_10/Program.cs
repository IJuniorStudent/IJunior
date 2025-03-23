namespace Practice_10;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumberGenerator = new Random();
        int number = randomNumberGenerator.Next(0, 101);
        int sum = 0;
 
        for (int i = 0; i <= number; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
                sum += i;
        }
        
        Console.WriteLine($"Случайное число: {number}");
        Console.WriteLine($"Сумма положительных чисел, кратных 3 или 5: {sum}");
    }
}
