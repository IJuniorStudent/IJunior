namespace Practice_27;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число для преобразования в целочисленный тип");
        
        int userNumber = ReadInputNumber();
        
        Console.WriteLine($"Поздравляем! Вы успешно ввели число: {userNumber}");
    }
 
    static int ReadInputNumber()
    {
        while (true)
        {
            Console.Write("> ");
            
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;
            
            Console.WriteLine("Не удалось преобразовать ввод в число, попробуйте еще раз");
        }
    }
}
