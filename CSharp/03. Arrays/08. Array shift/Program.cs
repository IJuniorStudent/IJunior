namespace Practice_25;

class Program
{
    static void Main(string[] args)
    {
        int arrayLength = 20;
        int[] numbers = new int[arrayLength];
        
        Console.WriteLine("Массив с исходными данными:");
        
        for (int i = 0; i < arrayLength; i++)
        {
            numbers[i] = i + 1;
            Console.Write($"{numbers[i]} ");
        }
        
        Console.WriteLine("\n");
        Console.Write("Введите количество сдвигов массива влево: ");
        
        int shiftCount = Convert.ToInt32(Console.ReadLine()) % arrayLength;
        
        for (int i = 0; i < shiftCount; i++)
        {
            for (int j = 0; j < arrayLength - 1; j++)
                (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
        }
        
        Console.WriteLine();
        Console.WriteLine("Массив со смещенными данными:");
        
        for (int i = 0; i < arrayLength; i++)
            Console.Write($"{numbers[i]} ");
        
        Console.WriteLine();
    }
}
