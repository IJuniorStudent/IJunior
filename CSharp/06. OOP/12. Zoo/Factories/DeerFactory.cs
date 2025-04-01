namespace Practice_48.Factories;

using Animals;

public class DeerFactory : AnimalFactory
{
    public override Animal Create(Gender gender)
    {
        return new Animal("Deer", "Bellow", gender);
    }
}
