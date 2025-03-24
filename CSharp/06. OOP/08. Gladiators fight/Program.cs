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
                    arena.InitBattle();
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
    
    public void InitBattle()
    {
        ShowWarriors();
        
        if (TrySelectWarriors(out Warrior? firstWarrior, out Warrior? secondWarrior) == false)
            return;
        
        Console.Clear();
        
        Warrior winner = StartBattle(firstWarrior, secondWarrior);
        
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
    
    private Warrior StartBattle(Warrior firstWarriorTemplate, Warrior secondWarriorTemplate)
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

class Warrior : IDamageable
{
    public Warrior(int attackDamage, int armor, int health)
    {
        AttackDamage = attackDamage;
        Armor = armor;
        Health = health;
        MaxHealth = health;
    }
    
    public int AttackDamage { get; }
    public int Armor { get; }
    public int Health { get; protected set; }
    public int MaxHealth { get; }
    
    public string Profession => GetProfessionName();
    public bool IsAlive => Health > 0;
    public string Summary => $"{GetProfessionName()} - урон: {AttackDamage}, защита: {Armor}, здоровье: {Health}. Особенность: {GetAbilityDescription()}";
    
    public void Attack(IDamageable target)
    {
        int attackDamage = GetAttackDamage();
        Console.WriteLine($"{GetProfessionName()} наносит {attackDamage} урона");
        
        target.TakeDamage(attackDamage);
    }
    
    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException();
        
        int minDamage = 0;
        
        int adjustedDamage = Math.Min(AdjustIncomeDamage(damage), Health);
        int normalizedDamage = Math.Max(adjustedDamage - Armor, minDamage);
        int totalDamage = Math.Min(normalizedDamage, Health);
 
        Health -= totalDamage;
        
        if (IsAlive)
            Console.WriteLine($"{GetProfessionName()} получает {totalDamage} ед. урона. Здоровье: {Health}");
        else
            Console.WriteLine($"{GetProfessionName()} получает {totalDamage} ед. урона и проигрывает бой");
    }
    
    public virtual Warrior MakeCopy()
    {
        throw new NotImplementedException();
    }
    
    protected virtual int GetAttackDamage()
    {
        throw new NotImplementedException();
    }
    
    protected virtual int AdjustIncomeDamage(int damage)
    {
        throw new NotImplementedException();
    }
    
    protected virtual bool TryUseAbility()
    {
        throw new NotImplementedException();
    }
    
    protected virtual string GetProfessionName()
    {
        throw new NotImplementedException();
    }
    
    protected virtual string GetAbilityDescription()
    {
        throw new NotImplementedException();
    }
}

class TwinBlade : Warrior
{
    private int _useAbilityChanceRangeMin = 0;
    private int _useAbilityChanceRangeMax = 100;
    private int _useAbilityChance = 30;
    private int _abilityAttackMultiplier = 2;
    
    public TwinBlade(int attackDamage, int armor, int health) : base(attackDamage, armor, health) { }
    
    public override TwinBlade MakeCopy()
    {
        return new TwinBlade(AttackDamage, Armor, Health);
    }
    
    protected override int GetAttackDamage()
    {
        if (TryUseAbility())
        {
            Console.WriteLine($"{GetProfessionName()} наносит урон x{_abilityAttackMultiplier}");
            return AttackDamage * _abilityAttackMultiplier;
        }
        
        return AttackDamage;
    }
    
    protected override bool TryUseAbility()
    {
        return Utils.GetRandomNumber(_useAbilityChanceRangeMin, _useAbilityChanceRangeMax) < _useAbilityChance;
    }
    
    protected override string GetProfessionName()
    {
        return "Амбидекстр";
    }
    
    protected override string GetAbilityDescription()
    {
        return $"Имеет шанс нанести урон, в {_abilityAttackMultiplier} раза превышающий базовый";
    }
}
 
class Barbarian : Warrior
{
    private int _attackNumberCounter = 0;
    private int _abilityUsePerAttacks = 3;
    private int _abilityAttackMultiplier = 2;
    
    public Barbarian(int attackDamage, int armor, int health) : base(attackDamage, armor, health) { }
    
