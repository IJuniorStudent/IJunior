namespace Practice_46;

public class Utils
{
    private static Random s_random = new Random();
    
    public static int GetRandomNumber(int rangeMax)
    {
        return s_random.Next(rangeMax);
    }
}
