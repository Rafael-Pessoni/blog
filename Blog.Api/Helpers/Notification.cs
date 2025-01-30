
using System.Collections.ObjectModel;

namespace Blog.Api.Helpers;

public class Notification : INotification
{
    public Notification()
    {
        _messages = new Collection<string>();
    }

    private readonly Collection<string> _messages;

    public void Add(string message) => _messages.Add(message);

    public bool Any() => _messages.Any();

    public IEnumerable<string> Get() => _messages;
}
