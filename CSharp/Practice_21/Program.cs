namespace Practice_21;

class Program
{
    static void Main(string[] args)
    {
        const string CommandCalculateSum = "sum";
        const string CommandExit = "exit";
        
        int[] userInputNumbers = new int[0];
        int sumOfInputNumbers = 0;
        bool isAppRunning = true;
        
        while (isAppRunning)
        {
            Console.Clear();
            Console.WriteLine("Вводите числа через Enter для последующего вычисления их суммы.");
            Console.WriteLine("Также используйте следующие управляющие команды:");
            Console.WriteLine($"- {CommandCalculateSum}: вычислить сумму всех введенных ранее чисел");
            Console.WriteLine($"- {CommandExit}: выйти из приложения");
            Console.WriteLine();
            Console.Write("Сохраненные числа: ");
            
            foreach (int number in userInputNumbers)
                Console.Write($"{number} ");
            
            Console.WriteLine("\n");
            Console.Write("> ");
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case CommandCalculateSum:
                    foreach (int number in userInputNumbers)
                        sumOfInputNumbers += number;
                    
                    Console.WriteLine();
                    Console.WriteLine($"Сумма введенных чисел: {sumOfInputNumbers}\n");
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    
                    userInputNumbers = new int[0];
                    sumOfInputNumbers = 0;
                    
                    break;
                
                case CommandExit:
                    isAppRunning = false;
                    Console.WriteLine("До свидания!");
                    break;
                
                default:
                    int value = Convert.ToInt32(userInput);
                    
                    int userNumbersCount = userInputNumbers.Length;
                    int[] tempBuffer = new int[userNumbersCount + 1];
                    
                    for (int i = 0; i < userNumbersCount; i++)
                        tempBuffer[i] = userInputNumbers[i];
                    
                    tempBuffer[userNumbersCount] = value;
                    userInputNumbers = tempBuffer;
                    
                    break;
            }
        }
    }
}
