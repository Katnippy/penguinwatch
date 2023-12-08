namespace Penguinwatch;

public class CustomSearchStrategy : AbstractSearchStrategy
{
    public override (double, double) GetLocation()
    {
        double lat;
        const int minLat = -90;
        const int maxLat = 90;
        do
        {
            Console.Write("Enter your current latitude in decimal degrees: ");
            if (double.TryParse(Console.ReadLine(), out lat) && lat >= minLat && lat <= maxLat)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a number between -90 and 90.");
            }
        } while (true);

        double lng;
        const int minLng = -180;
        const int maxLng = 180;
        do
        {
            Console.Write("Enter your current longitude in decimal degrees: ");
            if (double.TryParse(Console.ReadLine(), out lng) && lng >= minLng && lng <= maxLng)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a number between -180 and 180.");
            }
        } while (true);
        
        return (Math.Round(lat, 2), Math.Round(lng, 2));
    }
}