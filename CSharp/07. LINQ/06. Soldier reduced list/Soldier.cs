namespace Practice_55;

public class Soldier
{
    public Soldier(string name, string weapon, string rank, int serveTime)
    {
        Name = name;
        Weapon = weapon;
        Rank = rank;
        ServeTime = serveTime;
    }
    
    public string Name { get; }
    public string Weapon { get; }
    public string Rank { get; }
    public int ServeTime { get; }
}