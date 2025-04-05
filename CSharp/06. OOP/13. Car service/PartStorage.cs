namespace Practice_49;

public class PartStorage : Part
{
    public PartStorage(string type, int price, int amount) : base(type, price)
    {
        Amount = amount;
    }
    
    public int Amount { get; private set; }

    public bool TryTake()
    {
        if (Amount <= 0)
            return false;
        
        Amount--;
        return true;
    }
}
