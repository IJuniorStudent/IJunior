namespace Practice_49;

public class Invoice
{
    private Dictionary<string, int> _partsPrices;
    private Dictionary<string, bool> _partsRepairStatus;
    
    public Invoice(IReadOnlyList<CarPart> carParts)
    {
        RepairFee = 0;
        _partsPrices = new Dictionary<string, int>();
        _partsRepairStatus = new Dictionary<string, bool>();
        
        InitRepairData(carParts);
    }
    
    public int RepairFee { get; private set; }
    public int PartsCount => _partsPrices.Count;
    public int RepairedCount => GetRepairedPartsCount();
    
    public void RegisterRepairedPart(string partType)
    {
        _partsRepairStatus[partType] = true;
        RepairFee += _partsPrices[partType];
    }
    
    public List<string> GetPartTypes()
    {
        var partTypes = new List<string>();
        
        foreach (var pair in _partsPrices)
            partTypes.Add(pair.Key);
        
        return partTypes;
    }
    
    public int GetPartRepairPrice(string partType)
    {
        return _partsPrices[partType];
    }
    
    public bool IsPartRepaired(string partType)
    {
        return _partsRepairStatus[partType];
    }
    
    private void InitRepairData(IReadOnlyList<CarPart> carParts)
    {
        foreach (var part in carParts)
        {
            if (part.IsDamaged == false)
                continue;
            
            _partsPrices.Add(part.Type, part.Price);
            _partsRepairStatus.Add(part.Type, false);
        }
    }
    
    private int GetRepairedPartsCount()
    {
        int count = 0;
        
        foreach (var partStatus in _partsRepairStatus)
            if (partStatus.Value)
                count++;
        
        return count;
    }
}
