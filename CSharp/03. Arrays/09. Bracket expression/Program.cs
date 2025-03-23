namespace Practice_26;

class Program
{
    static void Main(string[] args)
    {
        string expression = "(()(()))";
        char openCharacter = '(';
        char closeCharacter = ')';
        
        int depthLevel = 0;
        int maxDepthLevel = depthLevel;
        
        foreach (char element in expression)
        {
            if (element == openCharacter)
                depthLevel++;
            else if (element == closeCharacter)
                depthLevel--;
            
            if (depthLevel < 0)
                break;
            
            if (depthLevel > maxDepthLevel)
                maxDepthLevel = depthLevel;
        }
        
        if (depthLevel == 0)
        {
            Console.WriteLine($"Выражение \"{expression}\" является корректным");
            Console.WriteLine($"Максимальный уровень вложенности: {maxDepthLevel}");
        }
        else
        {
            Console.WriteLine($"Выражение \"{expression}\" не является корректным");
        }
    }
}
