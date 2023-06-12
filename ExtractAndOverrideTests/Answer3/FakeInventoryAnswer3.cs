using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer3;

public class FakeInventoryAnswer3 : Inventory
{
    public bool IsThereAnyInventory { get; init; } = true;

    public override bool CheckInventory(OrderItems item)
    {
        return IsThereAnyInventory;
    }
}