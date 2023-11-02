namespace Penguinwatch;

public interface IPenguinSearchStrategy
{
    string GetSpecies();
    (double, double) GetLocation(); // ? Distance, too?
    void CallAPI((double, double) location); // ? Not sure what this'll return just yet.
}