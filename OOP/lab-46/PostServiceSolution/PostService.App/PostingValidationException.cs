namespace PostService.App;

/// <summary>
/// Сервер відхилив дані відправлення (код 400). Містить помилки валідації за назвами полів.
/// </summary>
public class PostingValidationException : Exception
{
    public Dictionary<string, string[]> Errors { get; }

    public PostingValidationException(Dictionary<string, string[]> errors)
        : base("Сервер відхилив дані відправлення.")
    {
        Errors = errors;
    }
}
