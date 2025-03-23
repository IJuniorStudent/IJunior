namespace Practice_17;

class Program
{
    static void Main(string[] args)
    {
        const string CommandMeleeAttack = "1";
        const string CommandCastSkillFireball = "2";
        const string CommandCastSkillBlast = "3";
        const string CommandUseHealPotion = "4";
        
        Random random = new Random();
        
        int bossHealth = 500;
        int bossAttackDamageMin = 15;
        int bossAttackDamageMax = 40;
        int bossRoundAttackDamage = random.Next(bossAttackDamageMin, bossAttackDamageMax);
        
        int playerMaxHealth = 100;
        int playerMaxMana = 100;
        int playerHealth = playerMaxHealth;
        int playerMana = playerMaxMana;
        
        int playerMeleeAttackDamage = 10;
        
        int playerSkillFireballDamage = 75;
        int playerSkillFireballManaConsume = 15;
        
        int playerSkillBlastDamage = 125;
        int playerSkillBlastManaConsume = 15;
        
        int healPotionHealthRecover = 35;
        int healPotionManaRecover = 35;
        int healPotionAmount = 5;
        
        bool canPlayerCastSkillBlast = false;
        string playerCommand = "";
        string lastActionLogMessage = "";
        
        while (playerHealth > 0 && bossHealth > 0)
        {
            if (canPlayerCastSkillBlast && playerCommand != CommandCastSkillFireball)
                canPlayerCastSkillBlast = false;
            
            Console.Clear();
            Console.WriteLine(lastActionLogMessage);
            Console.WriteLine();
            Console.WriteLine($"[Босс]  Здоровье: {bossHealth} | Сила атаки: {bossRoundAttackDamage}");
            Console.WriteLine($"[Игрок] Здоровье: {playerHealth} | Мана: {playerMana}");
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine($"{CommandMeleeAttack}. Обычная атака. Урон: {playerMeleeAttackDamage}");
            Console.WriteLine($"{CommandCastSkillFireball}. Применить умение \"Огненный шар\". Урон: {playerSkillFireballDamage}. Затраты маны: {playerSkillFireballManaConsume}");
            Console.Write($"{CommandCastSkillBlast}. Применить умение \"Взрыв\". Урон: {playerSkillBlastDamage}. Затраты маны: {playerSkillBlastManaConsume}");
            
            if (canPlayerCastSkillBlast)
                Console.WriteLine();
            else
                Console.WriteLine(" (недоступно. Сначала примените навык \"Огненный шар\")");
            
            Console.WriteLine($"{CommandUseHealPotion}. Использовать зелье восстановления. Восст. здоровья: {healPotionHealthRecover}. Восст. маны: {healPotionManaRecover}. (Осталось {healPotionAmount} шт.)");
            Console.Write("> ");
            
            playerCommand = Console.ReadLine();
            
            switch (playerCommand)
            {
                case CommandMeleeAttack:
                    bossHealth -= playerMeleeAttackDamage;
                    lastActionLogMessage = $"Вы нанесли боссу {playerMeleeAttackDamage} урона.";
                    break;
                
                case CommandCastSkillFireball:
                    if (playerMana >= playerSkillFireballManaConsume)
                    {
                        canPlayerCastSkillBlast = true;
                        playerMana -= playerSkillFireballManaConsume;
                        bossHealth -= playerSkillFireballDamage;
                        lastActionLogMessage = $"Огненный шар нанес боссу {playerSkillFireballDamage} урона.";
                    }
                    else
                    {
                        lastActionLogMessage = "Не хватило маны для создания огненного шара.";
                    }
                    break;
                
                case CommandCastSkillBlast:
                    if (canPlayerCastSkillBlast)
                    {
                        if (playerMana >= playerSkillBlastManaConsume)
                        {
                            playerMana -= playerSkillBlastManaConsume;
                            bossHealth -= playerSkillBlastDamage;
                            lastActionLogMessage = $"Взрыв нанес боссу {playerSkillBlastDamage} урона.";
                        }
                        else
                        {
                            lastActionLogMessage = "Не хватило маны для взрыва огненного шара.";
                        }
                    }
                    else
                    {
                        lastActionLogMessage = "Не удалось взорвать огненный шар по причине его отсутствия.";
                    }
                    break;
                
                case CommandUseHealPotion:
                    if (healPotionAmount > 0)
                    {
                        healPotionAmount--;
                        
                        int recoverHealthPoints = Math.Min(playerMaxHealth - playerHealth, healPotionHealthRecover);
                        int recoverManaPoints = Math.Min(playerMaxMana - playerMana, healPotionManaRecover);
                        
                        playerHealth += recoverHealthPoints;
                        playerMana += recoverManaPoints;
 
                        lastActionLogMessage = $"Вы восстановили {recoverHealthPoints} ед. здоровья и {recoverManaPoints} ед. маны.";
                    }
                    else
                    {
                        lastActionLogMessage = "У вас закончились зелья восстановления.";
                    }
                    break;
                
                default:
                    lastActionLogMessage = "Вы споткнулись при замахе.";
                    break;
            }
            
            if (bossHealth > 0)
            {
                playerHealth -= bossRoundAttackDamage;
                lastActionLogMessage += $" Босс нанес вам {bossRoundAttackDamage} урона.";
            }
        }
        
        Console.Clear();
        Console.WriteLine(lastActionLogMessage);
        Console.WriteLine();
        
        if (playerHealth <= 0)
            Console.WriteLine($"Увы! Вы проиграли. У босса осталось еще {bossHealth} ед. здоровья");
        else if (bossHealth <= 0)
            Console.WriteLine("Вам удалось одолеть босса!");
    }
}
