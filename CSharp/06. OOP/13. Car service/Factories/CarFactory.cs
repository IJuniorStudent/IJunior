namespace Practice_49.Factories;

public class CarFactory
{
    private CarPartFactory _carPartFactory;
    
    public CarFactory(PartFactory factory)
    {
        _carPartFactory = new CarPartFactory(factory);
    }
    
    public Queue<Car> Create()
    {
        int queueSize = 5;
        var carQueue = new Queue<Car>();
        
        for (int i = 0; i < queueSize; i++)
        {
            var car = new Car(_carPartFactory.Create());
            
            carQueue.Enqueue(car);
        }
        
        return carQueue;
    }
}
