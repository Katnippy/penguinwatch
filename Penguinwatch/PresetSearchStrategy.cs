namespace Penguinwatch;

public class PresetSearchStrategy : AbstractSearchStrategy
{
    public override (double, double) GetLocation()
    {
        return FindLocationInDict(GetUserLocationChoice());
    }
    
    private static int GetUserLocationChoice()
    {
        var optionSelected = false;
        var option = 0;
        var (leftPos, topPos) = Console.GetCursorPosition();
        const string optionSelectedColour = "\u001b[32m";
        while (!optionSelected)
        {
            Console.SetCursorPosition(leftPos, topPos);
            
            Console.Clear();
            Console.WriteLine("Select a location from where penguins can be observed.");
            // ? Maybe indicate what species can be seen?
            Console.WriteLine($"{(option == 0 ? optionSelectedColour : "")}" + 
                              "1. St. Andrew's Bay, South Georgia and the South Sandwich Islands\u001b[0m");
            Console.WriteLine($"{(option == 1 ? optionSelectedColour : "")}" + 
                              "2. West Point Island, Falkland Islands\u001b[0m");
            Console.WriteLine($"{(option == 2 ? optionSelectedColour : "")}" + 
                              "3. Volunteer Point, Falkland Islands\u001b[0m");
            Console.WriteLine($"{(option == 3 ? optionSelectedColour : "")}" + 
                              "4. New Island, Falkland Islands\u001b[0m");
            Console.WriteLine($"{(option == 4 ? optionSelectedColour : "")}" + 
                              "5. Snow Hill Island, Antarctica\u001b[0m");
            Console.WriteLine($"{(option == 5 ? optionSelectedColour : "")}" + 
                              "6. Dumont d'Urville Station, Antarctica\u001b[0m");
            Console.WriteLine($"{(option == 6 ? optionSelectedColour : "")}" + 
                              "7. Phillip Island Nature Parks, Australia\u001b[0m");
            Console.WriteLine($"{(option == 7 ? optionSelectedColour : "")}" + 
                              "8. Oamaru Blue Penguin Colony, New Zealand\u001b[0m");
            Console.WriteLine($"{(option == 8 ? optionSelectedColour : "")}" + 
                              "9. Isla Martillo, Argentina\u001b[0m");
            Console.WriteLine($"{(option == 9 ? optionSelectedColour : "")}" + 
                              "10. Los Pingüinos Natural Monument, Chile\u001b[0m");
            Console.WriteLine($"{(option == 10 ? optionSelectedColour : "")}" + 
                              "11. Pingüino de Humboldt National Reserve, Chile\u001b[0m");
            Console.WriteLine($"{(option == 11 ? optionSelectedColour : "")}" + 
                              "12. Isabela Island, Galápagos Islands\u001b[0m");
            Console.WriteLine($"{(option == 12 ? optionSelectedColour : "")}" + 
                              "13. Boulders Beach, South Africa\u001b[0m");
            Console.WriteLine($"{(option == 13 ? optionSelectedColour : "")}" + 
                              "14. Otago Peninsula Eco Restoration Alliance, New Zealand\u001b[0m");
            Console.WriteLine($"{(option == 14 ? optionSelectedColour : "")}" + 
                              "15. Monro Beach, New Zealand\u001b[0m");
            Console.WriteLine($"{(option == 15 ? optionSelectedColour : "")}" + 
                              "16. Snares Islands, New Zealand\u001b[0m");
            Console.WriteLine($"{(option == 16 ? optionSelectedColour : "")}" + 
                              "17. Antipodes Island, New Zealand\u001b[0m");
            Console.WriteLine($"{(option == 17 ? optionSelectedColour : "")}" + 
                              "18. Inaccessible Island, St Helena, Ascension, and Tristan da Cunha\u001b[0m");
            Console.WriteLine($"{(option == 18 ? optionSelectedColour : "")}" + 
                              "19. Macquarie Island, Australia\u001b[0m");
            
            var key = Console.ReadKey(true);
            
            const int maxOption = 18;
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
    
    private static (double, double) FindLocationInDict(int option)
    {
        Dictionary<int, (double, double)> locations = new()
        {
            { 0, (-54.43, -36.18) },
            { 1, (-51.35, -60.69) },
            { 2, (-51.47, -57.84) },
            { 3, (-51.72, -61.30) },
            { 4, (-64.47, -57.20) }, 
            { 5, (-66.67, 140.00) },
            { 6, (-38.48, 145.23) },
            { 7, (-45.11, 170.98) },
            { 8, (-54.91, -67.37) },
            { 9, (-52.92, -70.58) },
            { 10, (-29.25, -71.53) },
            { 11, (-0.50, -91.07) },
            { 12, (-34.20, 18.45) },
            { 13, (-45.80, 170.73) },
            { 14, (-43.70, 169.27) },
            { 15, (-48.02, 166.53) },
            { 16, (-49.67, 178.78) },
            { 17, (-37.30, -12.68) },
            { 18, (-54.63, 158.86) },
        };
        
        return locations[option];
    }
}