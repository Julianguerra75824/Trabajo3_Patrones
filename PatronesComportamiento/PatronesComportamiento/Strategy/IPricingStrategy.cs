namespace PatronesComportamiento.Strategy
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(Order order);
    }
}