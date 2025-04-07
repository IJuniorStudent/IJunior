namespace Practice_50;

public class CriminalsFactory
{
    public List<Criminal> Create()
    {
        return new List<Criminal>
        {
            new Criminal("Jack Daniels", 25, 350, "Orc", false),
            new Criminal("Jim Beam", 20, 500, "Elf", false),
            new Criminal("Red Label", 25, 400, "Orc", true),
            new Criminal("Blue Label", 20, 400, "Elf", true),
            new Criminal("Black Label", 25, 400, "Orc", false),
        };
    }
}
