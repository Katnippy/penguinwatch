using Penguinwatch;

class Program
{
    private static HttpClient _client = new();
    
    public static async Task Main()
    {
        // TODO: Change this.
        Console.Write("Custom (1) or preset (2)? ");
        // TODO: Add tests with xUnit.
        if (Int32.Parse(Console.ReadLine()) == 1)
        {
            CustomSearchStrategy custom = new();
            var task = custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), custom.GetUserAPIKey());
            var observations = await task;

            foreach (var observation in observations)
            {
                Console.WriteLine($"{observation.howMany} penguin{(observation.howMany > 1 ? "s have" : " has")} " +
                                  $"been observed at{(observation.locationPrivate ? "" : $" {observation.locName}")} " +
                                  $"{(!observation.locationPrivate ? "(" : "")}{observation.lat}, {observation.lng}" +
                                  $"{(!observation.locationPrivate ? ")" : "")}.");
            }
        }
        // TODO: Add tests with xUnit.
        else
        {
            PresetSearchStrategy custom = new();
            var task = custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), custom.GetUserAPIKey());
            var observations = await task;
            
            foreach (var observation in observations)
            {
                Console.WriteLine($"{observation.howMany} penguin{(observation.howMany > 1 ? "s have" : " has")} " +
                                  $"been observed at{(observation.locationPrivate ? "" : $" {observation.locName}")} " +
                                  $"{(!observation.locationPrivate ? "(" : "")}{observation.lat}, {observation.lng}" +
                                  $"{(!observation.locationPrivate ? ")" : "")}.");
            }
        }
    }
}