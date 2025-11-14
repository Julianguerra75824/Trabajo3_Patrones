namespace PatronesComportamiento.Strategy
{
    public class OrderItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }

        public OrderItem(string name, int quantity, decimal unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal Total => Quantity * UnitPrice;
    }

    public class Order
    {
        private readonly List<OrderItem> _items = new();

        public IReadOnlyList<OrderItem> Items => _items;

        public void AddItem(string name, int quantity, decimal unitPrice)
        {
            _items.Add(new OrderItem(name, quantity, unitPrice));
        }

        public decimal Subtotal => _items.Sum(i => i.Total);
    }
}