namespace Store.Abstract.Entity;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class EntityBase : IEntityWithId
{
    /// <summary>
    /// ctor.
    /// </summary>
    protected EntityBase(Guid id)
    {
        Id = id;
    }
    
    /// <inheritdoc/>
    public Guid Id { get; set; }
}