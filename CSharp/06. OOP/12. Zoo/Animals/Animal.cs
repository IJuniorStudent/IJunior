namespace Practice_48.Animals;

public enum Gender
{
    Male,
    Female,
    
    Max
}

public class Animal
{
    public Animal(string type, string sound, Gender gender)
    {
        Type = type;
        Sound = sound;
        Gender = gender;
    }
    
    public string Summary => $"Тип: {Type}, пол: {Gender}, звук: {Sound}";
    
    public string Type { get; }
    public string Sound { get; }
    public Gender Gender { get; }
}
