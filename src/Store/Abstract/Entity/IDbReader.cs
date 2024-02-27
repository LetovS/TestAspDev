namespace Store.Abstract.Entity;

public interface IDbReader
{
    /// <summary>
    /// Чтение из базы данных
    /// </summary>
    IQueryable<TEntity> Read<TEntity>() where TEntity : EntityBase;
}
