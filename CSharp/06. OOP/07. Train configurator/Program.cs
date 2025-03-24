namespace Practice_43;

class Program
{
    static void Main(string[] args)
    {
        const string CommandBuildTrain = "1";
        const string CommandExit = "2";
        
        Dispatcher dispatcher = new Dispatcher();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            dispatcher.PrintTrainsInfo();
            
            Console.WriteLine();
            Console.WriteLine($"{CommandBuildTrain}. Сформировать поезд");
            Console.WriteLine($"{CommandExit}. Выход");
            Console.WriteLine();
            
            string userInput = Utils.ReadUserInput("Выберите опцию");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandBuildTrain:
                    dispatcher.AddTrain();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
            }
        }
    }
}

class Wagon
{
    private int _passengersCount;
    
    public Wagon()
    {
        _passengersCount = 0;
    }
    
    public int SoldPlaces => _passengersCount;
    private int FreePlaces => GetCapacity() - _passengersCount;
    
    public virtual int GetCapacity()
    {
        int defaultWagonCapacity = 40;
        
        return defaultWagonCapacity;
    }
    
    public void PlacePassengers(int passengersCount)
    {
        if (FreePlaces < passengersCount)
            throw new ArgumentOutOfRangeException();
        
        _passengersCount += passengersCount;
    }
    
    public int PlaceToCapacity(int passengersCount)
    {
        int passengersToPlace = Math.Min(passengersCount, GetCapacity());
        
        PlacePassengers(passengersToPlace);
        
        return passengersToPlace;
    }
}

class Route
{
    public Route(string from, string to)
    {
        Departure = from;
        Arrival = to;
    }
    
    public string Departure { get; }
    public string Arrival { get; }
    public string Description => $"{Departure} - {Arrival}";
}

class Train
{
    private List<Wagon> _wagons;
    
    public Train(Route route, List<Wagon> wagons)
    {
        Route = route;
        _wagons = wagons;
    }
    
    public Route Route { get; }
    
    public string GetSummaryInfo()
    {
        int totalPassengers = 0;
        int maxPassengers = 0;
        
        foreach (var wagon in _wagons)
        {
            totalPassengers += wagon.SoldPlaces;
            maxPassengers += wagon.GetCapacity();
        }
        
        return $"[{Route.Description}] Вагонов: {_wagons.Count}, всего мест: {maxPassengers}, продано мест: {totalPassengers}";
    }
}

class Dispatcher
{
    private Random _random;
    private List<Train> _trains;
    
    public Dispatcher()
    {
        _random = new Random();
        _trains = new List<Train>();
    }
    
    public void PrintTrainsInfo()
    {
        if (_trains.Count == 0)
        {
            Console.WriteLine("Поезда отсутствуют");
            return;
        }
        
        foreach (var train in _trains)
            Console.WriteLine(train.GetSummaryInfo());
    }
    
    public void AddTrain()
    {
        if (TryCreateRoute(out Route? route) == false)
            return;
        
        if (TrySellTickets(out int soldTicketsCount) == false)
            return;
        
        Train train = CreateTrain(route, soldTicketsCount);
        
        if (ConfirmTrainConfiguration(train) == false)
            return;
        
        _trains.Add(train);
    }
    
    private bool TryCreateRoute(out Route? route)
    {
        Console.Clear();
        
        string startCityName = Utils.ReadUserInput("Введите город отправления");
        string targetCityName = Utils.ReadUserInput("Введите город прибытия");
        route = null;
        
        Console.WriteLine();
        
        if (startCityName.ToLower() == targetCityName.ToLower())
        {
            Utils.PrintWaitMessage("Город отправления совпадает с городом прибытия. Невозможно создать маршрут");
            return false;
        }
 
        if (Utils.TryConfirmUserInput($"Отправление \"{startCityName}\", прибытие: \"{targetCityName}\"") == false)
            return false;
        
        route = new Route(startCityName, targetCityName);
        return true;
    }
    
    private bool TrySellTickets(out int soldTicketsCount)
    {
        int ticketsMinCount = 100;
        int ticketsMaxCount = 200;
        
        Console.Clear();
        
        soldTicketsCount = _random.Next(ticketsMinCount, ticketsMaxCount + 1);
        
        return Utils.TryConfirmUserInput($"{soldTicketsCount} пассажиров приобрели билеты на поезд");
    }
    
    private Train CreateTrain(Route route, int requiredPassengersCount)
    {
        Console.Clear();
        
        int passengersToPlace = requiredPassengersCount;
        List<Wagon> wagons = new List<Wagon>();
        
        while (passengersToPlace > 0)
        {
            Wagon wagon = new Wagon();
            wagons.Add(wagon);
            
            passengersToPlace -= wagon.PlaceToCapacity(passengersToPlace);
        }
        
        return new Train(route, wagons);
    }
    
    private bool ConfirmTrainConfiguration(Train train)
    {
        Console.Clear();
        Console.WriteLine($"Предварительная конфигурация: {train.GetSummaryInfo()}");
        Console.WriteLine();
        
        return Utils.TryConfirmUserInput("Все данные верны?");
    }
}

class Utils
{
    public static bool TryConfirmUserInput(string promptMessage)
    {
        const string CommandConfirm = "+";
        
        return ReadUserInput($"{promptMessage}\nНажмите {CommandConfirm}, чтобы подтвердить") == CommandConfirm;
    }
    
    public static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    public static void PrintWaitMessage(string message)
    {
        Console.WriteLine(message);
        
        WaitAnyKeyPress();
    }
    
    public static void WaitAnyKeyPress()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey(true);
    }
}
