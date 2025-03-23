namespace Practice_24;

class Program
{
    static void Main(string[] args)
    {
        string sourceMessage = "Lorem ipsum dolor sit amet";
        
        string[] messageWords = sourceMessage.Split();
        
        foreach (string word in messageWords)
            Console.WriteLine(word);
    }
}
