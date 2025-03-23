namespace Practice_32;

class Program
{
    static void Main(string[] args)
    {
        const string CommandExit = "exit";
        
        Dictionary<string, string> wordExplainStorage = new Dictionary<string, string>
        {
            ["Функция"] = "Блок кода для повторного использования без дублирования",
            ["Метод"] = "Блок кода для повторного использования без дублирования, который является членом класса"
        };
        
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine($"Напишите слово для получения его значения или \"{CommandExit}\" для выхода.");
            Console.WriteLine("Доступные слова:");
            
            foreach (var word in wordExplainStorage.Keys)
                Console.WriteLine($"- {word}");
            
            Console.Write("> ");
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case CommandExit:
                    isAppRun = false;
                    Console.WriteLine("До свидания!");
                    break;
                
                default:
                    Console.WriteLine();
                    
                    if (wordExplainStorage.ContainsKey(userInput))
                        Console.WriteLine($"Значение слова \"{userInput}\": {wordExplainStorage[userInput]}");
                    else
                        Console.WriteLine($"Слово \"{userInput}\" не найдено");
                    
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
