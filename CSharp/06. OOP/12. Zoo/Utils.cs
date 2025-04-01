namespace Practice_48;

public class Utils
{
    private static Random s_random = new Random();
    
    public static int GetRandomNumber(int rangeMax)
    {
        return s_random.Next(rangeMax);
    }
    
    public static int GetRandomNumber(int rangeMin, int rangeMax)
    {
        return s_random.Next(rangeMin, rangeMax);
    }
    
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