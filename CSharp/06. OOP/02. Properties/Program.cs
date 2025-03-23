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
        
        Renderer renderer = new Renderer();
        Player player = new Player(playerStartX, playerStartY, playerAppearance);
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            renderer.DrawPlayer(player);
            
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            
            if (pressedKey == exitKey)
                isAppRun = false;
        }
    }
}

class Player
{
    public Player(int positionX, int positionY, char appearance)
    {
        PositionX = positionX;
        PositionY = positionY;
        Appearance = appearance;
    }
    
    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
    public char Appearance { get; private set; }
}

class Renderer
{
    public void DrawPlayer(Player player)
    {
        Console.SetCursorPosition(player.PositionX, player.PositionY);
        Console.Write(player.Appearance);
    }
}
