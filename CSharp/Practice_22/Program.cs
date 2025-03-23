namespace Practice_22;

class Program
{
    static void Main(string[] args)
    {
        int randValueMin = 1;
        int randValueMax = 9;
        
        int valueRepeatTimesMin = 1;
        int valueRepeatTimesMax = 10;
        
        int arrayLength = 30;
        int[] randomSequence = new int[arrayLength];
        Random random = new Random();
        
        for (int i = 0; i < arrayLength; i++)
        {
            int repeatNumber = random.Next(randValueMin, randValueMax + 1);
            int maxRepeatCount = random.Next(valueRepeatTimesMin, valueRepeatTimesMax + 1);
            maxRepeatCount = Math.Min(maxRepeatCount, arrayLength - i);
            
            for (int j = i; j < i + maxRepeatCount; j++)
                randomSequence[j] = repeatNumber;
            
            i += maxRepeatCount - 1;
        }
        
        Console.WriteLine($"Исходная последовательность чисел:");
        
        foreach (int value in randomSequence)
            Console.Write($"{value} ");
        
        Console.WriteLine("\n");
        
        int watchValueIndex = 0;
        int watchValue = randomSequence[watchValueIndex];
        int watchValueRepeatTimes = 1;
        
        int foundValueIndex = watchValueIndex;
        int foundValue = watchValue;
        int foundValueRepeatTimes = watchValueRepeatTimes;
        
        for (int i = 1; i < arrayLength; i++)
        {
            if (randomSequence[i] != watchValue)
            {
                watchValueRepeatTimes = 1;
                watchValueIndex = i;
                watchValue = randomSequence[i];
            }
            else
            {
                watchValueRepeatTimes++;
            }
            
            if (watchValueRepeatTimes > foundValueRepeatTimes)
            {
                foundValueRepeatTimes = watchValueRepeatTimes;
                foundValue = watchValue;
                foundValueIndex = watchValueIndex;
            }
        }
        
        Console.WriteLine($"Наиболее повторяемое число: {foundValue}");
        Console.WriteLine($"Длина последовательности: {foundValueRepeatTimes}");
        Console.WriteLine($"Номер элемента начала последовательности: {foundValueIndex + 1}");
    }
}
