namespace Gatherly.Application.Responses;

public class BaseReponse
{
    public BaseReponse()
    {
        Success = true;
    }

    public BaseReponse(string message)
    {
        Success = true;
        Message = message;
    }

    public BaseReponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> ValidationErrors { get; set; } = new List<string>();
}
