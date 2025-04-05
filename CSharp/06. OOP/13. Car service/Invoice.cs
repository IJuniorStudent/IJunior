namespace Practice_49;

public struct InvoiceCarPart
{
    public string Type;
    public int Price;
    public bool IsDamaged;

    public InvoiceCarPart(string type, int price, bool isDamaged)
    {
        Type = type;
        Price = price;
        IsDamaged = isDamaged;
    }
}

public class Invoice
{
    private int _totalRepairFee;
    private List<CarPart> _parts;
    
    public Invoice(IReadOnlyList<CarPart> carParts)
    {
        _totalRepairFee = 0;
        _parts = InitRepairList(carParts);
    }
    
    public int RepairFee => _totalRepairFee;
    public int PartsCount => _parts.Count;
    public int RepairedCount => GetRepairedPartsCount();

    public InvoiceCarPart GetPartDetails(int partIndex)
    {
        CarPart part = _parts[partIndex];
        
        return new InvoiceCarPart(part.Type, part.Price, part.IsDamaged);
    }
    
    public void Repair(int partIndex)
    {
        CarPart part = _parts[partIndex];
        
        part.Repair();
        _totalRepairFee += part.Price;
    }
    
    private List<CarPart> InitRepairList(IReadOnlyList<CarPart> carParts)
    {
        var repairList = new List<CarPart>();
        
        foreach (var part in carParts)
            if (part.IsDamaged)
                repairList.Add(part);
        
        return repairList;
    }
    
    private int GetRepairedPartsCount()
    {
        int count = 0;
        
        foreach (var part in _parts)
            if (part.IsDamaged == false)
                count++;
        
        return count;
    }
}
