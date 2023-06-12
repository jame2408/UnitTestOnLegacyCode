using ExtractAndOverride.Entity;

namespace ExtractAndOverride;

public class OrderProcessorAnswer1
{
    public void ProcessOrder(Order order)
    {
        if (!order.IsValid())
        {
            throw new Exception("Invalid order.");
        }

        var inventory = GetInventory();
        var result = order
            .Items
            .Select(item => inventory.CheckInventory(item)).ToList();

        order.SetStatus(
            result.Any(a => a == false)
                ? OrderStatus.Deny
                : OrderStatus.Processed);
    }

    protected virtual Inventory GetInventory()
    {
        return new Inventory();
    }
}