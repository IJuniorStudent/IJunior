namespace Practice_48.Factories;

using Animals;

public class KoalaFactory : AnimalFactory
{
    public override Animal Create(Gender gender)
    {
        return new Animal("Koala", "Shriek", gender);
    }
}
