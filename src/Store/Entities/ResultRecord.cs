using Store.Abstract.Entity;

namespace Store.Entities;

/// <summary>
/// Представляет сущность результата.
/// </summary>
public sealed class ResultRecord : EntityBase
{
    /// <summary>
    /// ctor.
    /// </summary>
    public ResultRecord(Guid id) : base(id)
    {
    }

    /// <summary>
    /// Ответ опрашиваемого.
    /// </summary>
    public string Answer { get; set; }

    public Guid InterviewId { get; set; }
}

