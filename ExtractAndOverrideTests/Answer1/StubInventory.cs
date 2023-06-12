using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer1;

internal class StubInventory : Inventory
{
    public Dictionary<OrderItems, bool> InventoryResults { get; init; } = new();

    public override bool CheckInventory(OrderItems item)
    {
        // Return the value from the dictionary, if it exists
        if (InventoryResults.TryGetValue(item, out var result))
        {
            return result;
        }

        // If the item is not in the dictionary, assume there is inventory
        return true;
    }
}