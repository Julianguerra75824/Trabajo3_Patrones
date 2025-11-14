namespace PatronesComportamiento.Observer
{
    public abstract class DomainEvent
    {
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
        public string Name => GetType().Name;
    }

    public class OrderPlacedEvent : DomainEvent
    {
        public string OrderId { get; }
        public decimal Amount { get; }

        public OrderPlacedEvent(string orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }

        public override string ToString() => $"OrderPlaced(OrderId={OrderId}, Amount={Amount:C})";
    }

    public class InventoryLowEvent : DomainEvent
    {
        public string ProductId { get; }
        public int CurrentStock { get; }

        public InventoryLowEvent(string productId, int currentStock)
        {
            ProductId = productId;
            CurrentStock = currentStock;
        }

        public override string ToString() => $"InventoryLow(ProductId={ProductId}, CurrentStock={CurrentStock})";
    }
}