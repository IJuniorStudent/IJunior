namespace Practice_56;

class Program
{
    static void Main(string[] args)
    {
        string surnameStart = "Б".ToLower();
        
        var factory = new SoldierFactory();
        List<Soldier> firstSquad = factory.Create();
        List<Soldier> secondSquad = new List<Soldier>();
        
        DisplaySoldiers("Отряд до перевода", firstSquad);
        
        secondSquad = secondSquad.Concat(
            firstSquad
                .Where(entry => entry.Surname.ToLower().StartsWith(surnameStart))
        ).ToList();
        
        firstSquad = firstSquad.Except(secondSquad).ToList();
        
        DisplaySoldiers("Отряд после перевода", firstSquad);
        DisplaySoldiers("Новый отряд", secondSquad);
    }
    
    static void DisplaySoldiers(string headMessage, List<Soldier> soldiers)
    {
        Console.WriteLine(headMessage);
        
        foreach (var soldier in soldiers)
            Console.WriteLine($"- {soldier.FullName}");
        
        Console.WriteLine();
    }
}