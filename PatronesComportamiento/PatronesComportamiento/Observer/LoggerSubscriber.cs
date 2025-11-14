namespace PatronesComportamiento.Observer
{
    public class LoggerSubscriber : ISubscriber
    {
        public void OnNotify(DomainEvent domainEvent)
        {
            // Simular logging
            Console.WriteLine($"[Logger] Evento registrado: {domainEvent.Name} @ {domainEvent.OccurredAt:u}");
        }
    }
}