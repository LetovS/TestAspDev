using Store.Abstract.Entity;

namespace Store.Entities;

/// <summary>
/// Представляет сущность ответа.
/// </summary>
public sealed class AnswerRecord : EntityBase
{
    /// <summary>
    /// ctor.
    /// </summary>
    public AnswerRecord(Guid id, string answer) : base(id)
    {
        Answer = answer;
    }

    /// <summary>
    /// Ответ на вопрос.
    /// </summary>
    public string Answer { get; set; }


    public Guid QuestionRecordId { get; set; }
}

