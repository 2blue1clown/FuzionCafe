
namespace OrderService;
public interface IBill
{
    double Total { get; }
    IEnumerable<IItemOrderInfo> order { get; }
}

