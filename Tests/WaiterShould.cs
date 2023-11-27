// Purpose: Tests the Waiter class.
namespace Tests;
using OrderService;

public class WaiterShould
{
    [Fact]
    public void ThrowExceptionForFoodNotOnMenu()
    {
        var menu = new Menu();
        var data = new List<MenuItem>(){
                new MenuItem(){Name = "Burger", Price = 5.99, Id = "1", Category = ItemCategory.Food},
                new MenuItem(){Name = "Fries", Price = 2.99, Id = "2", Category = ItemCategory.Food},
                new MenuItem(){Name = "Soda", Price = 1.99, Id = "3", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Coffee", Price = 1.99, Id = "4", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Tea", Price = 1.99, Id = "5", Category = ItemCategory.Drink}
            };
        foreach (var item in data)
        {
            menu.AddItem(item);
        }
        var waiter = new Waiter() { Menu = menu };
        Assert.Throws<Exception>(() => waiter.PlaceOrder("Not on menu", 1));
    }

    [Theory]
    [InlineData("Burger", 2, 11.98)]
    [InlineData("Burger", 1, 5.99)]
    public void CorrectlyGenerateBillForSingleItem(string itemName, int quantity, double expected)
    {
        var menu = new Menu();
        var data = new List<MenuItem>(){
                new MenuItem(){Name = "Burger", Price = 5.99, Id = "1", Category = ItemCategory.Food},
                new MenuItem(){Name = "Fries", Price = 2.99, Id = "2", Category = ItemCategory.Food},
                new MenuItem(){Name = "Soda", Price = 1.99, Id = "3", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Coffee", Price = 1.99, Id = "4", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Tea", Price = 1.99, Id = "5", Category = ItemCategory.Drink}
            };
        foreach (var item in data)
        {
            menu.AddItem(item);
        }
        var waiter = new Waiter() { Menu = menu };
        waiter.PlaceOrder(itemName, quantity);
        var bill = waiter.GetBill();
        Assert.Equal(expected, bill.Total);
    }

    [Theory]
    [InlineData(new string[] { "Burger", "Coffee" }, new int[] { 2, 1 }, 11)]
    [InlineData(new string[] { "Burger", "Coffee", "Fries" }, new int[] { 2, 1, 1 }, 13)]
    public void CorrectlyGenerateBillForMultipleItem(string[] itemNames, int[] quantities, double expected)
    {
        var menu = new Menu();
        var data = new List<MenuItem>(){
                new MenuItem(){Name = "Burger", Price = 5.00, Id = "1", Category = ItemCategory.Food},
                new MenuItem(){Name = "Fries", Price = 2.00, Id = "2", Category = ItemCategory.Food},
                new MenuItem(){Name = "Soda", Price = 1.00, Id = "3", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Coffee", Price = 1.00, Id = "4", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Tea", Price = 1.00, Id = "5", Category = ItemCategory.Drink}
            };
        foreach (var item in data)
        {
            menu.AddItem(item);
        }

        var waiter = new Waiter() { Menu = menu };
        for (int i = 0; i < itemNames.Length; i++)
        {
            waiter.PlaceOrder(itemNames[i], quantities[i]);
        }
        var bill = waiter.GetBill();
        Assert.Equal(expected, bill.Total);
    }
}