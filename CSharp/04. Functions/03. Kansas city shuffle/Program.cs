namespace Practice_29;

class Program
{
    static void Main(string[] args)
    {
        int arrayLength = 20;
        
        int[] numbers = InitNumberSequence(arrayLength);
        
        PrintArray("Исходный массив чисел", numbers);
        Shuffle(numbers);
        PrintArray("Перемешанный массив", numbers);
    }
 
    static int[] InitNumberSequence(int sequenceLength)
    {
        int[] numbers = new int[sequenceLength];
        
        for (int i = 0; i < sequenceLength; i++)
            numbers[i] = i + 1;
        
        return numbers;
    }
 
    static void Shuffle(int[] numbers)
    {
        int arrayLength = numbers.Length;
        Random random = new Random();
        
        for (int i = 0; i < arrayLength - 1; i++)
        {
            int swapIndex = random.Next(i, arrayLength);
            
            if (swapIndex != i)
                Swap(ref numbers[i], ref numbers[swapIndex]);
        }
    }
 
    static void Swap(ref int firstValue, ref int secondValue)
    {
        (firstValue, secondValue) = (secondValue, firstValue);
    }
    
    static void PrintArray(string headMessage, int[] numbers)
    {
        Console.WriteLine(headMessage);
        
        for (int i = 0; i < numbers.Length; i++)
            Console.Write($"{numbers[i]} ");
        
        Console.WriteLine();
    }
}
