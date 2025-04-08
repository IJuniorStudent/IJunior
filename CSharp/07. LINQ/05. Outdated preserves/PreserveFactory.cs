namespace Practice_54;

public class PreserveFactory
{
    public List<Preserve> Create()
    {
        return new List<Preserve>
        {
            new Preserve("Тушеная говядина", 2000, 10),
            new Preserve("Тушеная свинина", 2000, 12),
            new Preserve("Тушеная курица", 2024, 7),
            new Preserve("Тушеная индейка", 2020, 5),
            new Preserve("Тушеный мамонт", 500, 15),
        };
    }
}
