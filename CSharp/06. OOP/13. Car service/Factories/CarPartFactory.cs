﻿namespace Practice_49.Factories;

public class CarPartFactory
{
    private List<CarPart> _parts;
    
    public CarPartFactory(NewPartFactory factory)
    {
        _parts = factory.Create();
    }
    
    public List<CarPart> Create()
    {
        var carParts = new List<CarPart>();
        
        foreach (var part in _parts)
        {
            bool isDamaged = Utils.GetRandomNumber(2) > 0;
            
            carParts.Add(new CarPart(part.Type, part.Price, isDamaged));
        }
        
        return carParts;
    }
}
