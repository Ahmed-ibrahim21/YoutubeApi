﻿using YoutubeApi.Domain.Abstraction;
using YoutubeApi.Domain.Entities.InvoiceItems.ValueObjects;
using YoutubeApi.Domain.Entities.Invoices;
using YoutubeApi.Domain.Entities.Shared;

namespace YoutubeApi.Domain.Entities.InvoiceItems
{
    public sealed class InvoiceItem : BaseEntity
    {

        private InvoiceItem() { }
        internal InvoiceItem(
            Guid id,
            Money sellPrice,
            Quantity quantity,
            Guid invoiceId
            ) : base(id)
        {
            SellPrice = sellPrice;
            Quantity = quantity;
            TotalPrice = new Money(SellPrice.Value * Quantity.Value);
            InvoiceId = invoiceId;
        }

        public Money SellPrice { get; private set; } = null!;
        public Quantity Quantity { get; private set; } = null!;

        public Money TotalPrice { get; private set; } = null!;

        public Guid InvoiceId { get; private set; }

        public Invoice Invoice { get; private set; } = null!;
    }
}
