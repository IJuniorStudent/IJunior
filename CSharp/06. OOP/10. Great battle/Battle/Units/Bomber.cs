namespace Practice_46.Battle.Units;

public class Bomber : Soldier
{
    private int _maxTargets = 3;
    
    public Bomber() : base(70, 10, 20) { }
    
    public override void Attack(IEnumerable<IDamageable> targets)
    {
        foreach (var target in targets)
            target.TakeDamage(Damage);
    }
    
    public override IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets)
    {
        int selectRangeMin = 0;
        int selectRangeMax = possibleTargets.Count;
        
        int maxSelectTargets = Math.Min(_maxTargets, selectRangeMax);
        int firstSelectedIndex = Utils.GetRandomNumber(selectRangeMin, selectRangeMax);
        IDamageable[] targets = new IDamageable[maxSelectTargets];
        
        for (int i = 0; i < maxSelectTargets; i++)
            targets[i] = possibleTargets[(firstSelectedIndex + i) % selectRangeMax];
        
        return targets;
    }
}
