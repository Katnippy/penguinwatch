using System.Diagnostics.CodeAnalysis;

namespace Penguinwatch;

public interface IPenguinSearchStrategy
{
    string GetSpecies();
    (double, double) GetLocation();
    string GetUserApiKey();
    Task<List<PenguinObservationModel>>? CallApi(HttpClient client, string species, (double, double) location, string ApiKey);
}