namespace Penguinwatch;

public interface IPenguinSearchStrategy
{
    string GetSpecies();
    Tuple<double, double> GetLocation(); // ? Distance, too?
    void CallAPI(Tuple<double, double> location); // ? Not sure what this'll return just yet.
}