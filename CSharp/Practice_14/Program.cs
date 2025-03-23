namespace Practice_14;

class Program
{
    static void Main(string[] args)
    {
        string unlockPassword = "secrets";
        int inputPasswordAttemptsRemain = 3;
 
        while (--inputPasswordAttemptsRemain >= 0)
        {
            Console.Write("Введите пароль для разблокировки: ");
            if (Console.ReadLine() == unlockPassword)
                break;
            
            Console.WriteLine("Неверный пароль");
        }
 
        if (inputPasswordAttemptsRemain >= 0)
            Console.WriteLine("Секретики!");
    }
}
