using Penguinwatch;

public class Program
{
    private static HttpClient _client = new();
    private static bool _rerun = true;

    // TODO: Make program quittable at any time with Q (and make user aware of that).
    // TODO: For all option getters, if up is pressed on 1 then go to last.
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
        Console.WriteLine("");
        Console.WriteLine("Observations");
        Console.WriteLine("------------");
        if (observations.Any())
        {
            foreach (var observation in observations)
            {
                Console.WriteLine($"{observation.HowMany} penguin{
                                      (observation.HowMany > 1 || observation.HowMany == 0 ? "s have" : " has")
                                  } " +
                                  $"been observed at{
                                      (observation.LocationPrivate ? "" : $" {observation.LocationName}")
                                  } " +
                                  $"{(!observation.LocationPrivate ? "(" : "")}{observation.Lat}, {observation.Lng}" +
                                  $"{(!observation.LocationPrivate ? ")" : "")}.");
            }
        }
        else
        {
            Console.WriteLine("No penguins have been observed at this location.");
        }
        Console.WriteLine("");
    }
    
    public static async Task Main()
    {
        while (_rerun)
        {
            var context = new Context();
            if (GetUserCustomOrPresetChoice() == 0)
            {
                context.SetStrategy(new CustomSearchStrategy());
            }
            else
            {
                context.SetStrategy(new PresetSearchStrategy());
            }
            var observations = await context.ExecuteStrategy(_client);
            PrintObservations(observations);
            
            string cont;
            do
            {
                Console.Write("Do you wish to continue? (Y/N) ");
                cont = Console.ReadLine().ToLower();
                if (cont == "n" || cont == "no")
                {
                    _rerun = false;
                }
                else if (cont != "y" && cont != "yes")
                {
                    Console.WriteLine("Please respond by typing 'Y' for yes or 'N' for no.");
                }
            } while (cont != "n" && cont != "no" && cont != "y" && cont != "yes");
            Console.Clear();
        }
    }
}