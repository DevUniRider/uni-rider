namespace UniRider.API.Payments.Domain.Model.ValueObjects;

public record ExpirationDate(DateTime Value)
{
    public ExpirationDate() : this(DateTime.MinValue)
    {
        
    }
}