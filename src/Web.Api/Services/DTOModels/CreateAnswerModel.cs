using Store.Entities.Enums;

namespace Web.Api.Services.DTOModels;

/// <summary>
/// Модель ответа
/// </summary>
public class CreateAnswerModel
{
    /// <summary>
    /// Формулировка вопроса.
    /// </summary>
    public required string Question { get; set; }

    /// <summary>
    /// Ответ(ы) на вопрос.
    /// </summary>
    /// <remarks>
    /// Если тип вопроса <see cref="QuestionType.SingleChoice"/> в коллекции один ответ.
    /// Если тип вопроса <see cref="QuestionType.MultipleChoice"/> в коллекции множество ответов.
    /// </remarks>    
    public required ICollection<string> Answers { get; set; } = new List<string>();
}
