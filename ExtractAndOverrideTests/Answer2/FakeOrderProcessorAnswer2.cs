using ExtractAndOverride;
using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer2;

public class FakeOrderProcessorAnswer2 : OrderProcessorAnswer2
{
    public bool IsThereAnyInventory { get; init; } = true;

    protected override bool CheckInventory(OrderItems item)
    {
        return IsThereAnyInventory;
    }
}