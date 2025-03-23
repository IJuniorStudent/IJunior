namespace Practice_4;

class Program
{
    static void Main(string[] args)
    {
        string firstName = "Пупкин";
        string lastName = "Василий";
        
        string leftCup = "Кофе";
        string rightCup = "Чай";
        
        Console.WriteLine($"Данные до перестановки. Имя: {firstName}, Фамилия: {lastName}");
        Console.WriteLine($"Содержимое до перестановки. Левая чашка: {leftCup}, правая чашка: {rightCup}");
        Console.WriteLine();
        
        (firstName, lastName) = (lastName, firstName);
        (leftCup, rightCup) = (rightCup, leftCup);
 
        Console.WriteLine($"Данные после перестановки. Имя: {firstName}, Фамилия: {lastName}");
        Console.WriteLine($"Содержимое после перестановки. Левая чашка: {leftCup}, правая чашка: {rightCup}");
    }
}
