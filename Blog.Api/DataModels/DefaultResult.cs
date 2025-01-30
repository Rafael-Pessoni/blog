namespace Blog.Api.DataModels;

public class DefaultResult<T>
{
    public DefaultResult(T data)
    {
        Data = data;
        Success = true;
        Messages = null;
    }
 
    public DefaultResult(string message)
    {
        Success = false;
        Messages = new List<string> { message };
    }

    public DefaultResult(IEnumerable<string>? errorMessages)
    {
        Success = false;
        Messages = errorMessages;
    }

    public DefaultResult(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
    public IEnumerable<string>? Messages { get; set; }
    public T? Data { get; set; }
}
