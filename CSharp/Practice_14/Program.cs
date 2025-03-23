namespace Practice_14;

class Program
{
    static void Main(string[] args)
    {
        string unlockPassword = "secrets";
        int inputPasswordAttemptsMaxCount = 3;
        
        for (int i = 0; i < inputPasswordAttemptsMaxCount; i++)
        {
            Console.Write("Введите пароль для разблокировки: ");
            
            if (Console.ReadLine() == unlockPassword)
            {
                Console.WriteLine("Секретики!");
                break;
            }
            
            Console.WriteLine("Неверный пароль");
        }
    }
}
