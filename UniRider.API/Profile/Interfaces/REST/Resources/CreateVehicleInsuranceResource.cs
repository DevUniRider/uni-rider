namespace UniRider.API.Profile.Interfaces.REST.Resources;

public record CreateVehicleInsuranceResource( string PolicyNumber, string Insurer, string StartDate, string ExpirationDate);