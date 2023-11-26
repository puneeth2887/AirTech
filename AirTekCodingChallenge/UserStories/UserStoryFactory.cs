namespace AirTekCodingChallenge.UserStories;

public class UserStoryFactory : IUserStoryFactory
{
    private readonly IEnumerable<IUserStory> stories;

    public UserStoryFactory(IEnumerable<IUserStory> stories)
    {
        this.stories = stories;
    }

    public IUserStory CreateUserStory(UserStoryType type)
    {
        var story = stories.FirstOrDefault(p => p.AppliesTo == type) ?? throw new NotSupportedException();
        return story;
    }
}
