namespace PatronesComportamiento.Strategy
{
    public class RegularPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(Order order)
        {
            // Solo devuelve subtotal
            return order.Subtotal;
        }
    }

    // Contexto opcional pero útil para encapsular uso
    public class PricingContext
    {
        private IPricingStrategy _strategy;

        public PricingContext(IPricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IPricingStrategy strategy) => _strategy = strategy;

        public decimal Calculate(Order order) => _strategy.CalculatePrice(order);
    }
}