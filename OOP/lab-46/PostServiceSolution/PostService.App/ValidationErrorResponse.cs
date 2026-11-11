namespace PostService.App;

/// <summary>
/// Частина відповіді сервера з кодом 400 (ValidationProblem), потрібна клієнту:
/// помилки валідації за назвами полів.
/// </summary>
internal class ValidationErrorResponse
{
    public Dictionary<string, string[]> Errors { get; set; } = [];
}
