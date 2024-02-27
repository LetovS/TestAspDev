using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Abstract.Entity;
using Store.Entities;
using Store.Entities.Enums;

namespace Store.Abstract;

public interface IResourcesContext
{
    /// <summary>
    /// Ответы.
    /// </summary>
    public DbSet<AnswerRecord> Answers { get; }

    /// <summary>
    /// Интервью.
    /// </summary>
    public DbSet<InterviewRecord> Interviews { get; }

    /// <summary>
    /// Вопросы.
    /// </summary>
    public DbSet<QuestionRecord> Questions { get; }

    /// <summary>
    /// Результаты.
    /// </summary>
    public DbSet<ResultRecord> Results { get; }

    /// <summary>
    /// Опросы.
    /// </summary>
    public DbSet<SurveyRecord> Surveys { get; }

    /// <summary>
    /// Добавление объекта <see cref="EntityBase"/> в БД
    /// </summary>
    void Add<TEntity>(TEntity entity) where TEntity : EntityBase;

    /// <summary>
    /// Обновление объекта <see cref="EntityBase"/> в БД
    /// </summary>
    void Update<TEntity>(TEntity entity) where TEntity : EntityBase;

    /// <summary>
    /// Удаление объекта <see cref="EntityBase"/> из БД
    /// </summary>
    void Delete<TEntity>(TEntity entity) where TEntity : EntityBase;

    Task<int> SaveChangesAsync(CancellationToken ct = default);

    /// <summary>
    /// Чтение из базы данных
    /// </summary>
    IQueryable<TEntity> Read<TEntity>() where TEntity : EntityBase;

    /// <summary>
    /// Фасад
    /// </summary>
    DatabaseFacade Database { get; }
}
