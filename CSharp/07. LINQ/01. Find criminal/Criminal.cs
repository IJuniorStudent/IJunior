namespace Practice_50;

public class Criminal
{
    public Criminal(string fullName, int height, int weight, string origin, bool isJailed)
    {
        FullName = fullName;
        Height = height;
        Weight = weight;
        Origin = origin;
        IsJailed = isJailed;
    }

    public string Summary => $"{FullName}. Рост: {Height}, вес: {Weight}, национальность: {Origin}";
    
    public string FullName { get; }
    public int Height { get; }
    public int Weight { get; }
    public string Origin { get; }
    public bool IsJailed { get; }
}
