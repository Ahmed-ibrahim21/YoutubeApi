namespace YoutubeApi.Domain.Entities.Customers.ValueObject
{
    public record Address(
        string FirstLineAddress,
        string? SecondLineAddress,
        string PostCode,
        string City,
        string Country);
}
