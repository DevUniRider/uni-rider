namespace UniRider.API.Profile.Interfaces.REST.Resources;

public record VehicleInsuranceResource(int Id, string PolicyNumber, string Insurer, string StartDate, string ExpirationDate);