namespace Practice_48.Factories;

using Animals;

public abstract class AnimalFactory
{
    public abstract Animal Create(Gender gender);
}
