using ExtractAndOverride.Entity;

namespace ExtractAndOverrideTests.Answer1;

public class OrderProcessorAnswer1Tests
{
    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToProcessed_WhenInventoryIsSufficient()
    {
        // Arrange
        var (item1, item2, item3) = GivenGetOrderItems();
        var orderProcessor = GivenStubOrderProcessor(new Dictionary<OrderItems, bool>()
        {
            { item1, true },
            { item2, true },
            { item3, true }
        });
        var order = GivenOrder(item1, item2, item3);

        // Act
        orderProcessor.ProcessOrder(order);

        // Assert
        order.Status.Should().Be(OrderStatus.Processed);
    }

    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToDeny_WhenInventoryIsInsufficient()
    {
        // Arrange
        var (item1, item2, item3) = GivenGetOrderItems();
        var orderProcessor = GivenStubOrderProcessor(new Dictionary<OrderItems, bool>()
        {
            { item1, true },
            { item2, true },
            { item3, false }
        });
        var order = GivenOrder(item1, item2, item3);

        // Act
        orderProcessor.ProcessOrder(order);

        // Assert
        order.Status.Should().Be(OrderStatus.Deny);
    }

    private static Order GivenOrder(OrderItems item1, OrderItems item2, OrderItems item3)
    {
        return new Order
        {
            OrderNo = "123",
            Items = new List<OrderItems> { item1, item2, item3 }
        };
    }

    private StubOrderProcessorAnswer1 GivenStubOrderProcessor(Dictionary<OrderItems, bool> checkInventoryResult)
    {
        return new StubOrderProcessorAnswer1()
        {
            CheckInventoryResult = checkInventoryResult
        };
    }

    private (OrderItems item1, OrderItems item2, OrderItems item3) GivenGetOrderItems()
    {
        var item1 = new OrderItems()
        {
            Name = "iPhone 14",
            Quantity = 2
        };
        var item2 = new OrderItems()
        {
            Name = "MacBook Pro 16",
            Quantity = 1
        };
        var item3 = new OrderItems()
        {
            Name = "iPad Pro 12.9",
            Quantity = 3
        };
        return (item1, item2, item3);
    }
}