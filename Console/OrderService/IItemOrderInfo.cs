namespace OrderService;

public interface IItemOrderInfo
{
    string Id { get; }
    string Name { get; }
    double Price { get; }
    int Quantity { get; set; }
    double Total { get; }
}


