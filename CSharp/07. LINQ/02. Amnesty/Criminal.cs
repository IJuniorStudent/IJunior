namespace Practice_51;

public class Criminal
{
    public Criminal(string fullName, string jailReason)
    {
        FullName = fullName;
        JailReason = jailReason;
    }
    
    public string FullName { get; }
    public string JailReason { get; }
    public string Summary => $"Имя: {FullName}, преступление: {JailReason}";
}