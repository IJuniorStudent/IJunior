namespace Practice_48.Factories;

using Animals;

public class LemurFactory : AnimalFactory
{
    public override Animal Create(Gender gender)
    {
        return new Animal("Lemur", "Chatter", gender);
    }
}
