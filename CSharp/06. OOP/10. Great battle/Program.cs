namespace Practice_46;

using Battle;

class Program
{
    static void Main(string[] args)
    {
        var squadFactory = new SquadFactoryFixed();
        var arena = new Arena(squadFactory);
        
        arena.Fight();
        
        Squad winner = arena.GetWinner();
        
        Console.WriteLine($"Победитель - {winner.Name}");
    }
}
