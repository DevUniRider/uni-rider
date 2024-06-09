namespace UniRider.API.Payments.Domain.Model.ValueObjects;

public record CardNumber(string Cardnumber)
{
    public CardNumber() : this(string.Empty)
    {
       
    }
    public int PaymentId { get; set; }
    public string Value { get; init; } = Cardnumber;
    
}