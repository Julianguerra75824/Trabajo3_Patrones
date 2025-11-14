namespace PatronesComportamiento.Observer
{
    // Centro de notificaciones simple (Subject)
    public class NotificationCenter
    {
        private readonly List<ISubscriber> _subscribers = new();

        public void Subscribe(ISubscriber subscriber)
        {
            if (subscriber == null) return;
            if (!_subscribers.Contains(subscriber)) _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            if (subscriber == null) return;
            _subscribers.Remove(subscriber);
        }

        public void Notify(DomainEvent domainEvent)
        {
            Console.WriteLine($"[NotificationCenter] Notificando evento: {domainEvent.Name}");
            foreach (var sub in _subscribers.ToArray()) // ToArray para evitar modificación en el foreach
            {
                try
                {
                    sub.OnNotify(domainEvent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[NotificationCenter] Error notificando a {sub.GetType().Name}: {ex.Message}");
                }
            }
        }
    }
}