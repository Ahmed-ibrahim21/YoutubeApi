using Microsoft.EntityFrameworkCore;
using YoutubeApi.Domain.Entities.Customers;
using YoutubeApi.Domain.Entities.InvoiceItems;
using YoutubeApi.Domain.Entities.Invoices;
using YoutubeApi.Domain.Entities.Products;

namespace YoutubeApi.Infrastracture
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext() { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Invoice> Invoices { get; set; } = null!;

        public DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
