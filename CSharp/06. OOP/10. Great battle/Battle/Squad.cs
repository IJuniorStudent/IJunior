namespace Practice_46.Battle;

using Units;

public class Squad
{
    private List<Soldier> _units;
    
    public Squad(string name, IEnumerable<Soldier> soldiers)
    {
        _units = new List<Soldier>(soldiers);
        Name = name;
    }
    
    public string Name { get; }
    public bool IsAlive => _units.Count > 0;
    public IReadOnlyList<IDamageable> Units => _units;
    
    public void Attack(IReadOnlyList<IDamageable> targets)
    {
        foreach (var soldier in _units)
            soldier.Attack(targets);
    }
    
    public void RemoveDead()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            if (_units[i].IsAlive)
                continue;
            
            _units.RemoveAt(i);
            i--;
        }
    }
}
