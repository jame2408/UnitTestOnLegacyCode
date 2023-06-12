using ExtractAndOverride.Entity;

namespace ExtractAndOverride;

public class OrderProcessorAnswer3
{
    private readonly Inventory _inventory;

    // Legacy code
    public OrderProcessorAnswer3()
    {
        _inventory = new Inventory();
    }

    public OrderProcessorAnswer3(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void ProcessOrder(Order order)
    {
        if (!order.IsValid())
        {
            throw new Exception("Invalid order.");
        }

        // 這裡的 new Inventory() 是一個依賴，我們要如何把它抽離出來，
        var result = order
            .Items
            .Select(item => _inventory.CheckInventory(item)).ToList();

        // order 的狀態是由 result 決定的，我們要如何讓 result 的值可以被我們控制，
        // 讓我們可以測試 order 的狀態是否正確？
        order.SetStatus(
            result.Any(a => a == false)
                ? OrderStatus.Deny
                : OrderStatus.Processed);
    }
}