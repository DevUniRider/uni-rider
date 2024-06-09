namespace UniRider.API.Profile.Domain.Model.Commands;

public record CreateVehicleInsuranceCommand(string PolicyNumber, string Insurer, string StartDate, string ExpirationDate);