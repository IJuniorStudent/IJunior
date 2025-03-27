namespace Practice_46.Battle.Units;

public abstract class Soldier : IDamageable
{
    protected int Health;
    protected int MaxHealth;
    protected int Damage;
    protected int Armor;
    
    protected Soldier(int health, int damage, int armor)
    {
        Health = health;
        MaxHealth = health;
        Damage = damage;
        Armor = armor;
    }
    
    public bool IsAlive => Health > 0;
    
    public abstract void Attack(IReadOnlyList<IDamageable> possibleTargets);
    public abstract IDamageable[] SelectTargets(IReadOnlyList<IDamageable> possibleTargets);
    
    public virtual void TakeDamage(int damage)
    {
        if (IsAlive == false)
            return;
        
        int adjustedDamage = AdjustIncomeDamage(damage);
        int totalDamage = Math.Min(Health, adjustedDamage);
        
        Health -= totalDamage;
    }
    
    private int AdjustIncomeDamage(int damage)
    {
        int minDamage = 1;
        float maxDamageScale = 1.0f;
        
        float defenceFactor = (float)Armor / (MaxHealth + Armor);
        float damageScale = maxDamageScale - defenceFactor;
        int scaledDamage = (int)(damage * damageScale);
        
        return Math.Max(minDamage, scaledDamage);
    }
}
