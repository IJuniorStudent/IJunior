namespace Practice_5;

class Program
{
    static void Main(string[] args)
    {
        int gemPrice = 10;
        
        Console.Write("Введите количество вашего золота: ");
        int goldAmount = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Напишите, сколько кристаллов вы хотите купить: ");
        int gemCount = Convert.ToInt32(Console.ReadLine());
        
        goldAmount -= gemCount * gemPrice;
        
        Console.WriteLine($"Куплено кристаллов: {gemCount}");
        Console.WriteLine($"Осталось золота: {goldAmount}");
        Console.ReadKey();
    }
}
