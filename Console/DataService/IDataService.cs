using OrderService;

namespace DataService;

public interface IDataService
{
    IEnumerable<IMenuItem> LoadData();
}