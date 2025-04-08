namespace Practice_56;

public class Soldier
{
    public Soldier(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
    
    public string Name { get; }
    public string Surname { get; }
    public string FullName => $"{Surname} {Name}";
}