    public override Barbarian MakeCopy()
    {
        return new Barbarian(AttackDamage, Armor, Health);
    }
    
    protected override int GetAttackDamage()
    {
        if (TryUseAbility())
        {
            Console.WriteLine($"{GetProfessionName()} наносит урон x{_abilityAttackMultiplier}");
            return AttackDamage * _abilityAttackMultiplier;
        }
        
        return AttackDamage;
    }
    
    protected override bool TryUseAbility()
    {
        if (++_attackNumberCounter % _abilityUsePerAttacks != 0)
            return false;
        
        _attackNumberCounter = 0;
        return true;
    }
    
    protected override string GetProfessionName()
    {
        return "Варвар";
    }
    
    protected override string GetAbilityDescription()
    {
        return $"Каждую {_abilityUsePerAttacks} атаку наносит x{_abilityAttackMultiplier} урон";
    }
}

class Paladin : Warrior
{
    private int _furyLevel = 0;
    private int _furyLevelMax = 100;
    private int _furyIncreasePerHit = 15;
    private int _healthRestoreAmount = 40;
    
    public Paladin(int attackDamage, int armor, int health) : base(attackDamage, armor, health) { }
    
    public override Paladin MakeCopy()
    {
        return new Paladin(AttackDamage, Armor, Health);
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
    
    protected override string GetProfessionName()
    {
        return "Паладин";
    }
    
    protected override string GetAbilityDescription()
    {
        return $"Накапливает {_furyIncreasePerHit} ед. ярости при получении урона. " +
               $"При достижении {_furyLevelMax} ед. ярости использует лечение на {_healthRestoreAmount} ед. здоровья " +
               $"и сбрасывает уровень ярости.";
    }
    
    private void Heal()
    {
        if (Health == MaxHealth)
            return;
        
        int healAmount = Math.Min(Health + _healthRestoreAmount, MaxHealth);
        Console.WriteLine($"{GetProfessionName()} лечится на {healAmount} ед.");
        
        Health += healAmount;
    }
}

class Warlock : Warrior
{
    private int _mana = 100;
    private int _fireballManaCost = 25;
    private int _fireballDamageMultiplier = 10;
    
    public Warlock(int attackDamage, int armor, int health) : base(attackDamage, armor, health) { }
    
    public override Warlock MakeCopy()
    {
        return new Warlock(AttackDamage, Armor, Health);
    }
    
    protected override int GetAttackDamage()
    {
        if (TryUseAbility())
        {
            Console.WriteLine($"{GetProfessionName()} использует огненный шар");
            return AttackDamage * _fireballDamageMultiplier;
        }
        
        return AttackDamage;
    }
    
    protected override bool TryUseAbility()
    {
        if (_mana < _fireballManaCost)
            return false;
        
        _mana -= _fireballManaCost;
        return true;
    }
    
    protected override string GetProfessionName()
    {
        return "Чернокнижник";
    }
    
    protected override string GetAbilityDescription()
    {
        return $"Наносит x{_fireballDamageMultiplier} урона заклинанием \"Огненный шар\", пока есть мана. " +
               $"Всего маны: {_mana}, затраты маны на заклинание: {_fireballManaCost}";
    }
}

class Trickster : Warrior
{
    private int _useAbilityChanceRangeMin = 0;
    private int _useAbilityChanceRangeMax = 100;
    private int _useAbilityChance = 30;
    
    public Trickster(int attackDamage, int armor, int health) : base(attackDamage, armor, health) { }
    
    public override Trickster MakeCopy()
    {
        return new Trickster(AttackDamage, Armor, Health);
    }
    
    protected override int AdjustIncomeDamage(int damage)
    {
        if (TryUseAbility())
        {
            Console.WriteLine($"{GetProfessionName()} уклоняется от атаки");
            return 0;
        }
        
        return damage;
    }
    
    protected override bool TryUseAbility()
    {
        return Utils.GetRandomNumber(_useAbilityChanceRangeMin, _useAbilityChanceRangeMax) < _useAbilityChance;
    }
    
    protected override string GetProfessionName()
    {
        return "Ловкач";
    }
    
    protected override string GetAbilityDescription()
    {
        return $"Имеет шанс уклониться от удара";
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
