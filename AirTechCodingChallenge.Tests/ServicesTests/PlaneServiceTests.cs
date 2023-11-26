using AirTechCodingChallenge.Models;
using AirTechCodingChallenge.Services;
using Shouldly;

namespace AirTechCodingChallenge.Tests.ServicesTests;

public class PlaneServiceTestsBase
{
    private readonly IPlaneService testObject;
    private string name;
    private int capacity;
    private Plane result;

    public PlaneServiceTestsBase()
    {
        testObject = new PlaneService();
    }

    protected void GivenCapacity(int value)
    {
        capacity = value;
    }

    protected void GivenName(string value)
    {
        name = value;
    }

    protected async Task WhenCreatePlaneAsyncIsCalled()
    {
        result = await testObject.CreatePlaneAsync(name, capacity);
    }

    protected async Task WhenCreatePlaneAsyncIsCalledWithDefault()
    {
        result = await testObject.CreatePlaneAsync(name);
    }

    protected void ThenResultHasCapacity(int value)
    {
        result.Capacity.ShouldBe(value);
    }

    protected void ThenResultHasName(string value)
    {
        result.Name.ShouldBe(value);
    }
}

public class PlaneServiceTests : PlaneServiceTestsBase
{
    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(100)]
    public async Task CreatePlaneAsync_Capacity(int value)
    {
        GivenCapacity(value);
        await WhenCreatePlaneAsyncIsCalled();
        ThenResultHasCapacity(value);
    }

    [Fact]
    public async Task CreatePlaneAsync_CapacityDefault()
    {
        await WhenCreatePlaneAsyncIsCalledWithDefault();
        ThenResultHasCapacity(20);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("test")]
    [InlineData(null)]
    public async Task CreatePlaneAsync_Name(string name)
    {
        GivenName(name);
        await WhenCreatePlaneAsyncIsCalled();
        ThenResultHasName(name);
    }
}