namespace UniRider.API.Profile.Interfaces.REST.Resources;

public record CreateDriverLicenseResource(string Type, string Number, string ExpeditionDate, string ExpirationDate);