namespace Practice_46;

using Battle;

class Program
{
    static void Main(string[] args)
    {
        var arena = new Arena();
        arena.Fight();
        
        Squad winner = arena.GetWinner();
        
        Console.WriteLine($"Победитель - {winner.Name}");
    }
}
