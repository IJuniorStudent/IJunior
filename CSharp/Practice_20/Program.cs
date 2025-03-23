namespace Practice_20;

class Program
{
    static void Main(string[] args)
    {
        int arrayLength = 30;
        int arrayMinValue = 0;
        int arrayMaxValue = 20;
 
        int firstElementIndex = 0;
        int lastElementIndex = arrayLength - 1;
        
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
        
        if (array[firstElementIndex] > array[firstElementIndex + 1])
            Console.WriteLine($"Найден локальный максимум под номером {firstElementIndex + 1} - [{array[firstElementIndex]}] {array[firstElementIndex + 1]} ...");
            
        for (int i = 1; i < arrayLength - 1; i++)
        {
            if (array[i] > array[i - 1] && array[i] > array[i + 1])
                Console.WriteLine($"Найден локальный максимум под номером {i + 1} - ... {array[i - 1]} [{array[i]}] {array[i + 1]} ...");
        }
        
        if (array[lastElementIndex] > array[lastElementIndex - 1])
            Console.WriteLine($"Найден локальный максимум под номером {lastElementIndex + 1} - ... {array[lastElementIndex - 1]} [{array[lastElementIndex]}]");
    }
}
