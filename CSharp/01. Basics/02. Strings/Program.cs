using System.Text;

namespace Practice_2;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        
        Console.Write("Как вас зовут: ");
        string userName = Console.ReadLine();
        
        Console.Write("Сколько вам лет: ");
        int userAge = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Кто вы по знаку зодиака: ");
        string zodiacName = Console.ReadLine();
        
        Console.Write("Где вы работаете: ");
        string workName = Console.ReadLine();
        
        Console.WriteLine($"Вас зовут {userName}, вам {userAge}, вы {zodiacName} и работаете {workName}.");
        Console.ReadKey();
    }
}
