using UniRider.API.Profile.Domain.Model.Commands;

namespace UniRider.API.Profile.Domain.Model.Aggregates;

public partial class VehicleInsurance
{
    public int Id { get; set; }
    public string PolicyNumber { get; private set; }
    public string Insurer { get; private set; }
    public string StartDate { get; private set; }
    public string ExpirationDate { get; private set; }
    //public IEnumerable<VehicleDocument>? VehicleDocument { get; set; }

    protected VehicleInsurance()
    {
        this.PolicyNumber = string.Empty;
        this.Insurer = string.Empty;
        this.StartDate = string.Empty;
        this.ExpirationDate = string.Empty;
    }
    
    public VehicleInsurance(CreateVehicleInsuranceCommand command)
    {
        this.PolicyNumber = command.PolicyNumber;
        this.Insurer = command.Insurer;
        this.StartDate = command.StartDate;
        this.ExpirationDate = command.ExpirationDate;
    }
    public ICollection<VehicleDocument> VehicleDocument { get; }
}