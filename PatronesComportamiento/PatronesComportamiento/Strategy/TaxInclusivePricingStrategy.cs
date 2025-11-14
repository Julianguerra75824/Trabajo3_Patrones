namespace PatronesComportamiento.Strategy
{
    public class TaxInclusivePricingStrategy : IPricingStrategy
    {
        private readonly decimal _taxRate;

        public TaxInclusivePricingStrategy(decimal taxRate)
        {
            if (taxRate < 0 || taxRate > 1) throw new ArgumentOutOfRangeException(nameof(taxRate));
            _taxRate = taxRate;
        }

        public decimal CalculatePrice(Order order)
        {
            var subtotal = order.Subtotal;
            var tax = subtotal * _taxRate;
            return subtotal + tax;
        }
    }
}