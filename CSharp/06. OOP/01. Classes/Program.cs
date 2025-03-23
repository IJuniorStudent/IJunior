namespace Practice_37;

class Program
{
    static void Main(string[] args)
    {
        Player[] players =
        [
            new Player("Дмитрий", 100),
            new Player("Игорь", 9000),
            new Player("Максим", 359)
        ];
        
        foreach (var player in players)
            player.ShowInfo();
    }
}

class Player
{
    private string _name;
    private int _score;
    
    public Player(string name, int score)
    {
        _name = name;
        _score = score;
    }
    
    public void ShowInfo()
    {
        Console.WriteLine($"Меня зовут: {_name}, мой счет: {_score} очков");
    }
}
