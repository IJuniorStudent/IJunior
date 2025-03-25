namespace Practice_46.Battle;

using Units;

public class Squad
{
    private List<Soldier> _soldiers;
    
    public Squad(string name)
    {
        _soldiers = new List<Soldier>();
        Name = name;
    }
    
    public string Name { get; }
    public bool IsAlive => _soldiers.Count > 0;
    
    public void AddSoldiers(IEnumerable<Soldier> soldiers)
    {
        _soldiers.AddRange(soldiers);
    }
    
    public void Attack(Squad targetSquad)
    {
        foreach (var soldier in _soldiers)
            targetSquad.TakeDamage(soldier);
    }
    
    private void TakeDamage(Soldier attacker)
    {
        if (IsAlive == false)
            return;
        
        var targets = attacker.SelectTargets(_soldiers);
        attacker.Attack(targets);
        
        foreach (var target in targets)
        {
            var soldier = (Soldier)target;
            
            if (soldier.IsAlive == false)
                _soldiers.Remove(soldier);
        }
    }
}
