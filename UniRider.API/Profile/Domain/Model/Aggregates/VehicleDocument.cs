using UniRider.API.Profile.Domain.Model.Commands;

namespace UniRider.API.Profile.Domain.Model.Aggregates;

public partial class VehicleDocument
{
    public int Id { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Plate { get; private set; }
    
    public DriverLicense DriverLicense { get; set; }
    
    public int DriverLicenseId { get; private set; }
    
    public VehicleInsurance VehicleInsurance { get; set; }
    
    public int VehicleInsuranceId { get; private set; }

    protected VehicleDocument(string brand, string model, string color, string plate, int driverLicenseId, int vehicleInsuranceId)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        DriverLicenseId = driverLicenseId;
        VehicleInsuranceId = vehicleInsuranceId;
    }
    
    
    public VehicleDocument(CreateVehicleDocumentCommand command)
    {
        Brand = command.Brand;
        Model = command.Model;
        Color = command.Color;
        Plate = command.Plate;
        DriverLicenseId = command.DriverLicenseId;
        VehicleInsuranceId = command.VehicleInsuranceId;
    }
    
}