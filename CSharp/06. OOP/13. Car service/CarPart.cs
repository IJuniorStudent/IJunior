namespace Practice_49;

public class CarPart
{
    public CarPart(string type, int price, bool isDamaged)
    {
        Type = type;
        Price = price;
        IsDamaged = isDamaged;
    }
    
    public string Type { get; }
    public int Price { get; }
    public bool IsDamaged { get; }
    
    public CarPart Clone()
    {
        return new CarPart(Type, Price, IsDamaged);
    }
}
