using Store.Abstract.Entity;

namespace Store.Entities;

/// <summary>
/// Представляет сущность интервью.
/// </summary>
public sealed class InterviewRecord : EntityBase
{
    /// <summary>
    /// ctor.
    /// </summary>
    public InterviewRecord(Guid id) : base(id)
    {
    }
        
    /// <summary>
    /// Дата проведения интервью.
    /// </summary>
    public DateTime InterviewDate { get; set; }

    public Guid SurveyId { get; set; }

    /// <summary>
    /// Результаты опроса.
    /// </summary>
    public ICollection<ResultRecord> Results { get; set; } = new List<ResultRecord>();
}
