namespace Practice_23;

class Program
{
    static void Main(string[] args)
    {
        int randValueMin = 1;
        int randValueMax = 100;
        
        int arrayLength = 30;
        int[] numbers = new int[arrayLength];
        Random random = new Random();
        
        for (int i = 0; i < arrayLength; i++)
            numbers[i] = random.Next(randValueMin, randValueMax + 1);
        
        Console.WriteLine($"Исходный массив:");
        
        foreach (int value in numbers)
            Console.Write($"{value} ");
        
        Console.WriteLine("\n");
        
        for (int i = 0; i < arrayLength - 1; i++)
        {
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (numbers[j] < numbers[i])
                    (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
        }
        
        Console.WriteLine($"Отсортированный массив:");
        
        foreach (int value in numbers)
            Console.Write($"{value} ");
        
        Console.WriteLine();
    }
}
