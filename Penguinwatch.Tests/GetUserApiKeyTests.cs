namespace Penguinwatch.Tests;

public class GetUserApiKeyTests
{
    private static string GetUserApiKey(string hasAKey, string apiKey = "")
    {
        Console.Write("Do you have an eBird API key? (Y/N) ");
        if (hasAKey == "n" || hasAKey == "no")
        {
           return "Please go to https://ebird.org/api/keygen and obtain an API key first.";
        }
        else if (hasAKey != "y" && hasAKey != "yes")
        {
            return "Please respond by typing 'Y' for yes or 'N' for no.";
        }
        
        Console.Write("Enter your eBird API key: ");
        if (apiKey.Length != 12)
        {
            return "An eBird API key should be 12 characters long.";
        }

        return apiKey;
    }
    
    [Fact]
    public void TestCorrectApiKeyAndY()
    {
        // Arrange
        var hasAKey = "y";
        var apiKey = "apikeyapikey";
        var expected = "apikeyapikey";
        
        // Act
        var result = GetUserApiKey(hasAKey, apiKey);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestCorrectApiKeyAndYes()
    {
        // Arrange
        var hasAKey = "yes";
        var apiKey = "apikeyapikey";
        var expected = "apikeyapikey";
        
        // Act
        var result = GetUserApiKey(hasAKey, apiKey);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestIncorrectApiKey()
    {
        // Arrange
        var hasAKey = "yes";
        var apiKey = "apikeyapikeyy";
        var expected = "An eBird API key should be 12 characters long.";
        
        // Act
        var result = GetUserApiKey(hasAKey, apiKey);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestNoApiKeyAndN()
    {
        // Arrange
        var hasAKey = "n";
        var expected = "Please go to https://ebird.org/api/keygen and obtain an API key first.";
        
        // Act
        var result = GetUserApiKey(hasAKey);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestNoApiKeyAndNo()
    {
        // Arrange
        var hasAKey = "no";
        var expected = "Please go to https://ebird.org/api/keygen and obtain an API key first.";
        
        // Act
        var result = GetUserApiKey(hasAKey);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestBadInput()
    {
        // Arrange
        var hasAKey = "ni";
        var expected = "Please respond by typing 'Y' for yes or 'N' for no.";
        
        // Act
        var result = GetUserApiKey(hasAKey);

        // Assert
        Assert.Equal(expected, result);
    }
}