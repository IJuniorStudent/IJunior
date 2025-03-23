namespace Practice_22;

class Program
{
    static void Main(string[] args)
    {
        int randValueMin = 1;
        int randValueMax = 5;
        
        int arrayLength = 30;
        int[] numbers = new int[arrayLength];
        Random random = new Random();
        
        for (int i = 0; i < arrayLength; i++)
            numbers[i] = random.Next(randValueMin, randValueMax + 1);
        
        Console.WriteLine($"Исходная последовательность чисел:");
        
        foreach (int value in numbers)
            Console.Write($"{value} ");
        
        Console.WriteLine("\n");
        
        int tempIndex = 0;
        int tempRepeatTimes = 1;
        
        int foundValueIndex = tempIndex;
        int foundValue = numbers[tempIndex];
        int foundValueRepeatTimes = tempRepeatTimes;
        
        for (int i = 1; i < arrayLength; i++)
        {
            if (numbers[i] != numbers[i - 1])
            {
                tempRepeatTimes = 1;
                tempIndex = i;
            }
            else
            {
                tempRepeatTimes++;
            }
            
            if (tempRepeatTimes > foundValueRepeatTimes)
            {
                foundValueRepeatTimes = tempRepeatTimes;
                foundValueIndex = tempIndex;
                foundValue = numbers[i - 1];
            }
        }
        
        Console.WriteLine($"Наиболее повторяемое число: {foundValue}");
        Console.WriteLine($"Длина последовательности: {foundValueRepeatTimes}");
        Console.WriteLine($"Номер элемента начала последовательности: {foundValueIndex + 1}");
    }
}
