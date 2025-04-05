namespace Practice_49;

public class Car
{
    private List<CarPart> _parts;
    
    public Car(List<CarPart> parts)
    {
        _parts = parts;
    }
    
    public IReadOnlyList<CarPart> Parts => _parts;
}
