namespace Practice_49;

public class Shelf
{
    private Stack<CarPart> _parts;
    
    public Shelf(List<CarPart> parts)
    {
        _parts = new Stack<CarPart>(parts);
    }
    
    public int Count => _parts.Count;
    
    public bool TryTake(out CarPart? part)
    {
        part = null;
        
        if (_parts.Count == 0)
            return false;
        
        part = _parts.Pop();
        return true;
    }
}
