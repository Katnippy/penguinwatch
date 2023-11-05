namespace Penguinwatch;

public interface IPenguinSearchStrategy
{
    string GetSpecies();
    (double, double) GetLocation();
    string GetUserAPIKey();
    Task<List<PenguinObservationModel>> CallAPI(HttpClient client, string species, (double, double) location, string APIKey);
}