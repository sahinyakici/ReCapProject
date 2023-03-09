namespace Core.Utilities.Results.Abstract;

public interface IResult
{
    string Message { get; set; }
    bool Success { get; set; }
}