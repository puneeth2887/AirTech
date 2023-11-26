using AirTechCodingChallenge.Models;
using AirTechCodingChallenge.Services;
using Shouldly;

namespace AirTechCodingChallenge.Tests.ServicesTests;

public class AirportServiceTestsBase
{
    private readonly IAirportService testObject;
    private string code;
    private string name;
    private Airport result;

    public AirportServiceTestsBase()
    {
        testObject = new AirportService();
    }

    protected void GivenCode(string value)
    {
        code = value;
    }

    protected void GivenName(string value)
    {
        name = value;
    }

    protected async Task WhenCreateAirportAsyncIsCalled()
    {
        result = await testObject.CreateAirportAsync(code, name);
    }

    protected void ThenResultHasCode(string value)
    {
        result.Code.ShouldBe(value);
    }

    protected void ThenResultHasName(string value)
    {
        result.Name.ShouldBe(value);
    }
}

public class AirportServiceTests : AirportServiceTestsBase
{
    [Theory]
    [InlineData("A")]
    [InlineData("test")]
    [InlineData(null)]
    public async Task CreateAirportAsync_Code(string code)
    {
        GivenCode(code);
        await WhenCreateAirportAsyncIsCalled();
        ThenResultHasCode(code);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("test")]
    [InlineData(null)]
    public async Task CreateAirportAsync_Name(string name)
    {
        GivenName(name);
        await WhenCreateAirportAsyncIsCalled();
        ThenResultHasName(name);
    }
}