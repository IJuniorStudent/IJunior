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
            
            string userInput = Utils.ReadUserInput("Введите номер команды");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandListPlayers:
                    DatabaseUtils.PrintPlayersList(database);
                    break;
                
                case CommandAddPlayer:
                    DatabaseUtils.AddPlayer(database);
                    break;
                
                case CommandBanPlayer:
                    DatabaseUtils.BanPlayer(database);
                    break;
                
                case CommandUnbanPlayer:
                    DatabaseUtils.UnbanPlayer(database);
                    break;
                
                case CommandRemovePlayer:
                    DatabaseUtils.RemovePlayer(database);
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage("Введена неизвестная команда!");
                    break;
            }
        }
    }
}

class DatabaseUtils
{
    public static void PrintPlayersList(Database database)
    {
        database.PrintPlayers();
        
        Utils.WaitAnyKeyPress();
    }
    
    public static void AddPlayer(Database database)
    {
        string nickName = Utils.ReadUserInput("Введите ник персонажа");
        
        if (Utils.TryReadNumberInput("Введите уровень персонажа", out int level) == false)
            return;
        
        database.AddPlayer(nickName, level);
        
        Utils.PrintWaitMessage($"Игрок с ником \"{nickName}\" и уровнем {level} добавлен в базу данных!");
    }
    
    public static void BanPlayer(Database database)
    {
        database.PrintPlayers();
        
        if (Utils.TryReadNumberInput("Введите ID игрока, чтобы забанить", out int playerId) == false)
            return;
        
        if (TryGetPlayer(database, playerId, out Player? player) == false)
            return;
        
        player.Ban();
        
        Utils.PrintWaitMessage($"Игрок с ID {playerId} успешно забанен");
    }
    
    public static void UnbanPlayer(Database database)
    {
        database.PrintPlayers();
        
        if (Utils.TryReadNumberInput("Введите ID игрока, чтобы разбанить", out int playerId) == false)
            return;
        
        if (TryGetPlayer(database, playerId, out Player? player) == false)
            return;
        
        player.Unban();
        
        Utils.PrintWaitMessage($"Игрок с ID {playerId} успешно разбанен");
    }
    
    public static void RemovePlayer(Database database)
    {
        database.PrintPlayers();
        
        if (Utils.TryReadNumberInput("Введите ID игрока, чтобы удалить", out int playerId) == false)
            return;
        
        if (database.RemovePlayer(playerId) == false)
        {
            Utils.PrintWaitMessage($"Игрок с ID {playerId} не найден в базе данных");
            return;
        }
        
        Utils.PrintWaitMessage($"Игрок с ID {playerId} успешно удален");
    }
    
    private static bool TryGetPlayer(Database database, int playerId, out Player? player)
    {
        if (database.TryGetPlayer(playerId, out player) == false)
        {
            Console.WriteLine($"Игрок с ID {playerId} не найден в базе данных");
            return false;
        }
        
        return true;
    }
}
 
class Utils
{
    public static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    public static bool TryReadNumberInput(string promptMessage, out int number)
    {
        if (int.TryParse(ReadUserInput(promptMessage), out number) == false)
        {
            PrintWaitMessage("Ввведено некорректное число");
            return false;
        }
        
        return true;
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

class Database
{
    private int _playerIdCounter;
    private Dictionary<int, Player> _players;
    
    public Database()
    {
        _playerIdCounter = 1;
        _players = new Dictionary<int, Player>();
    }
    
    public void AddPlayer(string nick, int level)
    {
        _players.Add(_playerIdCounter, new Player(_playerIdCounter++, nick, level));
    }
    
    public bool TryGetPlayer(int playerId, out Player? player)
    {
        return _players.TryGetValue(playerId, out player);
    }
    
    public bool RemovePlayer(int playerId)
    {
        return _players.Remove(playerId);
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
}

class Player
{
    public Player(int id, string nick, int level)
    {
        Id = id;
        Nickname = nick;
        Level = level;
        IsBanned = false;
    }
    
    public int Id { get; private set; }
    public string Nickname { get; private set; }
    public int Level { get; private set; }
    public bool IsBanned { get; private set; }
    
    public void Print()
    {
        string banState = "";
        
        if (IsBanned)
            banState = " (забанен)";
        
        Console.WriteLine($"[{Id}] {Nickname} - уровень: {Level}{banState}");
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
