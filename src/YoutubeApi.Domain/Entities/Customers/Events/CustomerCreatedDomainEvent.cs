using YoutubeApi.Domain.Abstraction;

namespace YoutubeApi.Domain.Entities.Customers.Events
{
    public record CustomerCreatedDomainEvent(Guid customerId) : IDomainEvent;
}
