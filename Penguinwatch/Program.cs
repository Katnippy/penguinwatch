using Penguinwatch;

class Program
{
    private static HttpClient _client = new();
    
    public static async Task Main()
    {
        // TODO: Change this.
        Console.Write("Custom (1) or preset (2)? ");
        if (Int32.Parse(Console.ReadLine()) == 1)
        {
            CustomSearchStrategy custom = new();
            var task = custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), custom.GetUserAPIKey());
            var result = await task;
            
            Console.WriteLine(result);
        }
        else
        {
            PresetSearchStrategy custom = new();
            var task = custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), custom.GetUserAPIKey());
            var result = await task;
            
            Console.WriteLine(result);
        }
    }
}