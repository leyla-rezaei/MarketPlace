namespace MarketPlace.Application.Response;
public class ListResponse<T>
{
    public List<T>? Result { get; set; }
    public ResponseStatus Status { get; set; }
    public string Message { get; set; }

    public static ListResponse<T> Success(List<T> result)
    {
        return new ListResponse<T> { Status = ResponseStatus.Success, Result = result };
    }

    public static ListResponse<T> Success(List<T> result, string message)
    {
        return new ListResponse<T> { Status = ResponseStatus.Success, Result = result, Message = message };
    }

    public static ListResponse<T> Failed(ResponseStatus status, string message)
    {
        return new ListResponse<T> { Status = status, Result = null, Message = message };
    }

    public static implicit operator ListResponse<T>(ResponseStatus value)
    {
        return Failed(value, string.Empty);
    }

    public static implicit operator ListResponse<T>(string message)
    {
        return Failed(ResponseStatus.Failed, message);
    }

    public static implicit operator ListResponse<T>((ResponseStatus, string) value)
    {
        return Failed(value.Item1, value.Item2);
    }

    public static implicit operator ListResponse<T>(List<T> result)
    {
        return Success(result);
    }

    public static implicit operator ListResponse<T>((List<T> result, string message)value)
    {
        return Success(value.result,value.message);
    }
}
