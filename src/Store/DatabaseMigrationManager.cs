using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Store.Migrations;

public static class DatabaseMigrationManager
{
    /// <summary>
    /// Накат миграций
    /// </summary>
    /// <returns></returns>
    public static async Task MigrateSchema()
    {
        Console.WriteLine("Applying database schema migration...");

        await Migrate<ResourcesContext, ResourcesContextDesignTimeFactory>().ConfigureAwait(false);

        Console.WriteLine("Done");
    }

    /// <summary>
    /// Инициализация тестовых данных
    /// </summary>
    /// <returns></returns>
    public static async Task InitialTestData()
    {
        Console.WriteLine("Initial test data...");

        await SeedData<ResourcesContext, ResourcesContextDesignTimeFactory>().ConfigureAwait(false);

        Console.WriteLine("Done");
    }

    private static async Task Migrate<TDbContext, TDbContextFactory>()
        where TDbContext : DbContext
        where TDbContextFactory : IDesignTimeDbContextFactory<TDbContext>, new()
    {
        var dbContextFactory = new TDbContextFactory();
        await using var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());

        await dbContext.Database.MigrateAsync().ConfigureAwait(false);
    }

    private static async Task SeedData<TDbContext, TDbContextFactory>()
        where TDbContext : DbContext
        where TDbContextFactory : IDesignTimeDbContextFactory<TDbContext>, new()
    {
        var dbContextFactory = new TDbContextFactory();
        await using var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());


        await dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Surveys\" (\"Id\",\"Title\",\"Description\",\"CreatedAt\",\"StartDate\",\"EndDate\") VALUES " +
            "('82b6e4f5-5830-4a8d-9e17-6b49c9fb7e4f','First',NULL,'2024-02-27 18:52:08.464593+03','2024-02-27 18:52:08.464611+03','2024-03-12 18:52:08.464624+03');");

        await dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Questions\" (\"Id\",\"Question\",\"Type\",\"SurveyId\") VALUES " +
            "('f8b1d827-4324-4c92-87a4-dcd0aa6f1c94','Where are you from?',1,'82b6e4f5-5830-4a8d-9e17-6b49c9fb7e4f')," +
            "('9c4f9446-7c11-4c8b-9b1b-daa4711dbbe1','How old you?',1,'82b6e4f5-5830-4a8d-9e17-6b49c9fb7e4f');");

        await dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Interviews\" (\"Id\",\"InterviewDate\",\"SurveyId\") VALUES " +
            "('6e33a3f8-1201-4e12-b919-f72a0a1c318e','2024-02-28 00:00:00+03','82b6e4f5-5830-4a8d-9e17-6b49c9fb7e4f');");

        await dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Answers\" (\"Id\",\"Answer\",\"QuestionId\") VALUES " +
            "('c9799c6f-7b1a-48a2-9107-9bea68f16e75','Spb','f8b1d827-4324-4c92-87a4-dcd0aa6f1c94')," +
            "('b3e16ac1-1451-4f36-9e94-4f1d2b3b85e9','Msc','f8b1d827-4324-4c92-87a4-dcd0aa6f1c94')," +
            "('f3aa29a5-0ae1-4c2a-b00a-6e8fd3121bb8','Other','f8b1d827-4324-4c92-87a4-dcd0aa6f1c94')," +
            "('7d1f2e5d-9fc7-4b90-b1f9-d2d3280fe1e3','18','9c4f9446-7c11-4c8b-9b1b-daa4711dbbe1')," +
            "('a8e67a7f-6f7a-482e-ae92-58f6e6d0b4a6','25','9c4f9446-7c11-4c8b-9b1b-daa4711dbbe1')," +
            "('e5c97b3b-3f53-4e67-ae24-4b12b1f017a8','36','9c4f9446-7c11-4c8b-9b1b-daa4711dbbe1')");
    }
}