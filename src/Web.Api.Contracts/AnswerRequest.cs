using Store.Entities.Enums;
namespace Web.Api.Contracts;

/// <summary>
/// Модель запроса ответа
/// </summary>
public sealed class AnswerRequest
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public required string Question { get; set; }

    /// <summary>
    /// Данные ответа
    /// </summary>
    /// <remarks>Если тип вопроса <see cref="QuestionType.MultipleChoice"/> будет несколько ответов.</remarks>
    public ICollection<string> Answers { get; set; } = new List<string>();
}
