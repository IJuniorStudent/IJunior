namespace Practice_28;

class Program
{
    static void Main(string[] args)
    {
        int currentHealth = 4;
        int maxHealth = 10;
        int healthBarPositionX = 0;
        int healthBarPositionY = 0;
        
        DrawProgressBar("Health", GenerateProgressBar(currentHealth, maxHealth), healthBarPositionX, healthBarPositionY);
    }
    
    static string GenerateProgressBar(int filledLength, int totalLength, char fillChar = '#', char backChar = '_')
    {
        string progressBar = "";
        
        for (int i = 0; i < totalLength; i++)
        {
            char drawChar = i < filledLength ? fillChar : backChar;
            progressBar += drawChar;
        }
        
        return progressBar;
    }
    
    static void DrawProgressBar(string barCaption, string progressBar, int positionX, int positionY, char leftBorderChar = '[', char rightBorderChar = ']')
    {
        (int lastPositionX, int lastPositionY) = Console.GetCursorPosition();
        
        Console.SetCursorPosition(positionX, positionY);
        Console.Write($"{barCaption}: {leftBorderChar}{progressBar}{rightBorderChar}");
        Console.SetCursorPosition(lastPositionX, lastPositionY);
    }
}
