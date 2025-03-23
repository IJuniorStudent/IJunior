namespace Practice_36;

class Program
{
    static void Main(string[] args)
    {
        List<string> firstList = ["1", "2", "1"];
        List<string> secondList = ["3", "2"];
        
        List<string> uniqueValueList = MergeUniqueValues([firstList, secondList]);
        
        PrintList(uniqueValueList);
    }
    
    static List<string> MergeUniqueValues(List<List<string>> sourceLists)
    {
        var mergedList = new List<string>();
        
        foreach (var sourceList in sourceLists)
        {
            foreach (var value in sourceList)
            {
                if (mergedList.Contains(value))
                    continue;
                
                mergedList.Add(value);
            }
        }
        
        return mergedList;
    }
    
    static void PrintList(List<string> list)
    {
        foreach (var value in list)
            Console.Write($"{value} ");
    }
}
