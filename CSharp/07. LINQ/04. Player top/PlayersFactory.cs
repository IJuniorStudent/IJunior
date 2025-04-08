namespace Practice_53;

public class PlayersFactory
{
    public List<Player> Create()
    {
        return new List<Player>
        {
            new Player("Brandon", 50, 91),
            new Player("Jon", 999, 81),
            new Player("Eddard", 68, 44),
            new Player("Robb", 45, 49),
            new Player("Theon", 56, 74),
            new Player("Sansa", 61, 83),
            new Player("Catelyn", 72, 65),
            new Player("Arya", 33, 78),
            new Player("Rickon", 27, 83),
            new Player("Lysa", 100, 35)
        };
    }
}
