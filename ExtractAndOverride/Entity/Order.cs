namespace ExtractAndOverride.Entity;

public class Order
{
    public string OrderNo { get; init; }
    public List<OrderItems> Items { get; init; }
    public OrderStatus Status { get; private set; }

    // ... other properties

    public bool IsValid()
    {
        return string.IsNullOrEmpty(OrderNo) == false && Items.Any();
    }

    public void SetStatus(OrderStatus status)
    {
        Status = status;
    }
}