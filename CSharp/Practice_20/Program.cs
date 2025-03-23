namespace Practice_20;

class Program
{
    static void Main(string[] args)
    {
        int arrayLength = 30;
        int arrayMinValue = 0;
        int arrayMaxValue = 20;
        
        int[] array = new int[arrayLength];
        Random random = new Random();
        
        Console.WriteLine("Исходный массив:");
        
        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = random.Next(arrayMinValue, arrayMaxValue + 1);
            Console.Write($"{array[i]} ");
        }
        
        Console.WriteLine();
        Console.WriteLine();
        
        for (int i = 0; i < arrayLength; i++)
        {
            bool isGreaterThanPrev = i == 0 || array[i] > array[i - 1];
            bool isGreaterThanNext = i == arrayLength - 1 || array[i] > array[i + 1];
            
            if (isGreaterThanPrev == false || isGreaterThanNext == false)
                continue;
            
            Console.Write($"Найден локальный максимум под номером {i + 1} - ");
            
            if (i == 0)
                Console.WriteLine($"[{array[i]}] {array[i + 1]} ...");
            else if (i == arrayLength - 1)
                Console.WriteLine($"... {array[i - 1]} [{array[i]}]");
            else
                Console.WriteLine($"... {array[i - 1]} [{array[i]}] {array[i + 1]} ...");
        }
    }
}
