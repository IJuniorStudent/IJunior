namespace Practice_47;

public class Aquarium
{
    private int _capacity;
    private List<Fish> _population;

    public Aquarium(int capacity)
    {
        _capacity = capacity;
        _population = new List<Fish>();
    }
    
    public void AddFish(FishFactory factory)
    {
        if (_population.Count >= _capacity)
        {
            Utils.PrintWaitMessage("Аквариум полностью занят");
            return;
        }
        
        if (factory.TryCreate(out Fish fish) == false)
            return;
        
        _population.Add(fish);
        Update();
    }
    
    public void RemoveFish()
    {
        if (Utils.TryReadNumberInput("Введите номер рыбы, которую хотите достать", out int fishNumber) == false)
            return;

        int fishIndex = fishNumber - 1;

        if (fishIndex < 0 || fishIndex >= _population.Count)
        {
            Utils.PrintWaitMessage($"Рыбы под номером {fishNumber} не существует");
            return;
        }
        
        _population.RemoveAt(fishIndex);
        Update();
    }
    
    public void Update()
    {
        UpdatePopulation();
        RemoveDead();
    }
    
    public void DisplayPopulation()
    {
        Console.WriteLine($"Всего рыб {_population.Count} из {_capacity}");
        Console.WriteLine();
        
        for (int i = 0; i < _population.Count; i++)
            Console.WriteLine($"Рыба {i + 1}. {_population[i].Summary} ");
    }
    
    private void UpdatePopulation()
    {
        foreach (var fish in _population)
            fish.Update();
    }

    private void RemoveDead()
    {
        for (int i = _population.Count - 1; i >= 0; i--)
        {
            if (_population[i].IsAlive == false)
                _population.RemoveAt(i);
        }
    }
}