namespace Practice_15;

class Program
{
    static void Main(string[] args)
    {
        const int DivisorMinValue = 10;
        const int DivisorMaxValue = 25;
        
        const int FullDivideSearchRangeMin = 50;
        const int FullDivideSearchRangeMax = 150;
        
        Random random = new Random();
        int divisor = random.Next(DivisorMinValue, DivisorMaxValue + 1);
        
        Console.WriteLine($"Выбранное число в диапазоне от {DivisorMinValue} до {DivisorMaxValue}: {divisor}");
        Console.WriteLine();
        
        int rangeRemainder = FullDivideSearchRangeMin;
        while (rangeRemainder > 0)
            rangeRemainder -= divisor;
        
        int fullDivisorsCount = 0;
        
        for (int i = FullDivideSearchRangeMin - rangeRemainder; i <= FullDivideSearchRangeMax; i += divisor)
        {
            fullDivisorsCount++;
            Console.WriteLine($"Делитель {fullDivisorsCount}: {i}");
        }
        
        Console.WriteLine();
        Console.WriteLine($"Количество делителей без остатка на {divisor} в диапазоне от {FullDivideSearchRangeMin} до {FullDivideSearchRangeMax}: {fullDivisorsCount}");
    }
}
