namespace Practice_53;

public class Player
{
    public Player(string name, int level, int strength)
    {
        Name = name;
        Level = level;
        Strength = strength;
    }
    
    public string Name { get; }
    public int Level { get; }
    public int Strength { get; }
    public string Summary => $"Ник: {Name}, уровень: {Level}, сила: {Strength}";
}