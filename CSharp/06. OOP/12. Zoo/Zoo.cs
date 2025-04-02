namespace Practice_48;

using Factories;

public class Zoo
{
    private List<AnimalArea> _areas;
    
    public Zoo(AnimalAreaFactory factory)
    {
        _areas = factory.Create();
    }
    
    public int AreaCount => _areas.Count;
    
    public void DisplayArea(string userInput)
    {
        if (int.TryParse(userInput, out int areaNumber) == false)
            return;
        
        int areaIndex = areaNumber - 1;
        
        if (areaIndex < 0 || areaIndex >= _areas.Count)
        {
            Utils.PrintWaitMessage($"Вольера с номером {areaNumber} не существует");
            return;
        }
        
        _areas[areaIndex].Display();
    }
}