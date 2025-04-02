namespace Practice_48.Factories;

using Animals;

public class AnimalFactory
{
    public Animal Create(string type, string sound, Gender gender)
    {
        return new Animal(type, sound, gender);
    }
}
