
namespace OrderService;
public interface IBill
{
    decimal Total { get; }
    IEnumerable<IMenuItem> Items { get; }
}
