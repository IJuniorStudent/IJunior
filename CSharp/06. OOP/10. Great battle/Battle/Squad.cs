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
        var removeCandidates = new List<Soldier>();
        
        foreach (var soldier in _units)
            if (soldier.IsAlive == false)
                removeCandidates.Add(soldier);
        
        foreach (var soldier in removeCandidates)
            _units.Remove(soldier);
    }
}
