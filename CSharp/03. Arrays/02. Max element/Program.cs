namespace Practice_19;

class Program
{
    static void Main(string[] args)
    {
        int matrixRowCount = 10;
        int matrixColumnCount = 10;
        
        int randValueMin = 1;
        int randValueMax = 9;
        
        Random random = new Random();
        int[,] matrix = new int[matrixRowCount, matrixColumnCount];
        int matrixMaxValue = int.MinValue;
        
        Console.WriteLine("Исходная матрица со случайными значениями:");
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int randomValue = random.Next(randValueMin, randValueMax + 1);
                if (randomValue > matrixMaxValue)
                    matrixMaxValue = randomValue;
                
                matrix[i, j] = randomValue;
                Console.Write($"{randomValue} ");
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
        Console.WriteLine($"Наибольшее число в матрице: {matrixMaxValue}");
        
        Console.WriteLine();
        Console.WriteLine("Измененная матрица:");
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == matrixMaxValue)
                    matrix[i, j] = 0;
                
                Console.Write($"{matrix[i, j]} ");
            }
            
            Console.WriteLine();
        }
    }
}
