namespace Practice_48;

using Factories;

public class Zoo
{
    private List<AnimalArea> _areas;
    
    public Zoo(AnimalAreaFactory factory, int areasCount)
    {
        _areas = InitAreas(factory, areasCount);
    }
    
    public int AreaCount => _areas.Count;
    
    public void DisplayArea(string userInput)
    {
        if (int.TryParse(userInput, out int areaNumber) == false)
            return;
        
        int areaIndex = areaNumber;
        
        if (areaIndex < 0 || areaIndex >= _areas.Count)
        {
            Utils.PrintWaitMessage($"Вольера с номером {areaNumber} не существует");
            return;
        }
        
        _areas[areaIndex].Display();
    }
    
    private List<AnimalArea> InitAreas(AnimalAreaFactory factory, int areasCount)
    {
        var areas = new List<AnimalArea>();
        int animalsCount = 5;
        
        for (int i = 0; i < areasCount; i++)
            areas.Add(new AnimalArea(factory.CreateAnimals(animalsCount)));
        
        return areas;
    }
}