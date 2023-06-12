using ExtractAndOverride;
using ExtractAndOverride.Entity;
using NSubstitute;

namespace ExtractAndOverrideTests.Answer4;

[TestFixture]
public class OrderProcessorAnswer4Tests
{
    private Inventory _inventory;
    private ILog _log;

    [SetUp]
    public void SetUp()
    {
        _inventory = Substitute.For<Inventory>(); 
        _log = Substitute.For<ILog>();
    }

    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToProcessed_WhenInventoryIsSufficient()
    {
        GivenCheckInventoryShouldBe(true);

        GivenOrder().Status.Should().Be(OrderStatus.Processed);
        _log.Received(0).Information(Arg.Any<string>());
    }

    [Test]
    public void ProcessOrder_ShouldSetOrderStatusToDeny_WhenInventoryIsInsufficient()
    {
        GivenCheckInventoryShouldBe(false);
        
        GivenOrder().Status.Should().Be(OrderStatus.Deny);
        _log.Received(1).Information(Arg.Is<string>(s => s.Contains("denied")));
    }

    private void GivenCheckInventoryShouldBe(bool inventoryStatus)
    {
        _inventory.CheckInventory(Arg.Any<OrderItems>()).Returns(inventoryStatus);
    }

    private Order GivenOrder()
    {
        var orderProcessor = new OrderProcessorAnswer4(_inventory, _log);

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
        return order;
    }
}