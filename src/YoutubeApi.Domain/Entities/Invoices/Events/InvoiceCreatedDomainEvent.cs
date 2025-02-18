using YoutubeApi.Domain.Abstraction;

namespace YoutubeApi.Domain.Entities.Invoices.Events
{
    public record InvoiceCreatedDomainEvent(Guid InvoiceId) : IDomainEvent;
}
