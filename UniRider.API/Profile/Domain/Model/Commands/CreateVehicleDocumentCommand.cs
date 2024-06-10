namespace UniRider.API.Profile.Domain.Model.Commands;

public record CreateVehicleDocumentCommand(string Brand, string Model, string Color, string Plate, int DriverLicenseId, int VehicleInsuranceId);