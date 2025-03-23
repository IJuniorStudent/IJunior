namespace Practice_34;

class Program
{
    static void Main(string[] args)
    {
        const string CommandSumNumbers = "sum";
        const string CommandExit = "exit";
        
        List<int> numbers = new List<int>();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.WriteLine("Введите число, чтобы добавить его в список или введите одну из команд:");
            Console.WriteLine($"- {CommandSumNumbers}: посчитать сумму всех добавленных чисел");
            Console.WriteLine($"- {CommandExit}: выйти из приложения");
            Console.WriteLine();
            Console.Write("Добавленные числа: ");
            
            PrintNumbers(numbers);
            
            Console.WriteLine();
            Console.Write("> ");
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case CommandSumNumbers:
                    HandleCommandSumNumbers(numbers);
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    HandleCommandStoreNumber(userInput, numbers);
                    break;
            }
            
            Console.Clear();
        }
    }
    
    static void PrintNumbers(List<int> numbers)
    {
        foreach (var number in numbers)
            Console.Write($"{number} ");
    }
    
    static void HandleCommandSumNumbers(List<int> numbers)
    {
        int numberSum = 0;
        
        foreach (var number in numbers)
            numberSum += number;
        
        Console.WriteLine($"Сумма чисел: {numberSum}");
        
        WaitAnyKeyPress();
    }
    
    static void HandleCommandStoreNumber(string userInput, List<int> numbers)
    {
        if (int.TryParse(userInput, out int number) == false)
        {
            Console.WriteLine($"Значение {userInput} не является корректным числом");
            
            WaitAnyKeyPress();
            return;
        }
        
        numbers.Add(number);
    }
    
    static void WaitAnyKeyPress()
    {
        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите любую клавишу...");
        Console.ReadKey();
    }
}
