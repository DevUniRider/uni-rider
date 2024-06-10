namespace UniRider.API.Payments.Domain.Model.ValueObjects;

public record CardVerification(string Cvv)
{
    public CardVerification() : this(string.Empty)
    {
       
    }
    
    public string Value { get; init; } = Cvv;
}