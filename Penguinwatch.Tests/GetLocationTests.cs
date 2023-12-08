namespace Penguinwatch.Tests;

public class GetLocationTests
{
    private static (double, double) GetLocation(double lat, double lng)
    {
        const int minLat = -90;
        const int maxLat = 90;
        
        if (lat >= minLat && lat <= maxLat)
        {
        }
        else
        { 
            Console.WriteLine("Please enter a number between -90 and 90.");
        }
        
        const int minLng = -180;
        const int maxLng = 180;

        if (lng >= minLng && lng <= maxLng)
        { 
        }
        else
        {
            Console.WriteLine("Please enter a number between -180 and 180.");
        }
            
        return (Math.Round(lat, 2), Math.Round(lng, 2));
    }
    
    [Fact]
    public void TestCoordinatesWithinBoundary()
    {
        // Arrange
        var lat = -26.645833;
        var lng = 15.153889;
        var expected = (-26.65, 15.15);
        
        // Act
        var result = GetLocation(lat, lng);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestLatOutsideOfBoundary()
    {
        // Arrange
        var lat = -900.00;
        var lng = 15.153889;
        var expected = "Please enter a number between -90 and 90.\n";
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act
        GetLocation(lat, lng);

        // Assert
        var result = stringWriter.ToString();
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestLngOutsideOfBoundary()
    {
        // Arrange
        var lat = -26.645833;
        var lng = 1500.00;
        var expected = "Please enter a number between -180 and 180.\n";
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act
        GetLocation(lat, lng);

        // Assert
        var result = stringWriter.ToString();
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestCoordinatesNotADouble()
    {
        // Arrange
        var lat = -26;
        var lng = 15;
        var expected = (-26.00, 15.00);
        
        // Act
        var result = GetLocation(lat, lng);

        // Assert
        Assert.Equal(expected, result);
    }
    
    // [Fact]
    // public void TestCoordinatesNotANumber()
    // {
    //     // Arrange
    //     var lat = "lat";
    //     var lng = "lng";
    //     var expected = "Please enter a number between -90 and 90.\n";
    //     
    //     var stringWriter = new StringWriter();
    //     Console.SetOut(stringWriter);
    //     
    //     // Act
    //     GetLocation(lat, lng);
    //
    //     // Assert
    //     var result = stringWriter.ToString();
    //     Assert.Equal(expected, result);
    // }
}