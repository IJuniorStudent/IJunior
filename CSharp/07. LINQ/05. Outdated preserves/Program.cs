namespace Practice_54;

class Program
{
    static void Main(string[] args)
    {
        int currentYear = DateTime.Now.Year;
        
        var factory = new PreserveFactory();
        List<Preserve> preserves = factory.Create();
        
        List<Preserve> outdatedPreserves = preserves
            .Where(entry => entry.ExpireYear < currentYear)
            .ToList();
        
        Console.WriteLine("Просроченные консервы");
        
        foreach (var preserve in outdatedPreserves)
            Console.WriteLine(preserve.Summary);
    }
}
