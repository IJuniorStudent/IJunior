namespace Practice_45;

public class Utils
{
    private static Random s_random = new Random();
    
    public static int GetRandomNumber(int rangeMax)
    {
        int rangeMin = 0;
        
        return GetRandomNumber(rangeMin, rangeMax);
    }
    
    public static int GetRandomNumber(int rangeMin, int rangeMax)
    {
        return s_random.Next(rangeMin, rangeMax);
    }
}
