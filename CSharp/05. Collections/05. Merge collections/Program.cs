namespace Practice_36;

class Program
{
    static void Main(string[] args)
    {
        string[] firstValues = ["1", "2", "1"];
        string[] secondValues = ["3", "2"];
        
        List<string> uniqueValues = new List<string>();
        
        AppendUniqueValues(uniqueValues, firstValues);
        AppendUniqueValues(uniqueValues, secondValues);
        
        PrintList(uniqueValues);
    }
    
    static void AppendUniqueValues(List<string> targetList, string[] sourceValues)
    {
        foreach (string value in sourceValues)
        {
            if (targetList.Contains(value))
                continue;
            
            targetList.Add(value);
        }
    }
    
    static void PrintList(List<string> list)
    {
        foreach (var value in list)
            Console.Write($"{value} ");
    }
}
