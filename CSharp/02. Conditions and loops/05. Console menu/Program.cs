namespace Practice_11;

class Program
{
    static void Main(string[] args)
    {
        const string CommandHello = "hi";
        const string CommandGetWeather = "weather";
        const string CommandGenerateRandomNumber = "rand";
        const string CommandClearConsole = "clear";
        const string CommandExit = "exit";
 
        const int MinRandomNumber = 0;
        const int MaxRandomNumber = 100;
        
        Random random = new Random();
        bool isAppRunning = true;
        
        Console.WriteLine("Добро пожаловать в чат-бот!");
        Console.WriteLine();
 
        while (isAppRunning)
        {
            Console.WriteLine("Введите одну из команд:");
            Console.WriteLine($"- {CommandHello}: поприветствовать бота");
            Console.WriteLine($"- {CommandGetWeather}: узнать погоду");
            Console.WriteLine($"- {CommandGenerateRandomNumber}: получить случайное число в диапазоне от {MinRandomNumber} до {MaxRandomNumber}");
            Console.WriteLine($"- {CommandClearConsole}: очистить консоль");
            Console.WriteLine($"- {CommandExit}: выйти из приложения");
            Console.Write("> ");
            
            string userCommand = Console.ReadLine();
 
            switch (userCommand)
            {
                case CommandHello:
                    Console.WriteLine("Привет!");
                    break;
                
                case CommandGetWeather:
                    Console.WriteLine("Данный функционал недоступен в бесплатной версии");
                    break;
                
                case CommandGenerateRandomNumber:
                    int number = random.Next(MinRandomNumber, MaxRandomNumber + 1);
                    Console.WriteLine($"Ваше число: {number}");
                    break;
                
                case CommandClearConsole:
                    Console.Clear();
                    continue;
                
                case CommandExit:
                    Console.WriteLine("До свидания!");
                    isAppRunning = false;
                    break;
                
                default:
                    Console.WriteLine($"Команда \"{userCommand}\" мне неизвестна, попробуйте написать другую");
                    break;
            }
            
            Console.WriteLine();
        }
    }
}
 