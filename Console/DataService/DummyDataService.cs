using OrderService;

namespace DataService
{
    public class DummyDataService : IDataService
    {
        public IEnumerable<IMenuItem> LoadData()
        {
            // Implement the method here
            IEnumerable<MenuItem> data = new List<MenuItem>(){
                new MenuItem(){Name = "Burger", Price = 5.99, Id = "1", Category = ItemCategory.Food},
                new MenuItem(){Name = "Fries", Price = 2.99, Id = "2", Category = ItemCategory.Food},
                new MenuItem(){Name = "Soda", Price = 1.99, Id = "3", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Coffee", Price = 1.99, Id = "4", Category = ItemCategory.Drink},
                new MenuItem(){Name = "Tea", Price = 1.99, Id = "5", Category = ItemCategory.Drink}
            };

            return data;

        }
    }
}