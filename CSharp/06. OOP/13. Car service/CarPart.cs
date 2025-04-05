namespace Practice_49;

public class CarPart : Part
{
    public CarPart(string type, int price, bool isDamaged) : base(type, price)
    {
        IsDamaged = isDamaged;
    }
    
    public bool IsDamaged { get; private set; }
    
    public void Repair()
    {
        IsDamaged = false;
    }
}
