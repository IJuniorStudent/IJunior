namespace Practice_18;

class Program
{
    static void Main(string[] args)
    {
        int [,] matrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        int rowIndex = 1;
        int columnIndex = 0;
        
        int rowSum = 0;
        int columnMult = 1;
        
        Console.WriteLine("Исходная матрица");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
        
        for (int i = 0; i < matrix.GetLength(1); i++)
            rowSum += matrix[rowIndex, i];
        
        for (int i = 0; i < matrix.GetLength(0); i++)
            columnMult *= matrix[i, columnIndex];
        
        Console.WriteLine($"Сумма элементов для строки {rowIndex + 1}: {rowSum}");
        Console.WriteLine($"Произведение элементов для колонки {columnIndex + 1}: {columnMult}");
    }
}
