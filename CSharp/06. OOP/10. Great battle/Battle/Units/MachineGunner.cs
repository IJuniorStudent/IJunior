namespace Practice_46.Battle.Units;

public class MachineGunner : Soldier
{
    private int _maxTargets = 3;
    
    public MachineGunner() : base(90, 10, 15) { }
    
    public override void Attack(IReadOnlyList<IDamageable> possibleTargets)
    {
        var targets = SelectTargets(possibleTargets);
        
        foreach (var target in targets)
            target.TakeDamage(Damage);
    }
    
    public override IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets)
    {
        int selectRangeMin = 0;
        int selectRangeMax = possibleTargets.Count;
        
        IDamageable[] targets = new IDamageable[_maxTargets];
        
        for (int i = 0; i < _maxTargets; i++)
            targets[i] = possibleTargets[Utils.GetRandomNumber(selectRangeMin, selectRangeMax)];
        
        return targets;
    }
}
