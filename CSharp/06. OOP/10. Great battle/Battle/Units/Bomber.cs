namespace Practice_46.Battle.Units;

public class Bomber : Soldier
{
    private int _maxTargets = 3;
    
    public Bomber() : base(70, 10, 20) { }
    
    public override void Attack(IReadOnlyList<IDamageable> possibleTargets)
    {
        IDamageable[] targets = SelectTargets(possibleTargets);
        
        foreach (var target in targets)
            target.TakeDamage(Damage);
    }
    
    public override IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets)
    {
        int rangeMax = possibleTargets.Count;
        
        int maxTargetsCount = Math.Min(_maxTargets, rangeMax);
        int firstSelectedIndex = Utils.GetRandomNumber(rangeMax);
        IDamageable[] targets = new IDamageable[maxTargetsCount];
        
        for (int i = 0; i < maxTargetsCount; i++)
            targets[i] = possibleTargets[(firstSelectedIndex + i) % rangeMax];
        
        return targets;
    }
}
