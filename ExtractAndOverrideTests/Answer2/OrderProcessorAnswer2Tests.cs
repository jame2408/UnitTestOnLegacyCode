using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer2;

[TestFixture]
public class OrderProcessorAnswer2Tests
{
    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToProcessed_WhenInventoryIsSufficient()
    {
        var processor = new FakeOrderProcessorAnswer2()
        {
            IsThereAnyInventory = true
        };
        var order = new Order
        {
            OrderNo = "123",
            Items = new List<OrderItems>
            {
                new() { Name = "iPhone 14", Quantity = 1 },
                new() { Name = "MacBook Pro 16", Quantity = 2 }
            }
        };
        
        processor.ProcessOrder(order);
        
        order.Status.Should().Be(OrderStatus.Processed);
    }

    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToDeny_WhenInventoryIsInsufficient()
    {
        var processor = new FakeOrderProcessorAnswer2()
        {
            IsThereAnyInventory = false
        };
        var order = new Order
        {
            OrderNo = "123",
            Items = new List<OrderItems>
            {
                new() { Name = "iPhone 14", Quantity = 1 },
                new() { Name = "MacBook Pro 16", Quantity = 2 }
            }
        };
        
        processor.ProcessOrder(order);
        
        order.Status.Should().Be(OrderStatus.Deny);
    }
}