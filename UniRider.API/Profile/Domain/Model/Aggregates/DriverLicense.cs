using UniRider.API.Profile.Domain.Model.Commands;

namespace UniRider.API.Profile.Domain.Model.Aggregates;

public partial class DriverLicense
{
    public int Id { get; private set; }
    public string Type { get; private set; }
    public string Number { get; private set; }
    public string ExpeditionDate { get; private set; }
    public string ExpirationDate { get; private set; }

    protected DriverLicense()
    {
        this.Type = string.Empty;
        this.Number = string.Empty;
        this.ExpeditionDate = string.Empty;
        this.ExpirationDate = string.Empty;
    }

    public DriverLicense(CreateDriverLicenseCommand command)
    {
        this.Type = command.Type;
        this.Number = command.Number;
        this.ExpeditionDate = command.ExpeditionDate;
        this.ExpirationDate = command.ExpirationDate;
    }
}