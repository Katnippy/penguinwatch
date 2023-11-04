using Penguinwatch;

class Program
{
    private static HttpClient _client = new();
    
    public static void Main()
    {
        Console.Write("1 or 2? ");
        if (Int32.Parse(Console.ReadLine()) == 1)
        {
            CustomSearchStrategy custom = new();
            Console.WriteLine(custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), 
                              custom.GetUserAPIKey()));
        }
        else
        {
            Console.WriteLine("2");            
        }
    }
}