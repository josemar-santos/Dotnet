namespace E_Learn.Common.Domain;

public record ApiResponse<T>(string Message, T Content, int StatusCode)
{
    public static ApiResponse<T> Success(T content, string message = "Success") => new(message, content, 200);

    public static ApiResponse<T> Error(string message, int statusCode = 400) => new(message, default!, statusCode);
}
