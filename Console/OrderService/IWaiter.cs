
namespace OrderService;

public interface IWaiter
{
    void PlaceOrder(string order);

    IBill GetBill();


}

