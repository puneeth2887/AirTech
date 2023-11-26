namespace AirTechCodingChallenge.Models;

public record Order
{
    public required string OrderNumber { get; init; }
    public required string Destination { get; init; }
}
