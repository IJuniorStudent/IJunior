namespace Practice_31;

class Program
{
    const char WallSymbol = '#';
    const char PlayerSymbol = '@';
    
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        int gameFieldStartX = 0;
        int gameFieldStartY = 0;
        
        int playerStartPositionX = 1;
        int playerStartPositionY = 1;
        
        char[,] gameMap = LoadGameMap();
        int[] mapDrawPosition = [gameFieldStartX, gameFieldStartY];
        int[] playerPosition = [mapDrawPosition[0] + playerStartPositionX, mapDrawPosition[1] + playerStartPositionY];
        
        bool isGameRunning = true;
        
        while (isGameRunning)
        {
            Console.Clear();
            
            DrawGameMap(mapDrawPosition, gameMap);
            DrawPlayerMark(playerPosition);
            
            ConsoleKey userInputKey = Console.ReadKey().Key;
            
            if (HandleMovementInput(userInputKey, out int[] moveDirection))
                TryMovePlayer(gameMap, moveDirection, playerPosition);
            
            if (HandleExitInput(userInputKey))
                isGameRunning = false;
        }
        
        Console.CursorVisible = true;
        Console.Clear();
        Console.WriteLine("Bye bye!");
    }
    
    static bool HandleMovementInput(ConsoleKey pressedKey, out int[] moveDirection)
    {
        moveDirection = [0, 0];
        
        bool isHandled = true;
        
        switch (pressedKey)
        {
            case ConsoleKey.UpArrow:
                moveDirection[1] = -1;
                break;
            
            case ConsoleKey.DownArrow:
                moveDirection[1] = 1;
                break;
            
            case ConsoleKey.LeftArrow:
                moveDirection[0] = -1;
                break;
            
            case ConsoleKey.RightArrow:
                moveDirection[0] = 1;
                break;
            
            default:
                isHandled = false;
                break;
        }
        
        return isHandled;
    }
    
    static bool HandleExitInput(ConsoleKey pressedKey)
    {
        return pressedKey == ConsoleKey.Escape;
    }
    
    static void TryMovePlayer(char[,] gameMap, int[] moveDirection, int[] playerPosition)
    {
        if (gameMap[playerPosition[1] + moveDirection[1], playerPosition[0] + moveDirection[0]] == WallSymbol)
            return;
        
        playerPosition[0] += moveDirection[0];
        playerPosition[1] += moveDirection[1];
    }
    
    static void DrawGameMap(int[] drawPosition, char[,] gameMap)
    {
        Console.SetCursorPosition(drawPosition[0], drawPosition[1]);
        
        for (int i = 0; i < gameMap.GetLength(0); i++)
        {
            for (int j = 0; j < gameMap.GetLength(1); j++)
                Console.Write(gameMap[i, j]);
            
            Console.WriteLine();
        }
    }
    
    static void DrawPlayerMark(int[] playerPosition)
    {
        Console.SetCursorPosition(playerPosition[0], playerPosition[1]);
        Console.Write(PlayerSymbol);
    }
    
    static char[,] LoadGameMap()
    {
        string[] fileContents =
        [
            "##########",
            "#        #",
            "# ####  ##",
            "# #  #   #",
            "# #  ### #",
            "# #  #   #",
            "# #      #",
            "#    #####",
            "#        #",
            "##########"
        ];
        
        int mapHeight = fileContents.Length;
        int mapWidth = FindMinMapRowLength(fileContents);
        
        char[,] gameMap = new char[mapHeight, mapWidth];
        
        for (int i = 0; i < mapHeight; i++)
            for (int j = 0; j < mapWidth; j++)
                gameMap[i, j] = fileContents[i][j];
        
        return gameMap;
    }
    
    static int FindMinMapRowLength(string[] loadedGameMap)
    {
        if (loadedGameMap.Length == 0)
            return 0;
        
        int length = loadedGameMap[0].Length;
        
        foreach (string mapRow in loadedGameMap)
        {
            if (mapRow.Length < length)
                length = mapRow.Length;
        }
        
        return length;
    }
}
 