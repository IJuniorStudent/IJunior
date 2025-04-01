namespace Practice_48.Factories;

using Animals;

public class CapybaraFactory : AnimalFactory
{
    public override Animal Create(Gender gender)
    {
        return new Animal("Capybara", "Squeak", gender);
    }
}
