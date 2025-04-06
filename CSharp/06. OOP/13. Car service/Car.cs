namespace Practice_49;

public class Car
{
    private List<CarPart> _parts;
    
    public Car(List<CarPart> parts)
    {
        _parts = parts;
    }
    
    public IReadOnlyList<CarPart> Parts => _parts;
    public bool IsDamaged => IsAnyPartDamaged();
    
    public bool HasPart(string partType)
    {
        foreach (CarPart part in _parts)
            if (part.Type == partType)
                return true;
        
        return false;
    }
    
    public void ReplacePart(CarPart part)
    {
        int partIndex = FindPartIndex(part.Type);
        
        _parts[partIndex] = part;
    }
    
    private int FindPartIndex(string partType)
    {
        int invalidIndexValue = -1;
        
        for (int i = 0; i < _parts.Count; i++)
            if (_parts[i].Type == partType)
                return i;
        
        return invalidIndexValue;
    }

    private bool IsAnyPartDamaged()
    {
        foreach (CarPart part in _parts)
            if (part.IsDamaged)
                return true;
        
        return false;
    }
}
