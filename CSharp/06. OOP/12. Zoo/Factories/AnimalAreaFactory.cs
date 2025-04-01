namespace Practice_48.Factories;

using Animals;

public class AnimalAreaFactory
{
    private List<AnimalFactory> _factories;
    
    public AnimalAreaFactory()
    {
        _factories = InitFactoryList();
    }
    
    public List<Animal> CreateAnimals(int animalCount)
    {
        var animals = new List<Animal>();
        
        for (int i = 0; i < animalCount; i++)
        {
            AnimalFactory factory = _factories[Utils.GetRandomNumber(_factories.Count)];
            Gender gender = (Gender)Utils.GetRandomNumber((int)Gender.Max);
            
            animals.Add(factory.Create(gender));
        }
        
        return animals;
    }
    
    private List<AnimalFactory> InitFactoryList()
    {
        return new List<AnimalFactory>([
            new DeerFactory(),
            new CapybaraFactory(),
            new KoalaFactory(),
            new LemurFactory(),
            new ParrotFactory()
        ]);
    }
}
