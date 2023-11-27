namespace OrderService;


public interface IMenuItem
{
    string Id { get; }
    string Name { get; }
    double Price { get; }
    ItemCategory Category { get; }

    // more properties like description, ingredients, allergies
}
