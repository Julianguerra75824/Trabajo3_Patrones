namespace PatronesComportamiento.Observer
{
    public interface ISubscriber
    {
        void OnNotify(DomainEvent domainEvent);
    }
}