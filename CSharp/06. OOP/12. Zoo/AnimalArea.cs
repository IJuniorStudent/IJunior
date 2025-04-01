namespace Practice_48;

using Animals;

public class AnimalArea
{
    private List<Animal> _animals;
    
    public AnimalArea(List<Animal> animals)
    {
        _animals = animals;
    }
    
    public void Display()
    {
        Console.Clear();
        
        if (_animals.Count == 0)
        {
            Utils.PrintWaitMessage("В этом вольере нет животных");
            return;
        }
        
        Console.WriteLine("В этом вольере содержатся животные:");
        
        for (int i = 0; i < _animals.Count; i++)
            Console.WriteLine($"{i + 1}. {_animals[i].Summary}");
        
        Console.WriteLine();
        Utils.WaitAnyKeyPress();
    }
}
