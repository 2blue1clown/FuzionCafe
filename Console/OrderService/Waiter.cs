namespace OrderService;

public class Waiter : IWaiter
{
    public Menu Menu { get; set; }

    private Dictionary<string, IItemOrderInfo> _order = new();

    public void PlaceOrder(string itemName, int quantity)
    {
        //check that the order is in menu
        var item = Menu.Items.FirstOrDefault(x => x.Name.ToLower() == itemName.ToLower(), null);
        if (item == null)
        {
            throw new Exception("Item not found in menu");
        }
        //check if the order is already in the order
        if (_order.ContainsKey(itemName))
        {
            _order[itemName].Quantity += quantity;
        }
        else
        {
            _order.Add(itemName, new ItemOrderInfo()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = quantity
            });
        }
    }

    public IBill GetBill()
    {
        return new Bill(_order.Values);
    }


}