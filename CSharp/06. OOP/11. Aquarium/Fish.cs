namespace Practice_47;

public class Fish
{
    private int _lifetime;
    private int _maxLifetime;
    
    public Fish(int maxLifetime)
    {
        int startLifetime = 0;
        
        _lifetime = startLifetime;
        _maxLifetime = maxLifetime;
    }
    
    public bool IsAlive => _lifetime < _maxLifetime;
    public string Summary => $"Возраст: {_lifetime}, макс. возраст: {_maxLifetime}";
    
    public void Update()
    {
        UpdateLifetime();
    }

    private void UpdateLifetime()
    {
        if (_lifetime >= _maxLifetime)
            return;
        
        _lifetime += 1;
    }
}