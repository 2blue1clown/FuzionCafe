using DataService;
using OrderService;

namespace AppService;

// Should be only responsible for the Console interactions and flow not the business logic
public class ConsoleCafe
{

    private readonly IWaiter _waiter;
    private readonly IDataService _dataService;

    private bool finished = false;

    public ConsoleCafe(IWaiter waiter, IDataService dataService)
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
        Welcome();
        while (!finished)
        {
            TakeOrder();
            CheckIfFinished();
        }
        PresentBill();
    }

    void PresentBill()
    {
        var bill = _waiter.GetBill();
        Console.WriteLine($"Thank you for your order. Here is your bill:");
        //print items in bill order
        foreach (var item in bill.order)
        {
            Console.WriteLine($"{item.Name} x {item.Quantity} (${item.Price} each)\t.... {item.Price * item.Quantity} ");
        }
        Console.WriteLine();
        Console.WriteLine($"Total:\t${bill.Total:0.00}");
    }

    void Welcome()
    {
        Console.WriteLine("Welcome to the restaurant!");
        Console.WriteLine("Here is the menu:\n");
        //TODO: Sort into categories
        var categories = _waiter.Menu.Items.GroupBy(x => x.Category);
        foreach (var category in categories)
        {
            Console.WriteLine($"_{category.Key}");
            foreach (var item in category)
            {
                Console.WriteLine($"{item.Name} - ${item.Price}");
            }
            Console.WriteLine();
        }
    }

    string ChooseItem()
    {
        string? item = null;
        while (item == null)
        {

            Console.WriteLine("What item would you like to order?");
            var itemName = Console.ReadLine();
            if (itemName == null)
            {
                Console.WriteLine("We didn't get that. Please try again.");
                continue;
            }
            // check if item is in menu
            item = _waiter.Menu.Items.Select(x => x.Name).FirstOrDefault(x => x.ToLower() == itemName.ToLower(), null);
            if (item == null)
            {
                Console.WriteLine("Sorry, that item is not on the menu. Please make sure you type the menu item exactly as it appears.");
                continue;
            }
        }
        return item;
    }

    int ChooseQuantity()
    {
        int? quantity = null;
        while (quantity == null)
        {
            Console.WriteLine("How many would you like?");
            var quantityString = Console.ReadLine();
            if (quantityString == null)
            {
                Console.WriteLine("We didn't get that. Please try again.");
                continue;
            }
            // try to pass to valid int
            if (!int.TryParse(quantityString, out int quantityInt))
            {
                Console.WriteLine("Sorry, that is not a valid quantity. Please enter an integer.");
                continue;
            }
            quantity = quantityInt;

        }
        return (int)quantity;

    }
    void TakeOrder()
    {
        string itemName = ChooseItem();
        int quantity = ChooseQuantity();
        _waiter.PlaceOrder(itemName, quantity);
    }

    void CheckIfFinished()
    {
        Console.WriteLine("Would you like to order anything else? (y/n)");
        var response = Console.ReadLine();
        if (response == "n")
        {
            finished = true;
        }
    }

}