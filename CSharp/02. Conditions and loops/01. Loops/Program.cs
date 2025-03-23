namespace Practice_7;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите сообщение: ");
        string messageText = Console.ReadLine();
        
        Console.Write("Введите количество показов сообщения: ");
        int messageDisplayTimes = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 0; i < messageDisplayTimes; i++)
        {
            Console.WriteLine(messageText);
        }
        
        Console.ReadKey();
    }
}
