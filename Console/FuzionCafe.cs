using DataService;
using OrderService;

namespace AppService;


public class FuzionCafe
{

    private readonly IWaiter _waiter;
    private readonly IDataService _dataService;

    public FuzionCafe(IWaiter waiter, IDataService dataService)
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

    public void ReceiveCustomer()
    {
        bool finished = false;
        Console.WriteLine("Welcome to the restaurant!");
        Console.WriteLine("Here is the menu:");
        //TODO: Sort into categories
        foreach (var item in _waiter.Menu.Items)
        {
            Console.WriteLine($"{item.Name} - ${item.Price}");
        }
        while (!finished)
        {
            _waiter.TakeOrder();
            Console.WriteLine("Would you like to order anything else? (y/n)");
            var response = Console.ReadLine();
            if (response == "n")
            {
                finished = true;
            }
        }

        var bill = _waiter.GetBill();
        Console.WriteLine($"Thank you for your order. Here is your bill:");
        //print items in bill order
        foreach (var item in bill.order)
        {
            Console.WriteLine($"{item.Name} x {item.Quantity} (${item.Price} each)\t.... {item.Price * item.Quantity} ");
        }
        Console.WriteLine($"Your bill is ${bill.Total}");
    }

}