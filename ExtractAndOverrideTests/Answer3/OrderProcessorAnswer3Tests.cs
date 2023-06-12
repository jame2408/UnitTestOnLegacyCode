using ExtractAndOverride;
using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer3;

[TestFixture]
public class OrderProcessorAnswer3Tests
{
    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToProcessed_WhenInventoryIsSufficient()
    {
        var fakeInventory = new FakeInventoryAnswer3()
        {
            IsThereAnyInventory = true
        };
        var orderProcessor = new OrderProcessorAnswer3(fakeInventory);
        var order = new Order
        {
            OrderNo = "123",
            Items = new List<OrderItems>
            {
                new() { Name = "item1", Quantity = 1 },
                new() { Name = "item2", Quantity = 2 },
                new() { Name = "item3", Quantity = 3 }
            }
        };
        
        orderProcessor.ProcessOrder(order);
        
        order.Status.Should().Be(OrderStatus.Processed);
    }

    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToDeny_WhenInventoryIsInsufficient()
    {
    }
}