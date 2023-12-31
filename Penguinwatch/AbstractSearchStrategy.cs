using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Penguinwatch;

public abstract class AbstractSearchStrategy : IPenguinSearchStrategy
{
    public string GetSpecies()
    {
        return FindSpeciesInDict(GetUserSpeciesChoice());
    }

    private static int GetUserSpeciesChoice()
    {
        var optionSelected = false;
        var option = 0;
        var (leftPos, topPos) = Console.GetCursorPosition();
        const string optionSelectedColour = "\u001b[32m";
        while (!optionSelected)
        {
            Console.SetCursorPosition(leftPos, topPos);

            Console.Clear();
            Console.WriteLine("What species of penguin would you like to see?");
            // TODO: Add all species option.
            Console.WriteLine($"{(option == 0 ? optionSelectedColour : "")}1. King Penguin\u001b[0m");
            Console.WriteLine($"{(option == 1 ? optionSelectedColour : "")}2. Emperor Penguin\u001b[0m");
            Console.WriteLine($"{(option == 2 ? optionSelectedColour : "")}3. Adélie Penguin\u001b[0m");
            Console.WriteLine($"{(option == 3 ? optionSelectedColour : "")}4. Chinstrap Penguin\u001b[0m");
            Console.WriteLine($"{(option == 4 ? optionSelectedColour : "")}5. Gentoo Penguin\u001b[0m");
            Console.WriteLine($"{(option == 5 ? optionSelectedColour : "")}6. Little Penguin\u001b[0m");
            Console.WriteLine($"{(option == 6 ? optionSelectedColour : "")}7. Magellanic Penguin\u001b[0m");
            Console.WriteLine($"{(option == 7 ? optionSelectedColour : "")}8. Humboldt Penguin\u001b[0m");
            Console.WriteLine($"{(option == 8 ? optionSelectedColour : "")}9. Galápagos Penguin\u001b[0m");
            Console.WriteLine($"{(option == 9 ? optionSelectedColour : "")}10. African Penguin\u001b[0m");
            Console.WriteLine($"{(option == 10 ? optionSelectedColour : "")}11. Yellow-eyed Penguin\u001b[0m");
            Console.WriteLine($"{(option == 11 ? optionSelectedColour : "")}12. Fiordland Penguin\u001b[0m");
            Console.WriteLine($"{(option == 12 ? optionSelectedColour : "")}13. Snares Penguin\u001b[0m");
            Console.WriteLine($"{(option == 13 ? optionSelectedColour : "")}14. Erect-crested Penguin\u001b[0m");
            Console.WriteLine($"{(option == 14 ? optionSelectedColour : "")}15. Southern Rockhopper Penguin\u001b[0m");
            Console.WriteLine($"{(option == 15 ? optionSelectedColour : "")}16. Northern Rockhopper Penguin\u001b[0m");
            Console.WriteLine($"{(option == 16 ? optionSelectedColour : "")}17. Royal Penguin\u001b[0m");
            Console.WriteLine($"{(option == 17 ? optionSelectedColour : "")}18. Macaroni Penguin\u001b[0m");

            var key = Console.ReadKey(true);
            
            const int maxOption = 17;
            const int minOption = 0;
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (option == maxOption)
                    {
                    }
                    else
                    {
                        option++;
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (option == minOption)
                    {
                    }
                    else
                    {
                        option--;
                    }

                    break;
                case ConsoleKey.Enter:
                    optionSelected = true;
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }

        return option;
    }

    private static string FindSpeciesInDict(int option)
    {
        Dictionary<int, string> species = new()
        {
            { 0, "kinpen1" },
            { 1, "emppen1" },
            { 2, "adepen1" },
            { 3, "chipen2" },
            { 4, "genpen1" },
            { 5, "litpen1" },
            { 6, "magpen1" },
            { 7, "humpen1" },
            { 8, "galpen1" },
            { 9, "jacpen1" },
            { 10, "yeepen1" },
            { 11, "fiopen1" },
            { 12, "snapen1" },
            { 13, "bicpen1" },
            { 14, "rocpen1" },
            { 15, "rocpen4" },
            { 16, "roypen1" },
            { 17, "macpen1" },
        };

        return species[option];
    }

    public abstract (double, double) GetLocation();
    
    public string GetUserApiKey()
    {
        string hasAKey;
        do
        {
            Console.Write("Do you have an eBird API key? (Y/N) ");
            hasAKey = Console.ReadLine().ToLower();
            if (hasAKey == "n" || hasAKey == "no")
            {
                Console.WriteLine("Please go to https://ebird.org/api/keygen and obtain an API key first.");
                Console.WriteLine("");
                OpenEBirdWebsite();
                Console.WriteLine("");
            }
            else if (hasAKey != "y" && hasAKey != "yes")
            {
                Console.WriteLine("Please respond by typing 'Y' for yes or 'N' for no.");
            }
        } while (hasAKey != "n" && hasAKey != "no" && hasAKey != "y" && hasAKey != "yes");

        string apiKey;
        do
        {
            Console.Write("Enter your eBird API key: ");
            apiKey = Console.ReadLine();

            if (apiKey.Length != 12)
            {
                Console.WriteLine("An eBird API key should be 12 characters long.");
            }
        } while (apiKey.Length != 12);

        return apiKey;
    }

    private static void OpenEBirdWebsite()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start(new ProcessStartInfo("https://ebird.org/api/keygen") { UseShellExecute = true });
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("xdg-open", "https://ebird.org/api/keygen");
        }
        Thread.Sleep(2500);
    }
    
    // ? Do we need to handle timeouts?
    // ? Split into 2 methods?
    // TODO: Allow for user to adjust distance?

    // Call the appropriate API URI, return a deserialised list of observations.
    public async Task<List<PenguinObservationModel>>? CallApi(HttpClient client, string species, 
                                                             (double, double) location, string apiKey)
    { 
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://api.ebird.org/v2/data/nearest/geo/recent/" +
            $"{species}?lat={location.Item1}&lng={location.Item2}&dist=25");
        request.Headers.Add("X-eBirdApiToken", apiKey);

        var response = await client.SendAsync(request);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                Console.WriteLine("Invalid API key.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(e);
                Environment.Exit(0);
            }
        }
        var result = await response.Content.ReadAsStringAsync();
        var observations = JsonSerializer.Deserialize<List<PenguinObservationModel>>(result);
        
        return observations;
    }
}