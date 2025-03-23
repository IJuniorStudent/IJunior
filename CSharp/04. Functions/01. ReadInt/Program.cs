namespace Practice_27;

class Program
{
    static void Main(string[] args)
    {
        int userNumber = ReadInputNumber("Введите число для преобразования в целочисленный тип");
        
        Console.WriteLine($"Поздравляем! Вы успешно ввели число: {userNumber}");
    }
 
    static int ReadInputNumber(string promptMessage)
    {
        int resultNumber;
        
        while (int.TryParse(ReadConsoleInput(promptMessage), out resultNumber) == false)
            Console.WriteLine("Не удалось преобразовать ввод в число, попробуйте еще раз\n");
 
        return resultNumber;
    }
 
    static string ReadConsoleInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
}
