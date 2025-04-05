namespace Practice_49.Factories;

public class PartStorageFactory
{
    private List<Part> _parts;
    
    public PartStorageFactory(PartFactory factory)
    {
        _parts = factory.Create();
    }
    
    public Dictionary<string, PartStorage> Create()
    {
        var storages = new Dictionary<string, PartStorage>(_parts.Count);
        
        foreach (var part in _parts)
            storages.Add(part.Type, new PartStorage(part.Type, part.Price, 10));
        
        return storages;
    }
}
