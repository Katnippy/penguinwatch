namespace Penguinwatch;

public class Context
{
    private IPenguinSearchStrategy _strategy;

    public void SetStrategy(IPenguinSearchStrategy strategy)
    {
        _strategy = strategy;
    }

    public async Task<List<PenguinObservationModel>> ExecuteStrategy(HttpClient client)
    {
        var task = _strategy.CallApi(client, _strategy.GetSpecies(), _strategy.GetLocation(), 
                                     _strategy.GetUserApiKey());
        var observations = await task;

        return observations;
    }
}