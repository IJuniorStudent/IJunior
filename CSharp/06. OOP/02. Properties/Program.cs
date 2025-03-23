namespace Practice_38;

class Program
{
    static void Main(string[] args)
    {
        int playerStartX = 10;
        int playerStartY = 10;
        char playerAppearance = '@';
        ConsoleKey exitKey = ConsoleKey.E;
        
        Console.CursorVisible = false;
        
        Player player = new Player(playerStartX, playerStartY, playerAppearance);
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Rederer.DrawPlayer(player);
            
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            
            if (pressedKey == exitKey)
                isAppRun = false;
        }
    }
}

class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public char Appearance { get; private set; }
    
    public Player(int x, int y, char appearance)
    {
        X = x;
        Y = y;
        Appearance = appearance;
    }
}

class Rederer
{
    public static void DrawPlayer(Player player)
    {
        Console.SetCursorPosition(player.X, player.Y);
        Console.Write(player.Appearance);
    }
}
