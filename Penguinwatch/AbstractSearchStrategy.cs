namespace Penguinwatch;

public abstract class AbstractSearchStrategy : IPenguinSearchStrategy
{
    // TODO: Put below functions above.
    public string GetSpecies()
    {
        return FindSpeciesInDict(GetUserSpeciesChoice());
    }

    private int GetUserSpeciesChoice()
    {
        var optionSelected = false;
        var option = 0;
        var (leftPos, topPos) = Console.GetCursorPosition();
        const string optionSelectedColour = "\u001b[32m";
        
        Console.WriteLine("What species of penguin would you like to see?");
        
        while (!optionSelected)
        {
            Console.SetCursorPosition(leftPos, topPos);
            
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

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (option == 17)
                    {
                    }
                    else
                    {
                        option++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (option == 0)
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

    private string FindSpeciesInDict(int option)
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

    public abstract void CallAPI((double, double) location);
}