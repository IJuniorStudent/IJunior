namespace Practice_39;

class Program
{
    static void Main(string[] args)
    {
        const string CommandListPlayers = "1";
        const string CommandAddPlayer = "2";
        const string CommandBanPlayer = "3";
        const string CommandUnbanPlayer = "4";
        const string CommandRemovePlayer = "5";
        const string CommandExit = "6";
        
        Database database = new Database();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            Console.WriteLine($"{CommandListPlayers}. Показать список всех игроков");
            Console.WriteLine($"{CommandAddPlayer}. Добавить нового игрока в базу данных");
            Console.WriteLine($"{CommandBanPlayer}. Забанить игрока");
            Console.WriteLine($"{CommandUnbanPlayer}. Разбанить игрока");
            Console.WriteLine($"{CommandRemovePlayer}. Удалить игрока");
            Console.WriteLine($"{CommandExit}. Выход");
            Console.WriteLine();
            
            string userInput = ReadUserInput("Введите номер команды");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandListPlayers:
                    PrintPlayersList(database);
                    break;
                
                case CommandAddPlayer:
                    AddPlayer(database);
                    break;
                
                case CommandBanPlayer:
                    BanPlayer(database);
                    break;
                
                case CommandUnbanPlayer:
                    UnbanPlayer(database);
                    break;
                
                case CommandRemovePlayer:
                    RemovePlayer(database);
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    PrintWaitMessage("Введена неизвестная команда!");
                    break;
            }
        }
    }
    
    static void PrintPlayersList(Database database)
    {
        database.PrintPlayers();
        
        WaitAnyKeyPress();
    }
    
    static void AddPlayer(Database database)
    {
        string nickName = ReadUserInput("Введите ник персонажа");
        
        if (TryReadNumberInput("Введите уровень персонажа", out int level) == false)
            return;
        
        database.AddNewPlayer(nickName, level);
        
        PrintWaitMessage($"Игрок с ником \"{nickName}\" и уровнем {level} добавлен в базу данных!");
    }
    
    static void BanPlayer(Database database)
    {
        database.PrintPlayers();
        
        if (TryReadNumberInput("Введите ID игрока, чтобы забанить", out int playerId) == false)
            return;
        
        if (database.TryBanPlayer(playerId) == false)
        {
            PrintWaitMessage($"Игрок с ID {playerId} не найден в базе данных");
            return;
        }
        
        PrintWaitMessage($"Игрок с ID {playerId} успешно забанен");
    }
    
    static void UnbanPlayer(Database database)
    {
        database.PrintPlayers();
        
        if (TryReadNumberInput("Введите ID игрока, чтобы разбанить", out int playerId) == false)
            return;
        
        if (database.TryUnbanPlayer(playerId) == false)
        {
            PrintWaitMessage($"Игрок с ID {playerId} не найден в базе данных");
            return;
        }
        
        PrintWaitMessage($"Игрок с ID {playerId} успешно разбанен");
    }
    
    static void RemovePlayer(Database database)
    {
        database.PrintPlayers();
        
        if (TryReadNumberInput("Введите ID игрока, чтобы удалить", out int playerId) == false)
            return;
        
        if (database.TryRemovePlayer(playerId) == false)
        {
            PrintWaitMessage($"Игрок с ID {playerId} не найден в базе данных");
            return;
        }
        
        PrintWaitMessage($"Игрок с ID {playerId} успешно удален");
    }
    
    static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    static bool TryReadNumberInput(string promptMessage, out int number)
    {
        if (int.TryParse(ReadUserInput(promptMessage), out number) == false)
        {
            PrintWaitMessage("Ввведено некорректное число");
            return false;
        }
        
        return true;
    }
    
    static void PrintWaitMessage(string message)
    {
        Console.WriteLine(message);
        WaitAnyKeyPress();
    }
    
    static void WaitAnyKeyPress()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey(true);
    }
}

class Database
{
    private int _idCounter;
    private Dictionary<int, Player> _players;
    
    public Database()
    {
        _idCounter = 1;
        _players = new Dictionary<int, Player>();
    }
    
    public void AddNewPlayer(string nick, int level)
    {
        _players.Add(_idCounter, new Player(_idCounter++, nick, level));
    }
    
    public bool TryRemovePlayer(int playerId)
    {
        if (HasPlayer(playerId) == false)
            return false;
        
        _players.Remove(playerId);
        return true;
    }
    
    public bool TryBanPlayer(int playerId)
    {
        if (HasPlayer(playerId) == false)
            return false;
        
        _players[playerId].Ban();
        return true;
    }
    
    public bool TryUnbanPlayer(int playerId)
    {
        if (HasPlayer(playerId) == false)
            return false;
        
        _players[playerId].Unban();
        return true;
    }
    
    public void PrintPlayers()
    {
        if (_players.Count == 0)
        {
            Console.WriteLine("В базе данных нет ни одного игрока");
            return;
        }
        
        foreach (var player in _players)
            player.Value.Print();
    }
    
    private bool HasPlayer(int playerId)
    {
        return _players.ContainsKey(playerId);
    }
}

class Player
{
    public Player(int id, string nick, int level)
    {
        ID = id;
        Nickname = nick;
        Level = level;
        IsBanned = false;
    }
    
    public int ID { get; private set; }
    public string Nickname { get; private set; }
    public int Level { get; private set; }
    public bool IsBanned { get; private set; }
    
    public void Print()
    {
        string banState = "";
        
        if (IsBanned)
            banState = " (забанен)";
        
        Console.WriteLine($"[{ID}] {Nickname} - уровень: {Level}{banState}");
    }
    
    public void Ban()
    {
        IsBanned = true;
    }
    
    public void Unban()
    {
        IsBanned = false;
    }
}
