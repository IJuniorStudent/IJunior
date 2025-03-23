namespace Practice_9;

class Program
{
    static void Main(string[] args)
    {
        int sequenceStartNumber = 5;
        int sequenceMaxNumber = 103;
        int sequenceStepIncrement = 7;
 
        for (int i = sequenceStartNumber; i <= sequenceMaxNumber; i += sequenceStepIncrement)
        {
            Console.WriteLine(i);
        }
    }
}
