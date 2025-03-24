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
        
        Fight(firstWarrior, secondWarrior);
        Warrior winner = SelectWinner(firstWarrior, secondWarrior);
        
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
    
    private void Fight(Warrior firstWarrior, Warrior secondWarrior)
    {
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
    }
    
    private Warrior SelectWinner(Warrior firstWarrior, Warrior secondWarrior)
    {
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
        
        warrior = _warriors[warriorIndex].MakeCopy();
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
    public string Summary => $"{Profession} - урон: {Damage}, защита: {Armor}, здоровье: {Health}. Особенность: {AbilityDescription}";
    
    public abstract string Profession { get; }
    public abstract string AbilityDescription { get; }
    
    public abstract Warrior MakeCopy();
    public abstract void Attack(IDamageable target);
    public abstract void TakeDamage(int damage);
    
    protected int NormalizeDamage(int damage)
    {
        int minDamage = 0;
        
        return Math.Clamp(damage - Armor, minDamage, Health);
    }
    
    protected void DisplayAttackMessage(int damage)
    {
        Console.WriteLine($"{Profession} наносит {damage} ед. урона");
    }
    
    protected void DisplayDamageMessage(int damage)
    {
        Console.WriteLine($"{Profession} получает {damage} ед. урона. Здоровье: {Health}");
    }
}

class TwinBlade : Warrior
{
    private int _abilityChanceMin = 0;
    private int _abilityChanceMax = 100;
    private int _abilityApplyChance = 30;
    private int _abilityAttackMultiplier = 2;
    
    public TwinBlade(int damage, int armor, int health) : base(damage, armor, health) { }
 
    public override string Profession => "Амбидекстр";
    public override string AbilityDescription => $"Имеет шанс нанести урон, в {_abilityAttackMultiplier} раза превышающий базовый";
    
    public override TwinBlade MakeCopy()
    {
        return new TwinBlade(Damage, Armor, Health);
    }
    
    public override void Attack(IDamageable target)
    {
        int damage = CalculateHitDamage(Damage);
        DisplayAttackMessage(damage);
        
        target.TakeDamage(damage);
    }
    
    public override void TakeDamage(int damage)
    {
        int incomeDamage = NormalizeDamage(damage);
        Health -= incomeDamage;
        
        DisplayDamageMessage(incomeDamage);
    }
    
    private int CalculateHitDamage(int damage)
    {
        if (Utils.GetRandomNumber(_abilityChanceMin, _abilityChanceMax) >= _abilityApplyChance)
            return damage;
        
        Console.WriteLine($"{Profession} использует свою особенность и наносит x{_abilityAttackMultiplier} урона");
        
        return damage * _abilityAttackMultiplier;
    }
}
 
class Barbarian : Warrior
{
    private int _attackNumberCounter = 0;
    private int _abilityApplyPerHitCount = 3;
    private int _abilityDamageMultiplier = 2;
    
    public Barbarian(int damage, int armor, int health) : base(damage, armor, health) { }
 
    public override string Profession => "Варвар";
    public override string AbilityDescription => $"Каждую {_abilityApplyPerHitCount} атаку наносит x{_abilityDamageMultiplier} урон";
    
    public override Barbarian MakeCopy()
    {
        return new Barbarian(Damage, Armor, Health);
    }
    
    public override void Attack(IDamageable target)
    {
        int damage = CalculateHitDamage(Damage);
        DisplayAttackMessage(damage);
        
        target.TakeDamage(damage);
    }
    
    public override void TakeDamage(int damage)
    {
        int incomeDamage = NormalizeDamage(damage);
        Health -= incomeDamage;
        
        DisplayDamageMessage(incomeDamage);
    }
    
    private int CalculateHitDamage(int damage)
    {
        if (++_attackNumberCounter % _abilityApplyPerHitCount != 0)
            return damage;
        
        _attackNumberCounter = 0;
        
        Console.WriteLine($"{Profession} применяет особенность и наносит x{_abilityDamageMultiplier} урона");
        
        return damage * _abilityDamageMultiplier;
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
    public override string AbilityDescription =>
        $"Накапливает {_furyIncreasePerHit} ед. ярости при получении урона. " +
        $"При достижении {_furyLevelMax} ед. ярости использует лечение на {_healthRestoreAmount} ед. здоровья " +
        $"и сбрасывает уровень ярости.";
    
    public override Paladin MakeCopy()
    {
        return new Paladin(Damage, Armor, Health);
    }
    
    public override void Attack(IDamageable target)
    {
        DisplayAttackMessage(Damage);
        
        target.TakeDamage(Damage);
    }
    
    public override void TakeDamage(int damage)
    {
        if (TryApplyAbility())
            Heal();
        
        int incomeDamage = NormalizeDamage(damage);
        Health -= incomeDamage;
        
        DisplayDamageMessage(incomeDamage);
    }
    
    private bool TryApplyAbility()
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
    public override string AbilityDescription => 
        $"Наносит x{_fireballDamageMultiplier} урона заклинанием \"Огненный шар\", пока есть мана. " +
        $"Всего маны: {_mana}, затраты маны на заклинание: {_fireballManaCost}";
    
    public override Warlock MakeCopy()
    {
        return new Warlock(Damage, Armor, Health);
    }
    
    public override void Attack(IDamageable target)
    {
        int damage = CalculateHitDamage(Damage);
        DisplayAttackMessage(damage);
        
        target.TakeDamage(damage);
    }
    
    public override void TakeDamage(int damage)
    {
        int incomeDamage = NormalizeDamage(damage);
        Health -= incomeDamage;
        
        DisplayDamageMessage(incomeDamage);
    }
    
    private int CalculateHitDamage(int damage)
    {
        if (_mana < _fireballManaCost)
            return damage;
        
        _mana -= _fireballManaCost;
        
        Console.WriteLine($"{Profession} атакует заклинанием \"Огненный шар\"");
        
        return Damage * _fireballDamageMultiplier;
    }
}

class Trickster : Warrior
{
    private int _abilityChanceRangeMin = 0;
    private int _abilityChanceRangeMax = 100;
    private int _abilityApplyChance = 30;
    
    public Trickster(int damage, int armor, int health) : base(damage, armor, health) { }
    
    public override string Profession => "Ловкач";
    public override string AbilityDescription => "Имеет шанс уклониться от удара";
    
    public override Trickster MakeCopy()
    {
        return new Trickster(Damage, Armor, Health);
    }
    
    public override void Attack(IDamageable target)
    {
        DisplayAttackMessage(Damage);
        
        target.TakeDamage(Damage);
    }
    
    public override void TakeDamage(int damage)
    {
        int incomeDamage = CalculateIncomeDamage(NormalizeDamage(damage));
        
        if (incomeDamage == 0)
            return;
        
        Health -= incomeDamage;
        
        DisplayDamageMessage(incomeDamage);
    }
    
    private int CalculateIncomeDamage(int damage)
    {
        if (Utils.GetRandomNumber(_abilityChanceRangeMin, _abilityChanceRangeMax) >= _abilityApplyChance)
            return damage;
        
        Console.WriteLine($"{Profession} уклоняется от удара");
        
        return 0;
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
