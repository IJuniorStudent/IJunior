namespace Practice_50;

public class CriminalsDatabase
{
    private List<Criminal> _criminals;
    
    public CriminalsDatabase(CriminalsFactory factory)
    {
        _criminals = factory.Create();
    }

    public void Search()
    {
        Console.Clear();
        
        if (Utils.TryReadNumberInput("Введите рост", out int height) == false)
            return;
        
        if (Utils.TryReadNumberInput("Введите вес", out int weight) == false)
            return;
        
        string origin = Utils.ReadUserInput("Введите национальность").ToLower();
        
        var filtered = _criminals
            .Where(entry => entry.IsJailed == false && entry.Height == height && entry.Weight == weight && entry.Origin.ToLower() == origin)
            .ToArray();
        
        Console.Clear();
        Console.WriteLine($"Поиск по параметрам:\n- рост: {height}\n- вес: {weight}\n- национальность: {origin}");
        Console.WriteLine();
        
        DisplayFound(filtered);
        
        Console.WriteLine();
        
        Utils.WaitAnyKeyPress();
    }

    private void DisplayFound(Criminal[] foundList)
    {
        if (foundList.Length == 0)
        {
            Console.WriteLine("Ничего не найдено");
            return;
        }
        
        for (int i = 0; i < foundList.Length; i++)
            Console.WriteLine($"{i + 1}. {foundList[i].Summary}");
    }
}