using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities.Customers;
using YoutubeApi.Domain.Entities.Shared;

namespace YoutubeApi.Infrastracture.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(customer => customer.Address, address =>
            {
                address.Property(address => address.FirstLineAddress)
                .IsRequired()
                .HasMaxLength(40);

                address.Property(address => address.SecondLineAddress)
                .HasMaxLength(40);

                address.Property(address => address.PostCode)
                .IsRequired()
                .HasMaxLength(10);

                address.Property(address => address.City)
                .IsRequired()
                .HasMaxLength(20);

                address.Property(address => address.Country)
                .IsRequired()
                .HasMaxLength(20);
            });

            builder.Property(customer => customer.Title)
                .HasConversion(
                title => title.Value,
                value => new Title(value))
                .IsRequired()
                .HasMaxLength(45);


            builder.Property(customer => customer.Balance)
                .HasConversion(

                balance => balance.Value,
                value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);


            builder.HasMany(customer => customer.Invoices)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
