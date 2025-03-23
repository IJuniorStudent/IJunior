namespace Practice_7;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите сообщение: ");
        string displayMessage = Console.ReadLine();
        
        Console.Write("Введите количество повторов сообщения: ");
        int repeatCount = Convert.ToInt32(Console.ReadLine());
        
        while (repeatCount-- > 0)
        {
            Console.WriteLine($"Сообщение: {displayMessage}");
        }
        
        Console.ReadKey();
    }
}
