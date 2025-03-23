namespace Practice_16;

class Program
{
    static void Main(string[] args)
    {
        int randomNumberRangeMin = 0;
        int randomNumberRangeMax = 100000;
        int baseValue = 2;
        
        Random random = new Random();
        int randomNumber = random.Next(randomNumberRangeMin, randomNumberRangeMax + 1);
        
        int powerOfBase = 1;
        int searchValue = baseValue;
        
        while (searchValue <= randomNumber)
        {
            searchValue *= baseValue;
            powerOfBase++;
        }
        
        Console.WriteLine($"Случайно выбранное значение: {randomNumber}");
        Console.WriteLine($"Значение, превосходящее выбранное: {searchValue}");
        Console.WriteLine($"Степень числа {baseValue}: {powerOfBase}");
    }
}
