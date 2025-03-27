namespace Practice_46.Battle.Units;

public class Trooper : Soldier
{
    public Trooper() : base(100, 20, 10) { }
    
    public override void Attack(IReadOnlyList<IDamageable> possibleTargets)
    {
        IDamageable[] targets = SelectTargets(possibleTargets);
        
        foreach (var target in targets)
            target.TakeDamage(Damage);
    }
    
    public override IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets)
    {
        return [ possibleTargets[Utils.GetRandomNumber(possibleTargets.Count)] ];
    }
}
