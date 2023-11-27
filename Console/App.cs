using DataService;
using OrderService;

namespace AppService;


public class App
{

    private readonly IWaiter _waiter;
    private readonly IDataService _dataService;

    public App(IWaiter waiter, IDataService dataService)
    {
        _dataService = dataService;
        var menu = new Menu();
        foreach (var item in _dataService.LoadData())
        {
            menu.AddItem(item);
        }
        _waiter = waiter;
        _waiter.Menu = menu;


    }

    public void Run()
    {
        Console.WriteLine("Welcome to the restaurant!");
        Console.WriteLine("Here is the menu:");
        foreach (var item in _waiter.Menu.Items)
        {
            Console.WriteLine($"{item.Name} - {item.Price}");
        }

        Console.WriteLine("What would you like to order?");
        var order = Console.ReadLine();
        _waiter.PlaceOrder(order);
        var bill = _waiter.GetBill();
        Console.WriteLine($"Your bill is {bill.Total}");
    }
}