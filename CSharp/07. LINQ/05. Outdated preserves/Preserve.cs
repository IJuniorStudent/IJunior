namespace Practice_54;

public class Preserve
{
    public Preserve(string name, int factoryYear, int expireYears)
    {
        Name = name;
        FactoryYear = factoryYear;
        ExpireTime = expireYears;
    }
    
    public string Name { get; }
    public int FactoryYear { get; }
    public int ExpireTime { get; }
    public int ExpireYear => FactoryYear + ExpireTime;
    public string Summary => $"{Name}. Год производства: {FactoryYear}. Срок годности: {ExpireTime}, до {ExpireYear}";
}
