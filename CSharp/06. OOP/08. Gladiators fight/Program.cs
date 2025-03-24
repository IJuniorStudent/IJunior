namespace Practice_44;

class Program
{
    static void Main(string[] args)
    {
        const string CommandWatchBattle = "1";
        const string CommandExit = "2";
        
        BattleArena arena = new BattleArena();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine("Приветствуем на боевой арене!");
            Console.WriteLine();
            Console.WriteLine($"{CommandWatchBattle}. Посмотреть бой");
            Console.WriteLine($"{CommandExit}. Выход");
            Console.WriteLine();
            
            string userInput = Utils.ReadUserInput("Выберите опцию");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandWatchBattle:
                    arena.PerformFight();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage($"Неизвестная опция: \"{userInput}\"");
                    break;
            }
        }
    }
}

class BattleArena
{
    private List<Warrior> _warriors;
    
    public BattleArena()
    {
        _warriors = new List<Warrior>();
        
        InitWarriors();
    }
    
    public void PerformFight()
    {
        ShowWarriors();
        
        if (TrySelectWarriors(out Warrior? firstWarrior, out Warrior? secondWarrior) == false)
            return;
        
        Console.Clear();
        
        Warrior winner = Fight(firstWarrior, secondWarrior);
        
        Utils.PrintWaitMessage($"Бой окончен. Победитель: {winner.Profession}");
    }
    
    private void InitWarriors()
    {
        _warriors.AddRange([
            new TwinBlade(20, 10, 100),
            new Barbarian(25, 5, 100),
            new Paladin(15, 15, 100),
            new Warlock(3, 5, 100),
            new Trickster(15, 10, 100),
        ]);
    }
    
    private bool TrySelectWarriors(out Warrior? firstOrderWarrior, out Warrior? secondOrderWarrior)
    {
        firstOrderWarrior = null;
        secondOrderWarrior = null;
        
        return TrySelectWarrior("Укажите номер первого бойца", out firstOrderWarrior) &&
               TrySelectWarrior("Укажите номер второго бойца", out secondOrderWarrior);
    }
    
    private Warrior Fight(Warrior firstWarriorTemplate, Warrior secondWarriorTemplate)
    {
        Warrior firstWarrior = firstWarriorTemplate.MakeCopy();
        Warrior secondWarrior = secondWarriorTemplate.MakeCopy();
        
        while (firstWarrior.IsAlive && secondWarrior.IsAlive)
        {
            firstWarrior.Attack(secondWarrior);
            Console.WriteLine();
            
            if (secondWarrior.IsAlive)
            {
                secondWarrior.Attack(firstWarrior);
                Console.WriteLine();
            }
        }
        
        return firstWarrior.IsAlive ? firstWarrior : secondWarrior;
    }
    
    private void ShowWarriors()
    {
        Console.WriteLine("Доступные бойцы");
        
        for (int i = 0; i < _warriors.Count; i++)
            Console.WriteLine($"{i + 1}. {_warriors[i].Summary}");
    }
    
    private bool TrySelectWarrior(string promptMessage, out Warrior? warrior)
    {
        warrior = null;
        
        if (Utils.TryReadNumberInput(promptMessage, out int number) == false)
            return false;
        
        int warriorIndex = number - 1;
        
        if (warriorIndex < 0 || warriorIndex >= _warriors.Count)
        {
            Utils.PrintWaitMessage($"Нет бойца под номерм {number}");
            return false;
        }
        
        warrior = _warriors[warriorIndex];
        return true;
    }
}

interface IDamageable
{
    public void TakeDamage(int damage);
}

abstract class Warrior : IDamageable
{
    public Warrior(int damage, int armor, int health)
    {
        Damage = damage;
        Armor = armor;
        Health = health;
        MaxHealth = health;
    }
    
    public int Damage { get; }
    public int Armor { get; }
    public int Health { get; protected set; }
    public int MaxHealth { get; }
    public bool IsAlive => Health > 0;
    public string Summary => $"{Profession} - урон: {Damage}, защита: {Armor}, здоровье: {Health}. Особенность: {Ability}";
    
    public abstract string Profession { get; }
    public abstract string Ability { get; }
    
    public void Attack(IDamageable target)
    {
        int attackDamage = AdjustAttackDamage();
        Console.WriteLine($"{Profession} наносит {attackDamage} урона");
        
        target.TakeDamage(attackDamage);
    }
    
    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException();
        
        int minDamage = 0;
        
        int adjustedDamage = AdjustIncomeDamage(damage);
        int normalizedDamage = Math.Max(adjustedDamage - Armor, minDamage);
        int totalDamage = Math.Min(normalizedDamage, Health);
 
        Health -= totalDamage;
        
        if (IsAlive)
            Console.WriteLine($"{Profession} получает {totalDamage} ед. урона. Здоровье: {Health}");
        else
            Console.WriteLine($"{Profession} получает {totalDamage} ед. урона и проигрывает бой");
    }
    
    public abstract Warrior MakeCopy();
    
    protected virtual int AdjustAttackDamage()
    {
        return Damage;
    }
    
    protected virtual int AdjustIncomeDamage(int damage)
    {
        return damage;
    }
    
    protected abstract bool TryUseAbility();
}

class TwinBlade : Warrior
{
    private int _useAbilityChanceRangeMin = 0;
    private int _useAbilityChanceRangeMax = 100;
    private int _useAbilityChance = 30;
    private int _abilityAttackMultiplier = 2;
    
    public TwinBlade(int damage, int armor, int health) : base(damage, armor, health) { }
 
    public override string Profession => "Амбидекстр";
    public override string Ability => $"Имеет шанс нанести урон, в {_abilityAttackMultiplier} раза превышающий базовый";
    
