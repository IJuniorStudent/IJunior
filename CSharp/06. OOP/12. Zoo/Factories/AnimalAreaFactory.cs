namespace Practice_48.Factories;

using Animals;

public class AnimalAreaFactory
{
    private struct AnimalConfig
    {
        public string Type;
        public string Sound;
        
        public AnimalConfig(string type, string sound)
        {
            Type = type;
            Sound = sound;
        }
    }
    
    private List<AnimalConfig> _animalsConfig;
    
    public AnimalAreaFactory()
    {
        _animalsConfig = InitAnimalConfigs();
    }
    
    public List<AnimalArea> Create()
    {
        var factory = new AnimalFactory();
        var areas = new List<AnimalArea>();
        int animalsCount = 5;
        
        for (int i = 0; i < _animalsConfig.Count; i++)
        {
            AnimalConfig animalConfig = _animalsConfig[i];
            
            areas.Add(CreateArea(factory, ref animalConfig, animalsCount));
        }
        
        return areas;
    }
    
    private AnimalArea CreateArea(AnimalFactory factory, ref readonly AnimalConfig config, int animalCount)
    {
        var animals = new List<Animal>();
        
        for (int i = 0; i < animalCount; i++)
        {
            Gender gender = (Gender)Utils.GetRandomNumber((int)Gender.Max);
            
            animals.Add(factory.Create(config.Type, config.Sound, gender));
        }
        
        return new AnimalArea(animals);
    }
    
    private List<AnimalConfig> InitAnimalConfigs()
    {
        return new List<AnimalConfig>([
            new AnimalConfig("Deer", "Bellow"),
            new AnimalConfig("Capybara", "Squeak"),
            new AnimalConfig("Koala", "Shriek"),
            new AnimalConfig("Lemur", "Chatter"),
            new AnimalConfig("Parrot", "Squawk")
        ]);
    }
}
