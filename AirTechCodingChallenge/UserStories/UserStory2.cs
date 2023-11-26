using AirTechCodingChallenge.Services;

namespace AirTechCodingChallenge.UserStories;

public class UserStory2 : IUserStory
{
    private readonly IDataService dataService;

    public UserStoryType AppliesTo => UserStoryType.Type2;

    public UserStory2(IDataService dataService)
    {
        this.dataService = dataService;
    }

    public async Task ExecuteAsync()
    {
        var freights = await dataService.LoadFreightsAsync();
        foreach (var freight in freights)
        {
            Console.WriteLine(freight);
        }
    }
}
