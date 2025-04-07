namespace Practice_50;

class Program
{
    static void Main(string[] args)
    {
        const string CommandSearch = "1";
        const string CommandExit = "2";
        
        var database = new CriminalsDatabase(new CriminalsFactory());
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            Console.WriteLine($"{CommandSearch}. Поиск в базе данных");
            Console.WriteLine($"{CommandExit}. Выход");
            
            switch (Utils.ReadUserInput("Введите команду"))
            {
                case CommandSearch:
                    database.Search();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage("Неизвестная команда");
                    break;
            }
        }
    }
}