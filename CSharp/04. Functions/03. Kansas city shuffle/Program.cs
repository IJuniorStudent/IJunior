namespace Practice_29;

class Program
{
    static void Main(string[] args)
    {
        int arrayLength = 20;
        
        int[] numbers = InitNumberSequence(arrayLength);
        
        Console.WriteLine($"Исходный массив чисел:\n{ArrayToString(numbers)}\n");
        
        Shuffle(ref numbers);
        
        Console.WriteLine($"Перемешанный массив:\n{ArrayToString(numbers)}\n");
    }
 
    static int[] InitNumberSequence(int sequenceLength)
    {
        int[] result = new int[sequenceLength];
        
        for (int i = 0; i < sequenceLength; i++)
            result[i] = i + 1;
        
        return result;
    }
 
    static void Shuffle(ref int[] numbers)
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
    
    static string ArrayToString(int[] numbers)
    {
        string result = "";
        
        foreach (int value in numbers)
            result += $"{value} ";
        
        return result;
    }
}
