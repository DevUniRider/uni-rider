namespace UniRider.API.Profile.Interfaces.REST.Resources;

public record VehicleDocumentResource(int Id, string Brand, string Model, string Color, string Plate, VehicleInsuranceResource VehicleInsurance, DriverLicenseResource DriverLicense);
