using Microsoft.EntityFrameworkCore;
using Store.Abstract;
using Store.Entities;

namespace Store;

public class ResourcesContext : 
    DbContext,
    IResourcesContext
{
    public DbSet<AnswerRecord> Answers => Set<AnswerRecord>();
    public DbSet<InterviewRecord> Interviews => Set<InterviewRecord>();
    public DbSet<QuestionRecord> Questions => Set<QuestionRecord>();
    public DbSet<ResultRecord> Results => Set<ResultRecord>();
    public DbSet<SurveyRecord> Surveys => Set<SurveyRecord>();

    /// <summary>
    /// ctor.
    /// </summary>
    public ResourcesContext(DbContextOptions<ResourcesContext> options) : base(options) { }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    void IResourcesContext.Add<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Added;

    void IResourcesContext.Update<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Modified;

    void IResourcesContext.Delete<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Deleted;

    /// <summary>
    /// Сохранить изменения
    /// </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        var count = await base.SaveChangesAsync(token);
        
        foreach (var entry in base.ChangeTracker.Entries().ToArray())
        {
            entry.State = EntityState.Detached;
        }

        return count;
    }

    IQueryable<TEntity> IResourcesContext.Read<TEntity>() => base.Set<TEntity>().AsNoTracking().AsQueryable();

}
