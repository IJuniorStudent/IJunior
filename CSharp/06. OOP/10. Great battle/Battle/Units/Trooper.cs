namespace Practice_46.Battle.Units;

public class Trooper : Soldier
{
    public Trooper() : base(100, 20, 10) { }
    
    public override void Attack(IEnumerable<IDamageable> targets)
    {
        foreach (var target in targets)
            target.TakeDamage(Damage);
    }
    
    public override IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets)
    {
        int selectRangeMin = 0;
        int selectRangeMax = possibleTargets.Count;
        
        return [ possibleTargets[Utils.GetRandomNumber(selectRangeMin, selectRangeMax)] ];
    }
}
