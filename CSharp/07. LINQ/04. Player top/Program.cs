namespace Practice_53;

class Program
{
    static void Main(string[] args)
    {
        int maxTopPlayers = 3;
        
        var factory = new PlayersFactory();
        List<Player> players = factory.Create();
        
        DisplayPlayers("Список игроков", players);
        
        DisplayPlayers(
            "Топ игроков по уровню",
            players
                .OrderByDescending(entry => entry.Level)
                .Take(maxTopPlayers)
                .ToList()
        );
        
        DisplayPlayers(
            "Топ игроков по силе",
            players
                .OrderByDescending(entry => entry.Strength)
                .Take(maxTopPlayers)
                .ToList()
        );
    }
    
    static void DisplayPlayers(string headMessage, List<Player> players)
    {
        Console.WriteLine(headMessage);
        
        for (int i = 0; i < players.Count; i++)
            Console.WriteLine($"{i + 1}. {players[i].Summary}");
        
        Console.WriteLine();
    }
}