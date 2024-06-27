namespace UniRider.API.Profile.Interfaces.REST.Resources;

public record CreateVehicleDocumentResource(string Brand, string Model, string Color, string Plate, int DriverLicenseId, int VehicleInsuranceId);