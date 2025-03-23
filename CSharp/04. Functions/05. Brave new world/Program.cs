namespace Practice_31;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        char obstacleSymbol = '#';
        char playerSymbol = '@';
        
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
            DrawPlayerMark(playerPosition, playerSymbol);
            
            ConsoleKey userInputKey = Console.ReadKey().Key;
            
            int[] moveDirection = GetMoveDirection(userInputKey);
            
            if (CanPlayerMove(gameMap, playerPosition, moveDirection, obstacleSymbol))
                MovePlayer(playerPosition, moveDirection);
                
            if (IsExitPressed(userInputKey))
                isGameRunning = false;
        }
        
        Console.CursorVisible = true;
        Console.Clear();
        Console.WriteLine("Bye bye!");
    }
    
    static int[] GetMoveDirection(ConsoleKey pressedKey)
    {
        const ConsoleKey CommandMoveUp = ConsoleKey.UpArrow;
        const ConsoleKey CommandMoveDown = ConsoleKey.DownArrow;
        const ConsoleKey CommandMoveLeft = ConsoleKey.LeftArrow;
        const ConsoleKey CommandMoveRight = ConsoleKey.RightArrow;
        
        int[] moveDirection = [0, 0];
        
        switch (pressedKey)
        {
            case CommandMoveUp:
                moveDirection[1] = -1;
                break;
            
            case CommandMoveDown:
                moveDirection[1] = 1;
                break;
            
            case CommandMoveLeft:
                moveDirection[0] = -1;
                break;
            
            case CommandMoveRight:
                moveDirection[0] = 1;
                break;
        }
        
        return moveDirection;
    }
    
    static bool CanPlayerMove(char[,] gameMap, int[] position, int[] direction, char obstacleSymbol)
    {
        return gameMap[position[1] + direction[1], position[0] + direction[0]] != obstacleSymbol;
    }
    
    static void MovePlayer(int[] position, int[] direction)
    {
        position[0] += direction[0];
        position[1] += direction[1];
    }
    
    static bool IsExitPressed(ConsoleKey pressedKey)
    {
        const ConsoleKey CommandExit = ConsoleKey.Escape;
        
        return pressedKey == CommandExit;
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
    
    static void DrawPlayerMark(int[] playerPosition, char playerSymbol)
    {
        Console.SetCursorPosition(playerPosition[0], playerPosition[1]);
        Console.Write(playerSymbol);
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
