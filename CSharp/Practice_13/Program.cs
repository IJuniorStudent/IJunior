namespace Practice_13;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите ваше имя: ");
        string userName = Console.ReadLine();
        
        Console.Write("Введите символ, котороым будет нарисована рамка: ");
        char borderChar = Console.ReadLine()[0];
        
        string userNameBordered = $"{borderChar}{userName}{borderChar}";
        string border = "";
        
        for (int i = 0; i < userNameBordered.Length; i++)
            border += borderChar;
        
        Console.WriteLine(border);
        Console.WriteLine(userNameBordered);
        Console.WriteLine(border);
    }
}
