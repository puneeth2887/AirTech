namespace AirTekCodingChallenge.UserStories
{
    public interface IUserStoryFactory
    {
        IUserStory CreateUserStory(UserStoryType type);
    }
}