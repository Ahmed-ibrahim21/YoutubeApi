using YoutubeApi.Domain.Abstraction;
using YoutubeApi.Domain.Entities.Customers.DTOs;
using YoutubeApi.Domain.Entities.Customers.Events;
using YoutubeApi.Domain.Entities.Customers.ValueObject;
using YoutubeApi.Domain.Entities.Shared;

namespace YoutubeApi.Domain.Entities.Customers
{
    public sealed class Customer : BaseEntity
    {
        private Customer(Title title, Address address, Money balance)
        {
            Title = title;
            Address = address;
            Balance = balance;
        }

        private Customer()
        {
            
        }

        public Title Title { get; private set; } = null!;

        public Address Address { get; private set; } = null!;

        public Money Balance { get; private set; } = null!;

        //invoices will be located here. Search_for_needed


        public static Customer Create(CreateCustomerDto request)
        {
            var customer = new Customer(
                new Title(request.Title),
                new Address(
                    request.FirstLineAddress,
                    request.SecondLineAddress,
                    request.PostCode,
                    request.City,
                    request.Country), new Money(0));

            customer.RaiseDomainEvent(new CustomerCreatedDomainEvent(customer.Id));

            return customer;
        }
    }
}
