namespace Practice_49.Factories;

public class PartFactory
{
    public List<Part> Create()
    {
        return new List<Part>([
            new Part("Двигатель", 100),
            new Part("Коробка передач", 100),
            new Part("Радиатор", 100),
            new Part("Аккумулятор", 100),
            new Part("ЭБУ", 100),
        ]);
    }
}
