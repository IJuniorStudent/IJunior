namespace Practice_13;

class Program
{
    static void Main(string[] args)
    {
        const int BoxBorderWidth = 1;
        
        Console.Write("Введите ваше имя: ");
        string userName = Console.ReadLine();
        
        Console.Write("Введите символ, котороым будет нарисована рамка: ");
        char borderChar = Console.ReadLine()[0];
        
        int userNameLength = userName.Length;
        
        for (int i = 0; i < BoxBorderWidth; i++)
        {
            for (int j = 0; j < userNameLength + BoxBorderWidth + BoxBorderWidth; j++)
                Console.Write(borderChar);
            
            Console.WriteLine();
        }
        
        for (int i = 0; i < BoxBorderWidth; i++)
            Console.Write(borderChar);
        
        Console.Write(userName);
        
        for (int i = 0; i < BoxBorderWidth; i++)
            Console.Write(borderChar);
        
        Console.WriteLine();
        
        for (int i = 0; i < BoxBorderWidth; i++)
        {
            for (int j = 0; j < userNameLength + BoxBorderWidth + BoxBorderWidth; j++)
                Console.Write(borderChar);
            
            Console.WriteLine();
        }
    }
}
