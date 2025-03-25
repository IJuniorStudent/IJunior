namespace Practice_46.Battle.Units;

public class Sniper : Soldier
{
    private int _damageMultiplier = 2;
    
    public Sniper() : base(60, 20, 5) { }
    
    public override void Attack(IEnumerable<IDamageable> targets)
    {
        var damage = Damage * _damageMultiplier;
        
        foreach (var target in targets)
            target.TakeDamage(damage);
    }
    
    public override IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets)
    {
        int selectRangeMin = 0;
        int selectRangeMax = possibleTargets.Count;
        
        return [ possibleTargets[Utils.GetRandomNumber(selectRangeMin, selectRangeMax)] ];
    }
}
