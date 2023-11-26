using AirTekCodingChallenge.Models;
using AirTekCodingChallenge.Services;
using Shouldly;

namespace AirTekCodingChallenge.Tests.ServicesTests;

public class FlightServiceTestsBase
{
    private readonly IFlightService testObject;
    private string number;
    private Airport departure;
    private Airport arrival;
    private Plane plane;
    private int day;
    private Flight result;

    public FlightServiceTestsBase()
    {
        testObject = new FlightService();
    }

    protected void GivenDay(int value)
    {
        day = value;
    }

    protected void GivenNumber(string value)
    {
        number = value;
    }

    protected void GivenDepature(Airport value)
    {
        departure = value;
    }

    protected void GivenArrival(Airport value)
    {
        arrival = value;
    }

    protected void GivenPlane(Plane value)
    {
        plane = value;
    }

    protected async Task WhenCreateFlightAsyncIsCalled()
    {
        result = await testObject.CreateFlightAsync(number, departure, arrival, plane, day);
    }


    protected void ThenResultHasDay(int value)
    {
        result.Day.ShouldBe(value);
    }

    protected void ThenResultHasNumber(string value)
    {
        result.Number.ShouldBe(value);
    }

    protected void ThenResultHasDeparture(Airport value)
    {
        result.Departure.ShouldBe(value);
    }

    protected void ThenResultHasArrival(Airport value)
    {
        result.Arrival.ShouldBe(value);
    }

    protected void ThenResultHasPlane(Plane value)
    {
        result.Plane.ShouldBe(value);
    }

    public static IEnumerable<object[]> AirportData
    {
        get
        {
            yield return new object[] { new Airport { Code = "ABC", Name = "Test" } };
            yield return new object[] { new Airport { Code = "XYZ", Name = "Random" } };
        }
    }
    public static IEnumerable<object[]> PlaneData
    {
        get
        {
            yield return new object[] { new Plane { Name = "1", Capacity = 10 } };
            yield return new object[] { new Plane { Name = "2", Capacity = 20 } };
        }
    }
}

public class FlightServiceTests : FlightServiceTestsBase
{
    [Theory]
    [InlineData("A")]
    [InlineData("test")]
    [InlineData(null)]
    public async Task CreateFlightAsync_Number(string value)
    {
        GivenNumber(value);
        await WhenCreateFlightAsyncIsCalled();
        ThenResultHasNumber(value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(100)]
    public async Task CreateFlightAsync_Day(int value)
    {
        GivenDay(value);
        await WhenCreateFlightAsyncIsCalled();
        ThenResultHasDay(value);
    }

    [Theory]
    [MemberData(nameof(AirportData))]
    public async Task CreateFlightAsync_Departure(Airport airport)
    {
        GivenDepature(airport);
        await WhenCreateFlightAsyncIsCalled();
        ThenResultHasDeparture(airport);
    }

    [Theory]
    [MemberData(nameof(AirportData))]
    public async Task CreateFlightAsync_Arrival(Airport airport)
    {
        GivenArrival(airport);
        await WhenCreateFlightAsyncIsCalled();
        ThenResultHasArrival(airport);
    }

    [Theory]
    [MemberData(nameof(PlaneData))]
    public async Task CreateFlightAsync_Plane(Plane plane)
    {
        GivenPlane(plane);
        await WhenCreateFlightAsyncIsCalled();
        ThenResultHasPlane(plane);
    }
}