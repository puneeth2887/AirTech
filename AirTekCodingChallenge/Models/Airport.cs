namespace AirTekCodingChallenge.Models;

public record Airport
{
    public required string Code { get; init; }
    public required string Name { get; init; }
}
