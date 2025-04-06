namespace Practice_49.Factories;

public class NewPartFactory
{
    public List<CarPart> Create()
    {
        return new List<CarPart>([
            new CarPart("Двигатель", 100, false),
            new CarPart("Коробка передач", 100, false),
            new CarPart("Радиатор", 100, false),
            new CarPart("Аккумулятор", 100, false),
            new CarPart("ЭБУ", 100, false),
        ]);
    }
}
