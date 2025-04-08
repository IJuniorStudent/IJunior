namespace Practice_56;

public class SoldierFactory
{
    public List<Soldier> Create()
    {
        return new List<Soldier>
        {
            new Soldier("Михаил", "Бородин"),
            new Soldier("Даниил", "Климов"),
            new Soldier("Савелий", "Попов"),
            new Soldier("Тимофей", "Романов"),
            new Soldier("Михаил", "Булгаков")
        };
    }
}
