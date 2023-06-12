using ExtractAndOverride;
using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer1;

internal class StubOrderProcessorAnswer1 : OrderProcessorAnswer1
{
    public Dictionary<OrderItems, bool> CheckInventoryResult { get; init; } = new();

    protected override Inventory GetInventory()
    {
        var stubInventory = new StubInventory()
        {
            InventoryResults = CheckInventoryResult
        };
        return stubInventory;
    }
}