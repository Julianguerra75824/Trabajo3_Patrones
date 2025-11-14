namespace PatronesComportamiento.Observer
{
    public class EmailSubscriber : ISubscriber
    {
        private readonly string _email;

        public EmailSubscriber(string email)
        {
            _email = email;
        }

        public void OnNotify(DomainEvent domainEvent)
        {
            // Aquí iría la lógica de envío de correo; por ahora mostramos console message
            Console.WriteLine($"[EmailSubscriber({_email})] Recibió evento: {domainEvent}");
        }
    }
}