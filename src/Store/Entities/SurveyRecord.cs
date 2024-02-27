using Store.Abstract.Entity;

namespace Store.Entities;

/// <summary>
/// Представляет сущность опроса.
/// </summary>
public sealed class SurveyRecord : EntityBase
{
    /// <summary>
    /// ctor.
    /// </summary>
    public SurveyRecord(Guid id) : base(id)
    {
    }

    /// <summary>
    /// Название опроса.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Описание опроса.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания опроса.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата начала опроса.
    /// </summary>
    public DateTime StartDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата завершения опроса.
    /// </summary>
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(14);

    /// <summary>
    /// Заданные вопросы
    /// </summary>
    public ICollection<QuestionRecord> Questions { get; set; } = new List<QuestionRecord>();

    /// <summary>
    /// Все пройденные интервью
    /// </summary>
    public ICollection<InterviewRecord> Interviews { get; set; } = new List<InterviewRecord>();
}

