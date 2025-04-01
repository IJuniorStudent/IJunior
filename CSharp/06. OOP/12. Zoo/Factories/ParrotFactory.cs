namespace Practice_48.Factories;

using Animals;

public class ParrotFactory : AnimalFactory
{
    public override Animal Create(Gender gender)
    {
        return new Animal("Parrot", "Squawk", gender);
    }
}
