namespace Practice_10;

class Program
{
    static void Main(string[] args)
    {
        int firstFactor = 3;
        int secondFactor = 5;
        int maxRandomNumber = 100;
        
        Random random = new Random();
        int number = random.Next(0, maxRandomNumber + 1);
        int sum = 0;
        
        for (int i = 0; i <= number; i++)
        {
            if (i % firstFactor == 0 || i % secondFactor == 0)
                sum += i;
        }
        
        Console.WriteLine($"Случайное число: {number}");
        Console.WriteLine($"Сумма положительных чисел, кратных 3 или 5: {sum}");
    }
}
