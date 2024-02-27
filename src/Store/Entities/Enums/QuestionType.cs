namespace Store.Entities.Enums;

/// <summary>
/// Типы вопросов
/// </summary>
public enum QuestionType
{
    /// <summary>
    /// Тип не указан.
    /// </summary>
    None,
    /// <summary>
    /// Текстовый вопрос.
    /// </summary>
    Text,
    /// <summary>
    /// Вопрос с выбором одного варианта ответа.
    /// </summary>
    SingleChoice,
    /// <summary>
    /// Вопрос с выбором нескольких вариантов ответа.
    /// </summary>
    MultipleChoice
}

