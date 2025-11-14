using PatronesComportamiento.Observer;
using PatronesComportamiento.Strategy;

namespace PatronesComportamiento
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== DEMO: Strategy (Cálculo de precio) ===\n");
            StrategyDemo.Run();

            Console.WriteLine("\n=== DEMO: Observer (Notificaciones de eventos) ===\n");
            ObserverDemo.Run();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }

    internal static class StrategyDemo
    {
        public static void Run()
        {
            var order = new Order();
            order.AddItem("Camisa", 2, 25.00m);
            order.AddItem("Pantalón", 1, 40.00m);

            // Usar precio regular
            var pricing = new PricingContext(new RegularPricingStrategy());
            Console.WriteLine($"Total (Regular): {pricing.Calculate(order):C}");

            // Cambiar a descuento promocional
            pricing.SetStrategy(new DiscountPricingStrategy(0.10m)); // 10% descuento
            Console.WriteLine($"Total (Promo 10%): {pricing.Calculate(order):C}");

            // Aplicar estrategia con impuestos incluidos por región
            pricing.SetStrategy(new TaxInclusivePricingStrategy(0.19m)); // 19% IVA
            Console.WriteLine($"Total (Impuesto 19%): {pricing.Calculate(order):C}");
        }
    }

    internal static class ObserverDemo
    {
        public static void Run()
        {
            var notificationCenter = new NotificationCenter();

            var email = new EmailSubscriber("ventas@tienda.com");
            var sms = new SmsSubscriber("+573001112233");
            var logger = new LoggerSubscriber();

            notificationCenter.Subscribe(email);
            notificationCenter.Subscribe(sms);
            notificationCenter.Subscribe(logger);

            // Simular evento: pedido realizado
            var orderEvent = new OrderPlacedEvent(orderId: "ORD-1001", amount: 90.00m);
            notificationCenter.Notify(orderEvent);

            // Simular evento: inventario bajo
            var invEvent = new InventoryLowEvent(productId: "PROD-200", currentStock: 3);
            notificationCenter.Notify(invEvent);

            // remover un subscriber y notificar de nuevo
            notificationCenter.Unsubscribe(sms);
            Console.WriteLine("\n--- SMS unsubscribed ---\n");
            notificationCenter.Notify(new OrderPlacedEvent("ORD-1002", 150.25m));
        }
    }
}