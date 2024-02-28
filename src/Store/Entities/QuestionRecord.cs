using Store.Abstract.Entity;
using Store.Entities.Enums;

namespace Store.Entities;

/// <summary>
/// Представляет сущность вопроса.
/// </summary>
public sealed class QuestionRecord :
    EntityBase,
    IComparable<QuestionRecord>
{
    /// <summary>
    /// ctor.
    /// </summary>
    public QuestionRecord(Guid id) : base(id)
    {
    }

    /// <summary>
    /// Формулировка вопроса.
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// Тип вопроса.
    /// </summary>
    public QuestionType Type { get; set; } = QuestionType.None;

    /// <summary>
    /// Варианты ответов.
    /// </summary>
    public ICollection<AnswerRecord> Answers { get; set; } = new List<AnswerRecord>();

    public int CompareTo(QuestionRecord? other)
    {
        if (other == null) throw new ArgumentNullException();

        return this.Id.CompareTo(other.Id);
    }
}

