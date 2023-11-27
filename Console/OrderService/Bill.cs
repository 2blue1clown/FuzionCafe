namespace OrderService;

public record Bill : IBill
{
    public Bill(IEnumerable<IItemOrderInfo> order)
    {
        this.order = order;
    }
    public double Total
    {
        get
        {
            double total = 0;
            foreach (var item in order)
            {
                total += item.Total;
            }
            return total;
        }
    }
    public IEnumerable<IItemOrderInfo> order { get; init; }
}