
namespace OrderService;

public interface IWaiter
{
    Menu Menu { get; set; }
    void PlaceOrder(string order, int quantity);


    IBill GetBill();


}

