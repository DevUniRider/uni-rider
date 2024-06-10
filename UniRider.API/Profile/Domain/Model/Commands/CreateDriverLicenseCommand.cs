namespace UniRider.API.Profile.Domain.Model.Commands;

public record CreateDriverLicenseCommand(string Type, string Number , string ExpeditionDate, string ExpirationDate);