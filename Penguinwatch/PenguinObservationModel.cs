using System.Text.Json.Serialization;

namespace Penguinwatch;

public class PenguinObservationModel
{
    [JsonPropertyName("locName")]
    public string LocationName { get; set; }
    [JsonPropertyName("howMany")]
    public int HowMany { get; set; }
    [JsonPropertyName("lat")]
    public double Lat { get; set; }
    [JsonPropertyName("lng")]
    public double Lng { get; set; }
    [JsonPropertyName("locPrivate")]
    public bool LocationPrivate { get; set; }
}