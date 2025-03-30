namespace Practice_47;

public class FishFactory
{
    public bool TryCreate(out Fish? fish)
    {
        fish = null;
        
        if (Utils.TryReadNumberInput("Введите время жизни рыбы", out int lifetime) == false)
            return false;
        
        fish = new Fish(lifetime);
        return true;
    }
}