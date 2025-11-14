namespace PatronesComportamiento.Strategy
{
    public class DiscountPricingStrategy : IPricingStrategy
    {
        private readonly decimal _discountRate;

        public DiscountPricingStrategy(decimal discountRate)
        {
            if (discountRate < 0 || discountRate > 1) throw new ArgumentOutOfRangeException(nameof(discountRate));
            _discountRate = discountRate;
        }

        public decimal CalculatePrice(Order order)
        {
            var subtotal = order.Subtotal;
            var discount = subtotal * _discountRate;
            return subtotal - discount;
        }
    }
}