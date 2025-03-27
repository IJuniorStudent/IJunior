namespace Practice_46;

using Battle;

class Program
{
    static void Main(string[] args)
    {
        var squadFactory = new SquadFactory();
        var arena = new Arena(squadFactory);
        
        arena.Fight();
        arena.ShowWinner();
    }
}
