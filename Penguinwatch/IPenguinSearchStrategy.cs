namespace Penguinwatch;

public interface IPenguinSearchStrategy
{
    string GetSpecies();
    (double, double) GetLocation(); // ? Distance, too?
    string GetUserAPIKey();
    Task<string> CallAPI(HttpClient client, string species, (double, double) location, string APIKey);
}