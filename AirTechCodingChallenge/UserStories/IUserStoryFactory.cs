namespace AirTechCodingChallenge.UserStories
{
    public interface IUserStoryFactory
    {
        IUserStory CreateUserStory(UserStoryType type);
    }
}