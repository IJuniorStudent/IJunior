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
    public const int PassengerCapacity = 40;
    
    private int _passengersCount;
    
    public Wagon()
    {
        _passengersCount = 0;
    }
    
    public void PlacePassengers(int passengersCount)
    {
        if (FreePlaces < passengersCount)
            throw new ArgumentOutOfRangeException();
        
        _passengersCount += passengersCount;
    }
    
    public int PlaceToCapacity(int passengersCount)
    {
        int passengersToPlace = Math.Min(passengersCount, PassengerCapacity);
        
        PlacePassengers(passengersToPlace);
        
        return passengersToPlace;
    }
    
    public int SoldPlaces => _passengersCount;
    
    private int FreePlaces => PassengerCapacity - _passengersCount;
}

class Train
{
    private List<Wagon> _wagons;
    
    public Train(string startCityName, string targetCityName)
    {
        _wagons = new List<Wagon>();
        
        StartCityName = startCityName;
        TargetCityName = targetCityName;
    }
    
    public string StartCityName { get; }
    public string TargetCityName { get; }
    
    public void AddWagon(Wagon wagon)
    {
        _wagons.Add(wagon);
    }
    
    public string GetSummaryInfo()
    {
        int totalPassengers = 0;
        int maxPassengers = 0;
        
        foreach (var wagon in _wagons)
        {
            totalPassengers += wagon.SoldPlaces;
            maxPassengers += Wagon.PassengerCapacity;
        }
        
        return $"[{StartCityName} - {TargetCityName}] Вагонов: {_wagons.Count}, всего мест: {maxPassengers}, продано мест: {totalPassengers}";
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
        if (RequestPath(out string startCityName, out string targetCityName) == false)
            return;
        
        if (GetPassengersCount(out int passengersCount) == false)
            return;
        
        Train train = BuildTrain(startCityName, targetCityName, passengersCount);
        
        if (ConfirmTrainConfiguration(train) == false)
            return;
        
        _trains.Add(train);
    }
    
    private bool RequestPath(out string startCityName, out string targetCityName)
    {
        Console.Clear();
        
        startCityName = Utils.ReadUserInput("Введите город отправления");
        targetCityName = Utils.ReadUserInput("Введите город прибытия");
        
        Console.WriteLine();
        
        return Utils.ConfirmUserInput($"Отправление \"{startCityName}\", прибытие: \"{targetCityName}\"");
    }
    
    private bool GetPassengersCount(out int passengersCount)
    {
        int minPassengerCount = 100;
        int maxPassengerCount = 200;
        
        Console.Clear();
        
        passengersCount = _random.Next(minPassengerCount, maxPassengerCount + 1);
        
        return Utils.ConfirmUserInput($"{passengersCount} пассажиров хотят купить билеты на поезд");
    }
    
    private Train BuildTrain(string startCityName, string targetCityName, int passengersCount)
    {
        Console.Clear();
        
        Train train = new Train(startCityName, targetCityName);
        int passengersRemain = passengersCount;
        
        while (passengersRemain > 0)
        {
            Wagon wagon = new Wagon();
            
            passengersRemain -= wagon.PlaceToCapacity(passengersRemain);
            
            train.AddWagon(wagon);
        }
        
        return train;
    }
    
    private bool ConfirmTrainConfiguration(Train train)
    {
        Console.Clear();
        Console.WriteLine($"Предварительная конфигурация: {train.GetSummaryInfo()}");
        Console.WriteLine();
        
        return Utils.ConfirmUserInput("Все данные верны?");
    }
}

class Utils
{
    public static bool ConfirmUserInput(string promptMessage)
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
}
