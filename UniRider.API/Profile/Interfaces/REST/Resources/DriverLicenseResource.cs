namespace UniRider.API.Profile.Interfaces.REST.Resources;

public record DriverLicenseResource(int Id, string Type, string Number, string ExpeditionDate, string ExpirationDate);