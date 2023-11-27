namespace OrderService;

public class MenuItem : IMenuItem
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Id { get; set; }
    public ItemCategory Category { get; set; }
}