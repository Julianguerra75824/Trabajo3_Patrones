namespace PatronesComportamiento.Observer
{
    public class SmsSubscriber : ISubscriber
    {
        private readonly string _phone;

        public SmsSubscriber(string phone)
        {
            _phone = phone;
        }

        public void OnNotify(DomainEvent domainEvent)
        {
            Console.WriteLine($"[SmsSubscriber({_phone})] Recibió evento: {domainEvent}");
        }
    }
}