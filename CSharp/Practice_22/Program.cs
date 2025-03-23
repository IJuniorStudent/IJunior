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
        int[] array = new int[arrayLength];
        Random random = new Random();
        
        for (int i = 0; i < arrayLength; i++)
        {
            int randomNumber = random.Next(randValueMin, randValueMax + 1);
            int valueRepeatCount = random.Next(valueRepeatTimesMin, valueRepeatTimesMax + 1);
            valueRepeatCount = Math.Min(valueRepeatCount, arrayLength - i);
            
            for (int j = i; j < i + valueRepeatCount; j++)
                array[j] = randomNumber;
            
            i += valueRepeatCount - 1;
        }
        
        Console.WriteLine($"Исходная последовательность чисел:");
        
        foreach (int value in array)
            Console.Write($"{value} ");
        
        Console.WriteLine("\n");
        
        int watchValueIndex = 0;
        int watchValue = array[watchValueIndex];
        int watchValueRepeatTimes = 1;
        
        int foundValueIndex = watchValueIndex;
        int foundValue = watchValue;
        int foundValueRepeatTimes = watchValueRepeatTimes;
        
        for (int i = 1; i < arrayLength; i++)
        {
            if (array[i] != watchValue)
            {
                if (watchValueRepeatTimes > foundValueRepeatTimes)
                {
                    foundValueRepeatTimes = watchValueRepeatTimes;
                    foundValue = watchValue;
                    foundValueIndex = watchValueIndex;
                }
                watchValueRepeatTimes = 1;
                watchValueIndex = i;
                watchValue = array[i];
            }
            else
            {
                watchValueRepeatTimes++;
            }
        }
        
        if (watchValueRepeatTimes > foundValueRepeatTimes)
        {
            foundValueRepeatTimes = watchValueRepeatTimes;
            foundValue = watchValue;
            foundValueIndex = watchValueIndex;
        }
        
        Console.WriteLine($"Наиболее повторяемое число: {foundValue}");
        Console.WriteLine($"Длина последовательности: {foundValueRepeatTimes}");
        Console.WriteLine($"Номер элемента начала последовательности: {foundValueIndex + 1}");
    }
}
