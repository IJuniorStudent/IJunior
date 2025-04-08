namespace Practice_55;

class Program
{
    static void Main(string[] args)
    {
        var factory = new SoldierFactory();
        List<Soldier> soldiers = factory.Create();
        
        var reducedReport = soldiers
            .Select(entry => new { Name = entry.Name, Rank = entry.Rank });
        
        foreach (var soldier in reducedReport)
            Console.WriteLine($"Имя: {soldier.Name}, звание: {soldier.Rank}");
    }
}
