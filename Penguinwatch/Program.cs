using Penguinwatch;

public class Program
{
    private static HttpClient _client = new();

    // TODO: Make program quittable at any time with Q (and make user aware of that).
    private static int GetUserCustomOrPresetChoice()
    {
        var optionSelected = false;
        var option = 0;
        var (leftPos, topPos) = Console.GetCursorPosition();
        const string optionSelectedColour = "\u001b[32m";
        while (!optionSelected)
        {
            Console.SetCursorPosition(leftPos, topPos);
            
            Console.Clear();
            Console.WriteLine("Would you like to see penguins in your location, or in another preset location?");
            Console.WriteLine($"{(option == 0 ? optionSelectedColour : "")}1. My location\u001b[0m");
            Console.WriteLine($"{(option == 1 ? optionSelectedColour : "")}2. Preset location\u001b[0m");

            var key = Console.ReadKey(true);

            const int maxOption = 1;
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

    // ? Explicitate the species?
    private static void PrintObservations(List<PenguinObservationModel> observations)
    {
        if (observations.Any())
        {
            foreach (var observation in observations)
            {
                Console.WriteLine($"{observation.HowMany} penguin{(observation.HowMany > 1 ? "s have" : " has")} " +
                                  $"been observed at{
                                      (observation.LocationPrivate ? "" : $" {observation.LocationName}")
                                  } " +
                                  $"{(!observation.LocationPrivate ? "(" : "")}{observation.Lat}, {observation.Lng}" +
                                  $"{(!observation.LocationPrivate ? ")" : "")}.");
            }
        }
        else
        {
            Console.WriteLine("No penguins have been observed at your location.");
        }
    }
    
    public static async Task Main()
    {
        if (GetUserCustomOrPresetChoice() == 0)
        {
            CustomSearchStrategy custom = new();
            var task = custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), custom.GetUserAPIKey());
            var observations = await task;
            PrintObservations(observations);
        }
        else
        {
            PresetSearchStrategy custom = new();
            var task = custom.CallAPI(_client, custom.GetSpecies(), custom.GetLocation(), custom.GetUserAPIKey());
            var observations = await task;
            PrintObservations(observations);
        }
    }
}