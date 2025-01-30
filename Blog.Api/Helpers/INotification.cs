namespace Blog.Api.Helpers;

public interface INotification
{
    void Add(string message);
    bool Any();
    IEnumerable<string> Get();
}
