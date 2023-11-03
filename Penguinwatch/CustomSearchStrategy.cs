namespace Penguinwatch;

public class CustomSearchStrategy : AbstractSearchStrategy
{
    // TODO: Add tests with xUnit.
    public override (double, double) GetLocation()
    {
        double lat;
        do
        {
            Console.Write("Enter your current latitude in decimal degrees: ");
            if (double.TryParse(Console.ReadLine(), out lat) && lat >= -90 && lat <= 90)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a number between -90 and 90.");
            }
        } while (true);

        double lng;
        do
        {
            Console.Write("Enter your current longitude in decimal degrees: ");
            if (double.TryParse(Console.ReadLine(), out lng) && lng >= -180 && lng <= 180)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a number between -180 and 180.");
            }
        } while (true);
        
        return (lat, lng);
    }
    
    public override void CallAPI((double, double) location)
    {
        // ! Not implemented yet.
    }
}