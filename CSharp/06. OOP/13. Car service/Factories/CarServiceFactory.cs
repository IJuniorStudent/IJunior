namespace Practice_49.Factories;

public class CarServiceFactory
{
    public CarService Create()
    {
        var partsFactory = new PartFactory();
        
        var partStorageFactory = new PartStorageFactory(partsFactory);
        var carFactory = new CarFactory(partsFactory);
        
        return new CarService(partStorageFactory, carFactory, 500, 40, 1000);
    }
}
