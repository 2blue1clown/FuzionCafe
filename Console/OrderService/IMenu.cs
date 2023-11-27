namespace OrderService;

public interface IMenu
{
    IEnumerable<IMenuItem> Items { get; }

    void AddItem(IMenuItem item);
}