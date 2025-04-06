namespace Practice_49.Factories;

public class PartStorageFactory
{
    private List<CarPart> _parts;
    
    public PartStorageFactory(NewPartFactory factory)
    {
        _parts = factory.Create();
    }
    
    public Dictionary<string, Shelf> Create()
    {
        int shelfCapacity = 10;
        var storages = new Dictionary<string, Shelf>(_parts.Count);
        
        foreach (var part in _parts)
        {
            List<CarPart> parts = new List<CarPart>(shelfCapacity);
            
            for (int i = 0; i < shelfCapacity; i++)
                parts.Add(part.Clone());
            
            storages.Add(part.Type, new Shelf(parts));
        }
        
        return storages;
    }
}
