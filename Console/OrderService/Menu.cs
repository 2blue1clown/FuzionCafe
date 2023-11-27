namespace OrderService;

public class Menu : IMenu
{
    private readonly IList<IMenuItem> _menuItems = new List<IMenuItem>();

    public void AddItem(IMenuItem item)
    {
        (_menuItems as List<IMenuItem>)?.Add(item);
    }

    public IEnumerable<IMenuItem> Items => _menuItems;
}