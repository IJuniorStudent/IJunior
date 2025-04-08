namespace Practice_51;

class Program
{
    static void Main(string[] args)
    {
        string exceptReason = "Антиправительственное";
        List<Criminal> criminals = InitCrimialsList();
        
        DisplayCriminals("Список до исключения", criminals);
        
        criminals.RemoveAll(criminal => criminal.JailReason == exceptReason);
        
        DisplayCriminals("Список после исключения", criminals);
    }
    
    static List<Criminal> InitCrimialsList()
    {
        return new CriminalsFactory().Create();
    }

    static void DisplayCriminals(string headMessage, List<Criminal> criminals)
    {
        Console.WriteLine(headMessage);
        
        for (int i = 0; i < criminals.Count; i++)
            Console.WriteLine($"{i + 1}. {criminals[i].Summary}");
        
        Console.WriteLine();
    }
}