namespace Practice_28;

class Program
{
    static void Main(string[] args)
    {
        float currentHealthPercent = 75;
        int healthBarLength = 20;
        int healthBarPositionX = 0;
        int healthBarPositionY = 0;
        
        DrawProgressBar("Health", GenerateProgressBar(currentHealthPercent, healthBarLength), healthBarPositionX, healthBarPositionY);
    }
    
    static string GenerateProgressBar(float barFillPercent, int barLength, char fillChar = '#', char backChar = '_')
    {
        string progressBar = "";
        int fillLength = (int)(barLength * barFillPercent / 100.0f);
        
        for (int i = 0; i < barLength; i++)
        {
            char drawChar = i < fillLength ? fillChar : backChar;
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
