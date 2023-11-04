namespace Penguinwatch;

public interface IPenguinSearchStrategy
{
    string GetSpecies();
    (double, double) GetLocation(); // ? Distance, too?
    string GetUserAPIKey();
    string CallAPI(HttpClient client, string species, (double, double) location, string APIKey); // ? Not sure what this'll return just yet.
}