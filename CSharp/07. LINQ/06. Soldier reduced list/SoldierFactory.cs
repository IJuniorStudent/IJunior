namespace Practice_55;

public class SoldierFactory
{
    public List<Soldier> Create()
    {
        return new List<Soldier>
        {
            new Soldier("Тимофей", "Пистолет Макарова", "Старший сержант", 12),
            new Soldier("Арсений", "Автомат специальный Вал", "Капитан", 12),
            new Soldier("Михаил", "Автомат Калашникова", "Полковник", 12),
            new Soldier("Марк", "Снайперская винтовка Драгунова", "Лейтенант", 12),
            new Soldier("Роберт", "Лопата", "Рядовой", 12)
        };
    }
}
