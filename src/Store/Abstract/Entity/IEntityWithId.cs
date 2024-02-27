namespace Store.Abstract.Entity;

/// <summary>
/// Сущность с ИД
/// </summary>
public interface IEntityWithId : IEntity
{
    /// <summary>
    /// Entity's identificator
    /// </summary>
    public Guid Id { get; set; }
}