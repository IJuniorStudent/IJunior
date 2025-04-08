namespace Practice_52;

public class Patient
{
    public Patient(string name, string surname, string parentName, int age, string desease)
    {
        FullName = $"{surname} {name} {parentName}";
        Age = age;
        Desease = desease;
    }
    
    public string FullName { get; }
    public int Age { get; }
    public string Desease { get; }
    public string Summary => $"Имя: {FullName}, возраст: {Age}, заболевание: {Desease}";
}
