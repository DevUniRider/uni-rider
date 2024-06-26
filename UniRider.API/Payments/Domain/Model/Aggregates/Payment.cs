using UniRider.API.Payments.Domain.Model.Commands;
using UniRider.API.Payments.Domain.Model.ValueObjects;

namespace UniRider.API.Payments.Domain.Model.Aggregates;

public partial class Payment
{
    public Payment()
    {
        Cardnumber = new CardNumber();
        Expirationdate = new ExpirationDate();
        Cardverification = new CardVerification();
    }

    public Payment(string number, DateTime expiration, string cvv)
    {
        Cardnumber = new CardNumber(number);
        Expirationdate = new ExpirationDate(expiration);
        Cardverification = new CardVerification(cvv);
    }

    public Payment(CreatePaymentCommand command)
    {
        Cardnumber = new CardNumber(command.CardNumber);
        Expirationdate = new ExpirationDate(command.ExpirationDate);
        Cardverification = new CardVerification(command.CVV);
    }
    
    public int Id { get; }
    public CardNumber Cardnumber { get; private set; }
    public CardVerification Cardverification { get; private set; }
    public ExpirationDate Expirationdate { get; private set; }

    public string CardNumber => Cardnumber.Cardnumber;
    public string CardVerification => Cardverification.Cvv;
    public string ExpirationDate => Expirationdate.Value.ToString("MM/dd/yyyy");
}