    public override TwinBlade MakeCopy()
    {
        return new TwinBlade(Damage, Armor, Health);
    }
    
    protected override int AdjustAttackDamage()
    {
        if (TryUseAbility() == false)
            return Damage;
        
        Console.WriteLine($"{Profession} наносит урон x{_abilityAttackMultiplier}");
        return Damage * _abilityAttackMultiplier;
    }
    
    protected override bool TryUseAbility()
    {
        return Utils.GetRandomNumber(_useAbilityChanceRangeMin, _useAbilityChanceRangeMax) < _useAbilityChance;
    }
}
 
class Barbarian : Warrior
{
    private int _attackNumberCounter = 0;
    private int _abilityUsePerAttacks = 3;
    private int _abilityAttackMultiplier = 2;
    
    public Barbarian(int damage, int armor, int health) : base(damage, armor, health) { }
 
    public override string Profession => "Варвар";
    public override string Ability => $"Каждую {_abilityUsePerAttacks} атаку наносит x{_abilityAttackMultiplier} урон";
    
    public override Barbarian MakeCopy()
    {
        return new Barbarian(Damage, Armor, Health);
    }
    
    protected override int AdjustAttackDamage()
    {
        if (TryUseAbility() == false)
            return Damage;
        
        Console.WriteLine($"{Profession} наносит урон x{_abilityAttackMultiplier}");
        return Damage * _abilityAttackMultiplier;
    }
    
    protected override bool TryUseAbility()
    {
        if (++_attackNumberCounter % _abilityUsePerAttacks != 0)
            return false;
        
        _attackNumberCounter = 0;
        return true;
    }
}

class Paladin : Warrior
{
    private int _furyLevel = 0;
    private int _furyLevelMax = 100;
    private int _furyIncreasePerHit = 15;
    private int _healthRestoreAmount = 40;
    
    public Paladin(int damage, int armor, int health) : base(damage, armor, health) { }
 
    public override string Profession => "Паладин";
    public override string Ability =>
        $"Накапливает {_furyIncreasePerHit} ед. ярости при получении урона. " +
        $"При достижении {_furyLevelMax} ед. ярости использует лечение на {_healthRestoreAmount} ед. здоровья " +
        $"и сбрасывает уровень ярости.";
    
    public override Paladin MakeCopy()
    {
        return new Paladin(Damage, Armor, Health);
    }
    
    protected override int AdjustIncomeDamage(int damage)
    {
        if (TryUseAbility())
            Heal();
        
        return damage;
    }
    
    protected override bool TryUseAbility()
    {
        if (IsAlive == false)
            return false;
        
        _furyLevel += _furyIncreasePerHit;
        
        if (_furyLevel < _furyLevelMax)
            return false;
        
        _furyLevel = 0;
        return true;
    }
    
    private void Heal()
    {
        if (Health == MaxHealth)
            return;
        
        int healAmount = Math.Min(Health + _healthRestoreAmount, MaxHealth);
        Console.WriteLine($"{Profession} лечится на {healAmount} ед.");
        
        Health += healAmount;
    }
}

class Warlock : Warrior
{
    private int _mana = 100;
    private int _fireballManaCost = 25;
    private int _fireballDamageMultiplier = 10;
    
    public Warlock(int damage, int armor, int health) : base(damage, armor, health) { }
    
    public override string Profession => "Чернокнижник";
    public override string Ability => 
        $"Наносит x{_fireballDamageMultiplier} урона заклинанием \"Огненный шар\", пока есть мана. " +
        $"Всего маны: {_mana}, затраты маны на заклинание: {_fireballManaCost}";
    
    public override Warlock MakeCopy()
    {
        return new Warlock(Damage, Armor, Health);
    }
    
    protected override int AdjustAttackDamage()
    {
        if (TryUseAbility() == false)
            return Damage;
        
        Console.WriteLine($"{Profession} использует огненный шар");
        return Damage * _fireballDamageMultiplier;
    }
    
    protected override bool TryUseAbility()
    {
        if (_mana < _fireballManaCost)
            return false;
        
        _mana -= _fireballManaCost;
        return true;
    }
}

class Trickster : Warrior
{
    private int _useAbilityChanceRangeMin = 0;
    private int _useAbilityChanceRangeMax = 100;
    private int _useAbilityChance = 30;
    
    public Trickster(int damage, int armor, int health) : base(damage, armor, health) { }
    
    public override string Profession => "Ловкач";
    public override string Ability => "Имеет шанс уклониться от удара";
    
    public override Trickster MakeCopy()
    {
        return new Trickster(Damage, Armor, Health);
    }
    
    protected override int AdjustIncomeDamage(int damage)
    {
        if (TryUseAbility() == false)
            return damage;
        
        Console.WriteLine($"{Profession} уклоняется от атаки");
        return 0;
    }
    
    protected override bool TryUseAbility()
    {
        return Utils.GetRandomNumber(_useAbilityChanceRangeMin, _useAbilityChanceRangeMax) < _useAbilityChance;
    }
}

class Utils
{
    private static Random s_random = new();
    
    public static int GetRandomNumber(int min, int max)
    {
        return s_random.Next(min, max + 1);
    }
    
    public static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    public static bool TryReadNumberInput(string promptMessage, out int number)
    {
        if (int.TryParse(ReadUserInput(promptMessage), out number) == false)
        {
            PrintWaitMessage("Ввведено некорректное число");
            return false;
        }
        
        return true;
    }
    
    public static void PrintWaitMessage(string message)
    {
        Console.WriteLine(message);
        
        WaitAnyKeyPress();
    }
    
    public static void WaitAnyKeyPress()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey(true);
    }
}
