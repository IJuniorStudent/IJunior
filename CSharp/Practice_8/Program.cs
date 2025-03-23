namespace Practice_8;

class Program
{
    static void Main(string[] args)
    {
        string commandExit = "exit";
        string loopMessage = $"Программа выполняется. Для выхода введите \"{commandExit}\"\n> ";
        
        Console.Write(loopMessage);
        
        while (Console.ReadLine() != commandExit)
        {
            Console.Write(loopMessage);
        }
        
        Console.WriteLine("Программа завершена");
    }
}
