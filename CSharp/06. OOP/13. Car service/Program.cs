namespace Practice_49;

using Factories;

class Program
{
    static void Main(string[] args)
    {
        const string CommandServeCar = "1";
        const string CommandExit = "2";
        
        CarService service = InitService();
        bool isAppRun = true;
        
        while (isAppRun && service.IsOpen)
        {
            Console.Clear();
            Console.WriteLine($"Баланс сервиса: {service.Money}. Машин в очереди: {service.QueueSize}");
            Console.WriteLine("Действия:");
            Console.WriteLine($"{CommandServeCar}. Обслужить машину");
            Console.WriteLine($"{CommandExit}. Завершить работу");
            Console.WriteLine();
            
            switch (Utils.ReadUserInput("Выберите действие"))
            {
                case CommandServeCar:
                    service.ServeNext();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage("Неизвестное действие");
                    break;
            }
        }
        
        if (isAppRun == false)
        {
            Console.WriteLine("До свидания!");
            return;
        }
        
        if (service.QueueSize == 0)
        {
            Console.WriteLine("Все машины обслужены!");
            return;
        }
        
        Console.WriteLine("Вы банкрот. Сервис закрыт за долги");
    }
    
    private static CarService InitService()
    {
        return (new CarServiceFactory()).Create();
    }
}
