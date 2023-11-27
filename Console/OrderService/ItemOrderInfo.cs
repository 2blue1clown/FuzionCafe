namespace OrderService;

public record ItemOrderInfo : IItemOrderInfo
{
    public string Id { get; init; }
    public string Name { get; init; }
    public double Price { get; init; }
    public int Quantity { get; set; }
    public double Total
    {
        get
        {
            return Price * Quantity;
        }
    }
}