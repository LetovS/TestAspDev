namespace Web.Api.Contracts;

/// <summary>
/// Модель ответа вопроса
/// </summary>
public sealed class QuestionResponse
{
    /// <summary>
    /// ИД вопроса.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Формулировка вопроса
    /// </summary>
    public required string Question { get; set; }

    /// <summary>
    /// Варианты ответов
    /// </summary>
    public IReadOnlyList<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
}
