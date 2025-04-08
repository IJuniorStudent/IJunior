namespace Practice_51;

public class CriminalsFactory
{
    public List<Criminal> Create()
    {
        return new List<Criminal>
        {
            new Criminal("Thomas Shelby", "Антиправительственное"),
            new Criminal("Michael Scofield", "Ограбление банка"),
            new Criminal("Dovahkiin", "Находился рядом с Ульфриком Буревестником"),
            new Criminal("Nathan Drake", "Антиправительственное")
        };
    }
}
